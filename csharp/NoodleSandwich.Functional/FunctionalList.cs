using System;

namespace SamirTalwar.Functional
{
    public abstract class FunctionalList<T> where T : IComparable<T>
    {
        public static FunctionalList<T> Nil()
        {
            return new Nil<T>();
        }

        public static FunctionalList<T> Cons(T head, FunctionalList<T> tail)
        {
            return new Cons<T>(head, tail);
        }

        public static FunctionalList<T> Of(params T[] items)
        {
            return FromArray(items, 0, items.Length);
        }

        private static FunctionalList<T> FromArray(T[] items, int start, int end)
        {
            return start == end
                ? Nil()
                    : Cons(items[start], FromArray(items, start + 1, end));
        }

        public abstract bool IsEmpty { get; }

        public abstract T Head { get; }

        public abstract FunctionalList<T> Tail { get; }

        public abstract FunctionalList<TResult> Map<TResult>(Func<T, TResult> mapping) where TResult : IComparable<TResult>;
    }

    sealed class Nil<T> : FunctionalList<T> where T : IComparable<T>
    {
        public override bool IsEmpty
        {
            get { return true; }
        }

        public override T Head
        {
            get { throw new InvalidOperationException(); }
        }

        public override FunctionalList<T> Tail
        {
            get { throw new InvalidOperationException(); }
        }

        public override FunctionalList<TResult> Map<TResult>(Func<T, TResult> mapping)
        {
            return new Nil<TResult>();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, this))
                return true;

            var other = obj as FunctionalList<T>;
            if (object.ReferenceEquals(other, null))
                return false;

            return other.IsEmpty;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

    sealed class Cons<T> : FunctionalList<T> where T : IComparable<T>
    {
        private readonly T _head;
        private readonly FunctionalList<T> _tail;

        public Cons(T head, FunctionalList<T> tail)
        {
            _head = head;
            _tail = tail;
        }

        public override bool IsEmpty
        {
            get { return false; }
        }

        public override T Head
        {
            get { return _head; }
        }

        public override FunctionalList<T> Tail
        {
            get { return _tail; }
        }

        public override FunctionalList<TResult> Map<TResult>(Func<T, TResult> mapping)
        {
            return FunctionalList<TResult>.Cons(mapping(Head), Tail.Map(mapping));
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, this))
                return true;

            var other = obj as FunctionalList<T>;
            if (object.ReferenceEquals(other, null) || other.IsEmpty)
                return false;

            return Head.Equals(other.Head)
                && Tail.Equals(other.Tail);
        }

        public override int GetHashCode()
        {
            return Head.GetHashCode()
                ^ Tail.GetHashCode();
        }
    }
}

