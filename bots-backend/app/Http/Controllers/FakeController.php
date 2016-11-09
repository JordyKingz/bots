<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class FakeController extends Controller
{
  public function legalTextCheck(Request $request) {
    $data = [
      "status" => "success",
      "data" => [
        [
          "name" => "Privacy",
          "problems" => [
            [
              "tag" => "p1",
              "msg" => "Problem 1",
              "weight" => 20,
            ],
            [
              "tag" => "p2",
              "msg" => "Problem 2",
              "weight" => 70,
            ],
            [
              "tag" => "p3",
              "msg" => "Problem 3",
              "weight" => 55,
            ],
          ],
          "paragraphs" => [
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 54,
            ],
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 23,
            ],
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 77,
            ],
          ]
        ], // end privacy
        [
          "name" => "Aansprakelijkheid",
          "problems" => [
            [
              "tag" => "p1",
              "msg" => "Problem 1",
              "weight" => 23,
            ],
            [
              "tag" => "p2",
              "msg" => "Problem 2",
              "weight" => 55,
            ],
          ],
          "paragraphs" => [
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 23,
            ],
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 55,
            ],
          ]
        ], // Aansprakelijkheid
        [
          "name" => "Prijsverhogingen",
          "problems" => [
            [
              "tag" => "p1",
              "msg" => "Problem 1",
              "weight" => 23,
            ],
            [
              "tag" => "p2",
              "msg" => "Problem 2",
              "weight" => 23,
            ],
            [
              "tag" => "p3",
              "msg" => "Problem 3",
              "weight" => 55,
            ],
            [
              "tag" => "p4",
              "msg" => "Problem 4",
              "weight" => 100,
            ],
          ],
          "paragraphs" => [
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 55,
            ],
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 100,
            ],
          ]
        ], // Prijsverhogingen
      ],
    ];

    return response()->json($data);
  }
}
