public final class Cons<T> extends FunctionalList<T> {
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
}
