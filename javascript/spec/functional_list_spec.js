var FunctionalList = require('../lib/functional_list');

describe('a functional list', function() {
    it('is equal to another list containing the same values', function() {
        var one = FunctionalList.of(1, 3, 5, 7, 9);
        var two = FunctionalList.of(1, 3, 5, 7, 9);
        expect(one).toBeTheSameListAs(two);
    });

    it('is not equal to another list containg different values', function() {
        var one = FunctionalList.of(1, 1, 2, 3, 5);
        var two = FunctionalList.of(1, 3, 5, 7, 9);
        expect(one).not.toBeTheSameListAs(two);
    });

    it('can be mapped over a function', function() {
        var numbers = FunctionalList.of(3, 7, 10);
        expect(numbers.map(add(6))).toBeTheSameListAs(FunctionalList.of(9, 13, 16));
    });

    function add(amount) {
        return function(input) {
            return input + amount;
        }
    }

    beforeEach(function() {
        this.addMatchers({
            toBeTheSameListAs: function(expected) {
                return expected.equals(this.actual);
            }
        });
    });
});
