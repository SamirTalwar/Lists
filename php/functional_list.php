<?php

function nil() {
    return new Nil();
}

function cons($head, $tail) {
    return new Cons($head, $tail);
}

function list_of() {
    $args = func_get_args();
    return _from_array($args, 0, count($args));
}

function _from_array($items, $start, $end) {
    if ($start === $end) {
        return nil();
    }
    return cons($items[$start], _from_array($items, $start + 1, $end));
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
