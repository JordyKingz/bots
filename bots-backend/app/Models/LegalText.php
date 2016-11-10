<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use GuzzleHttp\Client;
use DOMDocument;

class LegalText extends Model
{
  public $timestamps = false;
  public static $searchThroughTags = [
    'p',
    'h1',
    'h2',
    'h3',
    'h4',
    'h5',
    'div',
    'body',
    'header',
    'a',
    'strong',
    'i',
    'b',
  ];
  private static $doc;
  // titles in lowercase (html gets normalised to lower)
  private static $findTitles = [
    'algemene voorwaarden',
    'algemene actievoorwaarden',
    'zakelijke klanten',
    'privacy verklaring',
    'cookies',
    'spaarprogramma',
  ];

  public static function textByUrl($url) {
    $client = new Client();
    $res = $client->request('GET', $url);
    $htmlString = $res->getBody()->getContents();
    $htmlDomDoc = self::parseStringToHtml($htmlString);
    $text = self::stripTextFromHtml($htmlDomDoc);

    return $text;
  }

  public static function parseStringToHtml($string) {
    $doc = new DOMDocument();
    self::$doc = $doc;
    libxml_use_internal_errors(true);
    $string = strtolower($string);
    $doc->loadHTML($string);
    libxml_use_internal_errors(false);
    return $doc;
  }

  public static function checkIfParentIsLegal($domElement) {
    $domElement = $domElement->parentNode;
    foreach ($domElement->childNodes as $key => $childNode) {
      if ($childNode->nodeName == "p") {
        $domElement->childNodes[$key]->appendChild(self::$doc->createElement("slashN" , '\\n'));
      }
    }
    $html = $domElement->nodeValue;
    return strlen($html) > 1000 ? $html : false;
  }

  public static function stripTextFromHtml($htmlDomDoc) {
    $domNodeLists = [];
    foreach (self::$searchThroughTags as $tagName) {
      $domNodeLists[] = $htmlDomDoc->getElementsByTagName($tagName);
    }

    $match = false;
    foreach ($domNodeLists as $domNodeList) {
      foreach ($domNodeList as $domElement) {
        foreach (self::$findTitles as $title) {
          if (strpos($domElement->nodeValue, $title) === 0) {
            // we have a potentialMatch
            $match = self::checkIfParentIsLegal($domElement);
            if ($match) {
              // we have a definitive match
              break;
            }
          }
        }
      }
      if ($match) {
        break;
      }
    }
    return $match;
  }



  public static function analyse($legalText) {
    $parts = self::findParts($legalText);
    // Split parts into sentences
    $sentences = self::makeSentences($parts);

    // In de zinnen kijken naar woorden
    $words = [
      "privacy" => [  // Praat over privacy
        "persoonlijke gegevens" => [ // Context = Persoonlijke gegevens
            "verspreiding" => [ // Woord wat iets zegt over context
              "cancel" => ["geen"], // Cancel voor dit woord - kijk in zin
              "weight" => 50
            ],
            "verkopen"
        ],
        "ontknoping" => [
          "verloting" => [
            "cancel" => [],
            "weight" => 30
          ]
        ]
      ]
    ];

    $results = self::performForeachHell($words, $sentences);

    return $results;
  }

  // analysing
  public static function performForeachHell($words, $sentences) {
    $result = [];
    foreach($words as $catname => $cat) {
      $weight = 0;
      # loop through each category
      foreach($cat as $context => $subwords){
        # loop through each keyword
        foreach($subwords as $subword => $attributes){
          # Loop through each subword in the sentences, mark as shady if found
          foreach($sentences as $part){
            # Loop through all the parts
            foreach($part as $sentence){
              # Loop through every part as a sentence... look for the subwords and keywords, mark as category
              $shitfound = false;
              if(stripos($sentence,$context) !== false){
                # Found keyword in sentence
                if(stripos($sentence,$subword) !== false){
                  # Also found subword that makes shit bad
                  if(empty($attributes['cancel']))
                    $shitfound = true; # Assume the clausule is bad mojo
                  foreach($attributes['cancel'] as $attr){
                    if(stripos($sentence,$attr) === false){
                      # If a cancel word is found, bad mojo becomes good mojo and weight doesnt count
                      $shitfound = true;
                    }
                  }
                }
              }
              if($shitfound)
                $weight = $weight + $attributes['weight'];
            }
          }
        }
      }
      $result[] = "$catname - $weight \n";
    }
    return $result;

  }


  public static function makeSentences($parts) {
    foreach($parts as $k=>$v){
      $parts[$k] = explode(".", $v); // hopen dat er geen afkortingen zijn
      foreach($parts[$k] as $x=>$y){
        if(strlen($y) < 2)
          unset($parts[$k][$x]);
      }
    }
    return $parts;
  }

  public static function findParts($check) {
    $i = 0;
    $x = 6;
    $check = str_replace("\r", "", $check);
    $searching = true;
    $teststring = "";

    $parts = [];
    while(count($parts) < strlen($check)/1000  && $searching){

      $teststring = "";
      for($i = 0; $i < $x; $i++)
        $teststring .= '\\n';
      $parts = explode($teststring, $check);
      $x = $x - 1;
      if($x == 0)
        $searching = false;
    }
    foreach($parts as $k=>$v){
      if(strlen($v) < 100) // completely abitrary
        unset($parts[$k]);
    }
    return $parts;
  }

}
