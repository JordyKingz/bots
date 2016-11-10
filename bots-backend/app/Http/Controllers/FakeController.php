<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class FakeController extends Controller
{
  public function legalTextCheck(Request $request) {
    $data = [
      "status" => "success",
      "categoriesTotal" => 12,
      "data" => [
        [
          "name" => "Privacy",
          "problems" => [
            [
              "tag" => "p1",
              "msg" => "Problem 1",
              "weight" => 20,
              "problems" => [ 0, 2 ],
            ],
            [
              "tag" => "p2",
              "msg" => "Problem 2",
              "weight" => 70,
              "problems" => [ 0, 2 ],
            ],
            [
              "tag" => "p3",
              "msg" => "Problem 3",
              "weight" => 55,
              "problems" => [ 0, 2 ],
            ],
          ],
          "paragraphs" => [
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 54,
              "problems" => [ 0, 2 ],
            ],
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 23,
              "problems" => [ 0, 2 ],
            ],
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 77,
              "problems" => [ 0, 2 ],
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
              "problems" => [ 0, 2 ],
            ],
            [
              "tag" => "p2",
              "msg" => "Problem 2",
              "weight" => 55,
              "problems" => [ 0, 2 ],
            ],
          ],
          "paragraphs" => [
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 23,
              "problems" => [ 0, 2 ],
            ],
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 55,
              "problems" => [ 0, 2 ],
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
              "problems" => [ 0, 2 ],
            ],
            [
              "tag" => "p2",
              "msg" => "Problem 2",
              "weight" => 23,
              "problems" => [ 0, 2 ],
            ],
            [
              "tag" => "p3",
              "msg" => "Problem 3",
              "weight" => 55,
              "problems" => [ 0, 2 ],
            ],
            [
              "tag" => "p4",
              "msg" => "Problem 4",
              "weight" => 100,
              "problems" => [ 0, 2 ],
            ],
          ],
          "paragraphs" => [
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 55,
              "problems" => [ 0, 2 ],
            ],
            [
              "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
              "weight" => 100,
              "problems" => [ 0, 2 ],
            ],
          ]
        ], // Prijsverhogingen
      ],
    ];

    return response()->json($data);
  }

  public function csLegalTextCheck(Request $request) {
    $data = [
      [
        "name" => "Privacy",
        "problems" => [
          [
            "tag" => "p1",
            "msg" => "Problem 1",
            "weight" => 20,
            "problems" => [ 0, 2 ],
          ],
          [
            "tag" => "p2",
            "msg" => "Problem 2",
            "weight" => 70,
            "problems" => [ 0, 2 ],
          ],
          [
            "tag" => "p3",
            "msg" => "Problem 3",
            "weight" => 55,
            "problems" => [ 0, 2 ],
          ],
        ],
        "paragraphs" => [
          [
            "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
            "weight" => 54,
            "problems" => [ 0, 2 ],
          ],
          [
            "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
            "weight" => 23,
            "problems" => [ 0, 2 ],
          ],
          [
            "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
            "weight" => 77,
            "problems" => [ 0, 2 ],
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
            "problems" => [ 0, 2 ],
          ],
          [
            "tag" => "p2",
            "msg" => "Problem 2",
            "weight" => 55,
            "problems" => [ 0, 2 ],
          ],
        ],
        "paragraphs" => [
          [
            "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
            "weight" => 23,
            "problems" => [ 0, 2 ],
          ],
          [
            "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
            "weight" => 55,
            "problems" => [ 0, 2 ],
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
            "problems" => [ 0, 2 ],
          ],
          [
            "tag" => "p2",
            "msg" => "Problem 2",
            "weight" => 23,
            "problems" => [ 0, 2 ],
          ],
          [
            "tag" => "p3",
            "msg" => "Problem 3",
            "weight" => 55,
            "problems" => [ 0, 2 ],
          ],
          [
            "tag" => "p4",
            "msg" => "Problem 4",
            "weight" => 100,
            "problems" => [ 0, 2 ],
          ],
        ],
        "paragraphs" => [
          [
            "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
            "weight" => 55,
            "problems" => [ 0, 2 ],
          ],
          [
            "text" => "lorum ipsum dolor somit, dit type ik met veel geniet.",
            "weight" => 100,
            "problems" => [ 0, 2 ],
          ],
        ]
      ], // Prijsverhogingen
    ];

    return response()->json($data);
  }
}
