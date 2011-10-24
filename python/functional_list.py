class FunctionalList:
    @staticmethod
    def of(*items):
        def fromArray(items, start, end):
            return Nil() if start == end else Cons(items[start], fromArray(items, start + 1, end))

        return fromArray(items, 0, len(items))

    def map(self, mapping):
        return Nil() if self.isEmpty() else Cons(mapping(self.head), self.tail.map(mapping))

class Nil(FunctionalList):
    def isEmpty(self):
        return True

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
