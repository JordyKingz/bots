<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Category;

class DebuggingController extends Controller
{
  public function bolLegalText() {
    return view('bol-legal'); // is actually apple legal
  }

  public function valitosGreen() {
    return view('legal.valitos-green');
  }

  public function valitosOrange() {
    return view('legal.valitos-orange');
  }

  public function valitosRed() {
    return view('legal.valitos-red');
  }
}
