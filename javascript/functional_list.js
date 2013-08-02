var FunctionalList = (function() {
    function FunctionalList() { }

    FunctionalList.nil = function() {
        return new Nil();
    };

    FunctionalList.cons = function(head, tail) {
        return new Cons(head, tail);
    };

    FunctionalList.of = function() {
        var items = Array.prototype.slice.call(arguments);
        return fromArray(items, 0, items.length);
    };

    function fromArray(items, start, finish) {
        return start === finish ? FunctionalList.nil() : FunctionalList.cons(items[start], fromArray(items, start + 1, finish));
    }


    function Nil() { }

    Nil.prototype = new FunctionalList();

    Nil.prototype.isEmpty = function() {
        return true;
    };

    Nil.prototype.map = function(mapping) {
        return this;
    };


    function Cons(head, tail) {
        this.head = function() {
            return head;
        };

        this.tail = function() {
            return tail;
        };
    }

    Cons.prototype = new FunctionalList();

    Cons.prototype.isEmpty = function() {
        return false;
    };

    Cons.prototype.map = function(mapping) {
        return FunctionalList.cons(mapping(this.head()), this.tail().map(mapping));
    };


    return FunctionalList;
}());
