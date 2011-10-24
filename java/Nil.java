import java.util.NoSuchElementException;

public final class Nil<T> extends FunctionalList<T> {
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
}
