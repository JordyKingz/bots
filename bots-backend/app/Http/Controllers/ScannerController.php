<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\HtmlString;
use App\Models\LegalText;
use App\Models\Category;
use App\Models\Snippet;
use App\Models\Appuser;
use App\Models\Review;

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
      if ($url == '') {
        return response()->json(["status" => "fail"]);
      }
      if(stripos($url, "peterschriever.com") !== false) {
        throw new \Exception("Cannot call this domain.");
      }
      $legalText = LegalText::textByUrl($request->url);
      if (empty($legalText)) {
        return response()->json(["status" => "fail"]);
      }

      // NOTE: Wouter, hier uitbreiden met jouw parser
      // en dan de json response aanpassen gebaseerd op parser results
      // + opslaan resultaten in DB
      $analysisResults = LegalText::analyse($legalText);
      // return response()->json($analysisResults);
      $formattedData = LegalText::formatData($analysisResults);
      return response()->json($formattedData);
    }

    public function legalTextCheckByPaste(Request $request) {
      // retrieve legalText from Url
      // $url = $request->url;
      // if(stripos($url, "peterschriever.com") !== false) {
      //   throw new \Exception("Cannot call this domain.");
      // }
      // $legalText = LegalText::textByUrl($request->url);
      $legalText = $request->text;

      if (empty($legalText)) {
        return response()->json(["status" => "fail"]);
      }

      // NOTE: Wouter, hier uitbreiden met jouw parser
      // en dan de json response aanpassen gebaseerd op parser results
      // + opslaan resultaten in DB
      $analysisResults = LegalText::analyse($legalText);
      // return response()->json($analysisResults);
      $formattedData = LegalText::formatCSData($analysisResults);
      return response()->json($formattedData);
    }

    public function csLegalTextCheck(Request $request) {
      // retrieve legalText from Url
      $url = $request->url;
      if ($url == '') {
        return response()->json(["status" => "fail"]);
      }
      if(stripos($url, "peterschriever.com") !== false) {
        throw new \Exception("Cannot call this domain.");
      }
      $legalText = LegalText::textByUrl($request->url);

      // NOTE: Wouter, hier uitbreiden met jouw parser
      // en dan de json response aanpassen gebaseerd op parser results
      // + opslaan resultaten in DB
      $analysisResults = LegalText::analyse($legalText);
      // return response()->json($analysisResults);
      $formattedData = LegalText::formatCSData($analysisResults);
      return response()->json($formattedData);
    }

    public function getSnippet(Request $request) {
      $data = [
        "snippetId" => 1,
        "category" => "Privacy",
        "text" => "duurzame gegevensdrager: elk hulpmiddel waaronder ook begrepen e-mail dat de consument of ondernemer in staat stelt om informatie die aan hem persoonlijk is gericht, op te slaan op een manier die toekomstige raadpleging of gebruik gedurende een periode die is afgestemd op het doel waarvoor de informatie is bestemd, en die ongewijzigde reproductie van de opgeslagen informatie mogelijk maakt",
        "weight" => 64,
        "guid" => $request->guid == "null" ? 1 : $request->guid // 1: generate snippet
      ];
      return response()->json($data);
      // if ($request->guid) {
      //   $appUser = AppUser::where('id', $request->guid)->find(1)['id'];
      // } else {
      //   $appUser = AppUser::create()->id;
      // }
      //
      // return response()->json($appUser);
    }

    public function storeSnippet(Request $request) {
      // send response of review
      $review = Review::create([
        "guid" => $request->guid,
        "snippetid" => $request->snippetId,
        "score" => $request->review,
        "comment" => $request->comment
      ]);

      $data = [
        "status" => "success",
        "snippetId" => $request->snippetId ? $request->snippetId : 1,
        "guid" => $request->guid ? $request->guid : 1,
        "receivedReview" => $request->review ? $request->review : "review not found in post",
        "reviewComment" => $request->reviewComment ? $request->reviewComment : "comment was not added.",
        "reviewId" => $review,
      ];
      return response()->json($data);
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
