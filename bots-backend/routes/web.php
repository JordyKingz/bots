<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| This file is where you may define all of the routes that are handled
| by your application. Just tell Laravel the URIs it should respond
| to using a Closure or controller method. Build something great!
|
*/

// @TODO: add landing-page front-end
// Route::group(['name' => 'landing-page'], function() {
  Route::get('/', function() {
    return "home";
  });
// });

Route::get('haha', 'TestingController@bla');


Route::group(['prefix' => 'api', 'middleware' => 'cors'], function () {
  Route::group(['prefix' => 'v1'], function () {

    Route::resource('test-connection', 'TestingController');

    // @TODO: fix legal-text-check with Wouters analyser and parse results into
    // json response
    // + store results into the db (somehow)
    Route::post('legal-text-check', 'ScannerController@legalTextCheck');
    Route::post('csharp-legal-text-check', 'FakeController@csLegalTextCheck');
    // Route::post('legal-text-check', 'FakeController@legalTextCheck');

    Route::post('get-snippet', 'ScannerController@getSnippet');
    Route::post('receive-snippet', 'ScannerController@storeSnippet');

    Route::get('generate-user-guid', 'UserController@generateGuiUserId');

  });
});


Route::group(['prefix' => 'legal'], function () {
  Route::get('apple', 'DebuggingController@bolLegalText');
  Route::get('valitos-green', 'DebuggingController@valitosGreen');
  Route::get('valitos-orange', 'DebuggingController@valitosOrange');
  Route::get('valitos-red', 'DebuggingController@valitosRed');
});
