class FunctionalList:
    @staticmethod
    def of(*items):
        return _fromArray(items, 0, len(items))

    def _fromArray(items, start, end):
        return Nil() if start == end else Cons(items[start], _fromArray(items, start + 1, end))

class Nil(FunctionalList):
    def isEmpty(self):
        return True

    def map(self, mapping):
        return self

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
