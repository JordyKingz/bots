<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Category;

class DebuggingController extends Controller
{
    public function bolLegalText() {
      return Category::get()->count();
      return view('bol-legal');
    }
}
