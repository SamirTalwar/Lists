using System;
using NUnit.Framework;

namespace SamirTalwar.Functional
{
    [TestFixture]
    public class FunctionalListTest
    {
        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionIfAccessingHeadOnNil()
        {
            var head = FunctionalList<int>.Nil().Head;
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionIfAccessingTailOnNil()
        {
            var head = FunctionalList<int>.Nil().Tail;
        }

        [Test]
        public void ShouldBeEqualToAnotherListIfBothListsAreNil()
        {
            var one = FunctionalList<int>.Nil();
            Assert.That(one.Equals(one), Is.True);
        }

        [Test]
        public void ShouldBeEqualToAnotherListContainingTheSameValues()
        {
            var one = FunctionalList<int>.Of(1, 3, 5, 7, 9);
            var two = FunctionalList<int>.Of(1, 3, 5, 7, 9);
            Assert.That(one.Equals(two), Is.True, "should be equal if both lists contain same values");
            Assert.That(one.GetHashCode(), Is.EqualTo(two.GetHashCode()), "hash code should be equal for lists with same values");
        }

        [Test]
        public void ShouldNotBeEqualToAnObjectOfDifferentType()
        {
            var one = FunctionalList<int>.Of(1, 3, 5, 7, 9);
            Assert.That(one.Equals(new object()), Is.False, "cons should not be equal to an object of a different type");
            Assert.That(FunctionalList<int>.Nil().Equals(new object()), Is.False, "nil should not be equal to an object of a different type");
        }

        [Test]
        public void ShouldBeEqualToSelf()
        {
            var one = FunctionalList<int>.Of(1, 3, 5, 7, 9);
            Assert.That(one.Equals(one), Is.True, "cons should be equal to self");
        }

        [Test]
        public void ShouldBeNotEqualToAnotherListContainingDifferentValues()
        {
            var one = FunctionalList<int>.Of(1, 1, 2, 3, 5);
            var two = FunctionalList<int>.Of(1, 3, 5, 7, 9);
            Assert.That(one.Equals(two), Is.False, "cons should not be equal to a list with different elements");
            Assert.That(one.GetHashCode(), Is.Not.EqualTo(two.GetHashCode()), "hash code should not be equal for lists with different values");
        }

        [Test]
        public void ShouldBeNotEqualToAnotherListWhichIsNil()
        {
            var one = FunctionalList<int>.Of(1, 1, 2, 3, 5);
            var two = FunctionalList<int>.Nil();
            Assert.That(one.Equals(two), Is.False, "cons should not be equal to empty list");
            Assert.That(two.Equals(one), Is.False, "nil should not be equal to non empty list");
            Assert.That(one.GetHashCode(), Is.Not.EqualTo(two.GetHashCode()), "hash code should not be equal for lists with different values");
        }

        [Test]
        public void ShouldBeMappableOverAFunction()
        {
            var numbers = FunctionalList<int>.Of(3, 7, 10);
            Assert.That(numbers.Map(AddSixAndStringify), Is.EqualTo(FunctionalList<string>.Of("9", "13", "16")));
        }

        private string AddSixAndStringify(int input)
        {
            return (input + 6).ToString();
        }
    }
}
