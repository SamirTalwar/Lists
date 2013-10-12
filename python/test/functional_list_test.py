from functional_list import FunctionalList
import unittest

class FunctionalListTest(unittest.TestCase):
    def test_is_equal_to_another_list_containg_the_same_values(self):
        one = FunctionalList.of(1, 3, 5, 7, 9)
        two = FunctionalList.of(1, 3, 5, 7, 9)
        self.assertEqual(two, one)

    def test_is_not_equal_to_another_list_containg_different_values(self):
        one = FunctionalList.of(1, 1, 2, 3, 5)
        two = FunctionalList.of(1, 3, 5, 7, 9)
        self.assertNotEqual(two, one)

    def test_can_be_mapped_over_a_function(self):
        numbers = FunctionalList.of(3, 7, 10)
        mapped = numbers.map(FunctionalListTest.add(6))
        self.assertEqual(FunctionalList.of(9, 13, 16), mapped)

    @staticmethod
    def add(amount):
        return lambda input: amount + input
