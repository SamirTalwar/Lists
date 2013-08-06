package com.noodlesandwich.lists;

import org.junit.Test;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.equalTo;
import static org.hamcrest.Matchers.is;
import static org.hamcrest.Matchers.not;

public final class FunctionalListTest {
    @Test public void
    is_equal_to_another_list_containg_the_same_values() {
        FunctionalList<Integer> one = FunctionalList.of(1, 3, 5, 7, 9);
        FunctionalList<Integer> two = FunctionalList.of(1, 3, 5, 7, 9);
        assertThat(one, is(equalTo(two)));
    }

    @Test public void
    is_not_equal_to_another_list_containg_different_values() {
        FunctionalList<Integer> one = FunctionalList.of(1, 1, 2, 3, 5);
        FunctionalList<Integer> two = FunctionalList.of(1, 3, 5, 7, 9);
        assertThat(one, is(not(equalTo(two))));
    }

    @Test public void
    can_be_mapped_over_a_function() {
        FunctionalList<Integer> numbers = FunctionalList.of(3, 7, 10);
        assertThat(numbers.map(add(6)), is(FunctionalList.of(9, 13, 16)));
    }

    private static Function<Integer, Integer> add(final int amount) {
        return new Function<Integer, Integer>() {
            @Override public Integer apply(Integer input) {
                return input + amount;
            }
        };
    }
}
