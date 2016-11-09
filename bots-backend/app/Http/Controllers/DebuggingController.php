<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class DebuggingController extends Controller
{
    public function bolLegalText() {
      return view('bol-legal');
    }
}
