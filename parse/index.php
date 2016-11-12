<?php
//file_get_contents('eula/one.txt'); // Bol.com
function makesentences($parts) {
  foreach($parts as $k=>$v){
    $parts[$k] = explode(".", $v); // hopen dat er geen afkortingen zijn
    foreach($parts[$k] as $x=>$y){
      if(strlen($y) < 2)
        unset($parts[$k][$x]);
    }
  }
  return $parts;
}
function findparts($check){
  $i = 0;
  $x = 6;
  $check = str_replace("\r", "", $check);
  $searching = true;
  $teststring = "";

  $parts = [];
  while(count($parts) < strlen($check)/1000  && $searching){

    $teststring = "";
    for($i = 0; $i < $x; $i++)
      $teststring .= '\\n';
    $parts = explode($teststring, $check);
    $x = $x - 1;
    if($x == 0)
      $searching = false;
  }
  foreach($parts as $k=>$v){
    if(strlen($v) < 100) // completely abitrary
      unset($parts[$k]);
  }
  return $parts;
}


$ls = scandir('eula');
$newlist = [];
foreach($ls as $file){
  if(!($file == '.' || $file == '..'))
    array_push($newlist, strtolower(file_get_contents('eula/' . $file)));
}
$ls = $newlist;
$check = $ls[1];
$parts = findparts($check);


// Split parts into sentences
$sentences = makesentences($parts);
// In de zinnen kijken naar woorden
$woorden = [
  "privacy" => [  // Praat over privacy
    "persoonlijke gegevens" => [ // Context = Persoonlijke gegevens
        "verspreiding" => [ // Woord wat iets zegt over context
          "cancel" => ["geen"], // Cancel voor dit woord - kijk in zin
          "weight" => 50
        ],
        "verkopen"
    ],
    "ontknoping" => [
      "verloting" => [
        "cancel" => [],
        "weight" => 30
      ]
    ]
  ]
];

foreach($woorden as $catname => $cat) {
  $weight = 0;
  # loop through each category
  foreach($cat as $context => $subwords){
    # loop through each keyword
    foreach($subwords as $subword => $attributes){
      # Loop through each subword in the sentences, mark as shady if found
      foreach($sentences as $part){
        # Loop through all the parts
        foreach($part as $sentence){
          # Loop through every part as a sentence... look for the subwords and keywords, mark as category
          $shitfound = false;
          if(stripos($sentence,$context) !== false){
            # Found keyword in sentence
            if(stripos($sentence,$subword) !== false){
              # Also found subword that makes shit bad
              if(empty($attributes['cancel']))
                $shitfound = true; # Assume the clausule is bad mojo
              foreach($attributes['cancel'] as $attr){
                if(stripos($sentence,$attr) === false){
                  # If a cancel word is found, bad mojo becomes good mojo and weight doesnt count
                  $shitfound = true;
                }
              }
            }
          }
          if($shitfound)
            $weight = $weight + $attributes['weight'];
        }
      }
    }
  }
  echo "$catname - $weight \n";
}

?>
