<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Problem extends Model
{
    public $timestamps = false;

    public function keywords(){
        return $this->hasMany('App\Models\Keyword');
    }

    public function category(){
        return $this->belongsTo('App\Models\Category');
    }
}
