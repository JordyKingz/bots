<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Keyword extends Model
{
    public $timestamps = false;

    protected $hidden = array('pivot');

    public function phrasewords(){
        return $this->belongsToMany('App\Models\Phraseword', 'keywords_phrasewords', 'keywords_id', 'phraseword_id');
    }
}
