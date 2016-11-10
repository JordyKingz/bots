<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\HtmlString;
use App\Models\LegalText;
use App\Models\Category;
use App\Models\Snippet;

class ScannerController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {

    }

    public function legalTextCheck(Request $request) {
      // retrieve legalText from Url
      $url = $request->url;
      $legalText = LegalText::textByUrl($request->url);
      // NOTE: Wouter, hier uitbreiden met jouw parser
      // en dan de json response aanpassen gebaseerd op parser results
      // + opslaan resultaten in DB
      $analysedLegalText = LegalText::analyse($legalText);
      return response()->json(["legalText" => $analysedLegalText]);
    }

    public function getSnippet(Request $request) {
      // assume we have list => [iets, bla, asd]
      // of categories we want a snippet from
      // make sure user did not already review this
      // snippet. TODO: retrieve settings from $request
      // $categoriesList = ['iets', 'bla', 'asd'];
      // $categories = Category::whereIn('name', $categoriesList)->get();
      // $snippets = Snippet::all()->get();

    }

    public function storeSnippet(Request $request) {
      //
    }


    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        //
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        //
    }
}
