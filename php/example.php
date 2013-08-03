<?php

require_once "functional_list.php";

$list = Cons::from_array(array(1, 2, 3, 4));

$result = $list->map(function ($x) {
    return $x * 2;
});

var_dump($result);
