<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use GuzzleHttp\Client;
use DOMDocument;
use App\Models\Category;

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
    // $string = strtolower($string);
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
          if (strpos(strtolower($domElement->nodeValue), $title) === 0) {
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

  public static function formatData($data) {
    // $categories = Category::get()->whereIn('name', $data);
    // return $data;

    $catBlocks = [];
    foreach ($data as $catName => $catData) {
      $cat = Category::where('name', $catName)->get()->first();
      $paragraphs = [];
      foreach ($catData['paragraphs'] as $i => $paragraphText) {

        $paragraphs[] = [
          "text" => $paragraphText,
          "weight" => 123,
          "problems" => [ 0, 2 ],
        ];
      }
      $catBlocks[] = [
        "name" => $cat['name'],
        "problems" => $catData['problems'],
        "paragraphs" => $paragraphs
      ];
    }

    // main arr
    $arr = [
      "status" => "success",
      "categoriesTotal" => Category::get()->count(),
      "data" => $catBlocks,
    ];
    return $arr;
  }

  public static function formatCSData($data) {
    // $categories = Category::get()->whereIn('name', $data);
    // return $data;

    $catBlocks = [];
    foreach ($data as $catName => $catData) {
      $cat = Category::where('name', $catName)->get()->first();
      $catBlocks[] = [
        "name" => $cat['name'],
        "problems" => $catData['problems'],
        "paragraphs" => $catData['paragraphs']
      ];
    }

    // main arr
    return $catBlocks;
  }

  public static function analyse($legalText) {
    $parts = self::findParts($legalText);
    // Split parts into sentences
    // $sentences = self::makeSentences($parts);

    // In de zinnen kijken naar woorden
    $words = self::getAnalysisWords();

    $results = self::performForeachHell($words, $parts);
    return $results;
  }

  // analysing
  public static function getAnalysisWords() {
    $cats = Category::get()->all();

    $words = [];
    foreach ($cats as $i => $cat) {
      $catProblems = [];
      foreach ($cat->problems as $probKey => $problem) {
        $phrasewords = [];
        foreach ($problem->keywords as $keywordKey => $keyword) {
          $phrasewords[] = $keyword->phrasewords;
        }
        $catProblems[$problem->tag] = [
          "message" => $problem->message,
          "weight" => $problem->weight,
          "keywords" => $problem->keywords,
        ];
      }
      $words[] = [
        $cat['name'] => $catProblems,
      ];
    }
    return $words;

    $words = [
      // dit is categories.name
      "privacy" => [  // Praat over privacy
        // dit is category->problems (collection, loop)
        "persoonlijke gegevens" => [ // Context = Persoonlijke gegevens
            // is keyword
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
  }

  public static function performForeachHell($words, $sentences) {
    $result = []; # Category list of list
    foreach($words as $catindex => $cat) {
      $weight = 0;
      # loop through each category
      foreach($cat as $catname => $problems){
        # loop through each problem array
        foreach($problems as $problemTag => $problemParent){
          $w = $problemParent['weight'];
          foreach($sentences as $paragraph){
            # Loop through all the paragraphs
            # No problem found so far right?
            foreach($problemParent['keywords'] as $problem){
              $keyword = $problem['word'];
              $and = $problem['combination'] == "\u0001" ? true : false; # If true, phrase words should be and-ed: else or-ed
              $found = false;
              if(stripos($paragraph, $keyword) !== false){
                # found but means nothing yet
                if(count($problem['phrasewords']) == 0){
                  $found = true; # word is found and no phrasewords so yeah rip this shit
                }
                else{
                  if($and || !$and){ # Everything must be present haha joke always and
                    $found = true;
                    foreach($problem['phrasewords'] as $word){
                      if(stripos($paragraph,$word['word']) === false){
                        $found = false;
                      }
                    }
                  }
                  else{ # One must be present unless there are no phrasewords so revers and
                    $found = false;
                    foreach($problem['phrasewords'] as $word){
                      if(stripos($paragraph,$word['word']) !== false){
                        $found = true;
                      }

                    }
                  }
                }
              }
              if($found){
                #Oeeiiiii
                if(!isset($result[$catname]))
                  $result[$catname] = [];
                if(!isset($result[$catname]['problems'])){
                  $result[$catname]['problems'] = [];
                  $result[$catname]['paragraphs'] = [];
                }
                $problemArray = [
                  'tag'=>$problemTag,
                  'msg'=>$problemParent['message'],
                  'weight'=>$w
                ];
                array_push($result[$catname]['problems'],$problemArray);
                $paragraph = str_replace('\\n','',$paragraph);
                if(!in_array($paragraph, $result[$catname]['paragraphs']))
                  array_push($result[$catname]['paragraphs'],$paragraph);
              }
            }
          }
        }
      }
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

  public static function findParts($text) { // DIT WERKT NIET MEE FUCKEN
    $found = false;
    $searching = true;
    $text = preg_split('/[\n]/',$text);
    while($searching){
      $searching = false;
      foreach($text as $index => $line){
        if(strlen(trim($line)) == 0){
          unset($text[$index]);
        }
      }
      foreach($text as $index => $line){
        $line = preg_replace('/[\n\r]/','',$line);
        if(substr(trim($line),-1) != '.'){ // Werken? :D
          if(isset($text[$index+1])){
            unset($text[$index]);
            $text[$index+1] = $line . $text[$index+1];
            $searching = true;
            break;
          }
        }
      }
    }
    return $text;
}

}
