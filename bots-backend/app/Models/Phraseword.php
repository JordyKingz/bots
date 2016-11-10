<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Phraseword extends Model
{
    public $timestamps = false;

    protected $hidden = array('pivot');

    public function keywords(){
        return $this->belongsToMany('App\Models\Keyword', 'keywords_phrasewords', 'keywords_id', 'phraseword_id');
    }
}
