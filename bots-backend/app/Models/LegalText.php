<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use GuzzleHttp\Client;

class LegalText extends Model
{
  private $content = "";

  public function __construct($html) {

  }

  public static function textByUrl($url) {
    $client = new Client();
    $res = $client->request('GET', $url);
    $html = $res->getBody()->getContents();

    $text = self::stripTextFromHtml($html);

    return $text;
  }

  public static function stripTextFromHtml($html) {
    return $html;
  }
  
}
