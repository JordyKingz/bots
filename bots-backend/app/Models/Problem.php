<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Problem extends Model
{
    public $timestamps = false;
    public function keywords(){
        return $this->belongsToMany('App\Model\Keyword');
    }
}
