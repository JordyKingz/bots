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

Route::get('/', function () {
    return view('welcome');
});


Route::group(['prefix' => 'api', 'middleware' => 'cors'], function () {
  Route::group(['prefix' => 'v1'], function () {

    Route::resource('test-connection', 'TestingController');

    Route::post('legal-text-check', 'ScannerController@legalTextCheck');

  });
});
