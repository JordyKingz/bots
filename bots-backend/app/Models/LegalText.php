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
    return "Wouters functie";
  }

}
