public abstract class FunctionalList<T> {
    public static <T> FunctionalList<T> nil() {
        return new Nil<T>();
    }

    public static <T> FunctionalList<T> cons(final T head, final FunctionalList<T> tail) {
        return new Cons<T>(head, tail);
    }

    public static <T> FunctionalList<T> of(final T... items) {
        return FunctionalList.of(items, 0, items.length);
    }

    private static <T> FunctionalList<T> of(final T[] items, final int start, final int end) {
        return start == end
                   ? FunctionalList.<T>nil()
                   : cons(items[start], of(items, start + 1, end));
    }

    public abstract boolean isEmpty();

    public abstract T head();

    public abstract FunctionalList<T> tail();

    public <U> FunctionalList<U> map(final Function<T, U> mapping) {
        return isEmpty()
                   ? FunctionalList.<U>nil()
                   : cons(mapping.apply(head()), tail().map(mapping));
    }
}
