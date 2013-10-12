class FunctionalList:
    @staticmethod
    def of(*items):
        return FunctionalList._fromArray(items, 0, len(items))

    @staticmethod
    def _fromArray(items, start, end):
        return Nil() if start == end else Cons(items[start], FunctionalList._fromArray(items, start + 1, end))

class Nil(FunctionalList):
    def isEmpty(self):
        return True

    def map(self, mapping):
        return self

    def __eq__(self, other):
        return other.isEmpty()

class Cons(FunctionalList):
    def __init__(self, head, tail):
        self._head = head
        self._tail = tail

    def isEmpty(self):
        return False

    @property
    def head(self):
        return self._head

    @property
    def tail(self):
        return self._tail

    def map(self, mapping):
        return Cons(mapping(self.head), self.tail.map(mapping))

    def __eq__(self, other):
        return not other.isEmpty() \
            and self.head == other.head \
            and self.tail == other.tail
