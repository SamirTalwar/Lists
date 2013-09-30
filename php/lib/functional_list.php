<?php

abstract class FunctionalList {
    public static function nil() {
        return new Nil();
    }

    public static function cons($head, $tail) {
        return new Cons($head, $tail);
    }

    public static function of() {
        $args = func_get_args();
        return static::_from_array($args, 0, count($args));
    }

    public static function from_array($items)
    {
        return self::_from_array($items, 0, count($items));
    }

    private static function _from_array($items, $start, $end) {
        if ($start === $end) {
            return static::nil();
        }
        return static::cons($items[$start], static::_from_array($items, $start + 1, $end));
    }

    public abstract function isEmpty();
    public abstract function head();
    public abstract function tail();

    public abstract function map($f);
}

class Nil extends FunctionalList {
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

class Cons extends FunctionalList {
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
        return FunctionalList::cons($f($this->head), $this->tail->map($f));
    }
}

?>
