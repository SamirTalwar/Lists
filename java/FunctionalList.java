import java.util.NoSuchElementException;

public abstract class FunctionalList<T> {
    public static <T> FunctionalList<T> nil() {
        return new Nil<T>();
    }

    public static <T> FunctionalList<T> cons(final T head, final FunctionalList<T> tail) {
        return new Cons<T>(head, tail);
    }

    public static <T> FunctionalList<T> of(final T... items) {
        return fromArray(items, 0, items.length);
    }

    private static <T> FunctionalList<T> fromArray(final T[] items, final int start, final int end) {
        return start == end
                   ? FunctionalList.<T>nil()
                   : cons(items[start], fromArray(items, start + 1, end));
    }

    public abstract boolean isEmpty();

    public abstract T head();

    public abstract FunctionalList<T> tail();

    public abstract <U> FunctionalList<U> map(Function<T, U> mapping);

    public static final class Nil<T> extends FunctionalList<T> {
        @Override
        public boolean isEmpty() {
            return true;
        }

        @Override
        public T head() {
            throw new NoSuchElementException();
        }

        @Override
        public FunctionalList<T> tail() {
            throw new NoSuchElementException();
        }

        @Override
        public <U> FunctionalList<U> map(Function<T, U> mapping) {
            return this;
        }
    }

    public static final class Cons<T> extends FunctionalList<T> {
        private final T head;
        private final FunctionalList<T> tail;

        public Cons(final T head, final FunctionalList<T> tail) {
            this.head = head;
            this.tail = tail;
        }

        @Override
        public boolean isEmpty() {
            return false;
        }

        @Override
        public T head() {
            return head;
        }

        @Override
        public FunctionalList<T> tail() {
            return tail;
        }

        @Override
        public <U> FunctionalList<U> map(Function<T, U> mapping) {
            return cons(mapping.apply(head()), tail().map(mapping));
        }
    }
}
