<?php

require 'lib/functional_list.php';

class FunctionalListTest extends PHPUnit_Framework_TestCase {
    function test_is_equal_to_another_list_containg_the_same_values() {
        $one = FunctionalList::of(1, 3, 5, 7, 9);
        $two = FunctionalList::of(1, 3, 5, 7, 9);
        $this->assertEquals($two, $one);
    }

    function test_is_not_equal_to_another_list_containg_different_values() {
        $one = FunctionalList::of(1, 1, 2, 3, 5);
        $two = FunctionalList::of(1, 3, 5, 7, 9);
        $this->assertNotEquals($two, $one);
    }

    function test_can_be_mapped_over_a_function() {
        $numbers = FunctionalList::of(3, 7, 10);
        $mapped = $numbers->map($this->add(6));
        $this->assertEquals(FunctionalList::of(9, 13, 16), $mapped);
    }

    function add($amount) {
        return function($input) use ($amount) {
            return $input + $amount;
        };
    }
}

?>
