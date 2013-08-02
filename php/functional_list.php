<?php

function nil() {
    return new Nil();
}

function cons($head, $tail) {
    return new Cons($head, $tail);
}

abstract class FunctionalList {
    public static function of() {
        $args = func_get_args();
        return self::_from_array($args, 0, count($args));
    }

    private static function _from_array($items, $start, $end) {
        if ($start === $end) {
            return nil();
        }
        return cons($items[$start], self::_from_array($items, $start + 1, $end));
    }

    public abstract function isEmpty();
    public abstract function head();
    public abstract function tail();

    public abstract function map($f);
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
