<?php

function nil() {
    return new Nil();
}

function cons($head, $tail) {
    return new Cons($head, $tail);
}

function list_of() {
    return _list_of(func_get_args());
}

function _list_of($args) {
    if (count($args) === 0) {
        return nil();
    }
    return cons($args[0], _list_of(array_slice($args, 1)));
}

interface FunctionalList {
    public function isEmpty();
    public function head();
    public function tail();

    public function map($f);
}

class Nil {
    public function isEmpty() {
        return true;
    }

    public function head() {
        throw new Exception('Nil does not have a head');
    }

    public function tail() {
        throw new Exception('Nil does not have a tail');
    }

    public function map($f) {
        return $this;
    }
}

class Cons {
    public function __construct($head, $tail) {
        $this->head = $head;
        $this->tail = $tail;
    }

    public function isEmpty() {
        return false;
    }

    public function head() {
        return $this->head;
    }

    public function tail() {
        return $this->tail;
    }

    public function map($f) {
        return cons($f($this->head), $this->tail->map($f));
    }
}

?>
