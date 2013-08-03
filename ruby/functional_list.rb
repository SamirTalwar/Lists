module FunctionalList
  def FunctionalList.nil
    Nil.new
  end

  def FunctionalList.cons(head, tail)
    Cons.new head, tail
  end

  def FunctionalList.of(*items)
    fromArray items, 0, items.length
  end

private

  def FunctionalList.fromArray(items, start, finish)
    start == finish ? FunctionalList.nil : cons(items[start], fromArray(items, start + 1, finish))
  end
end

class Nil
  include FunctionalList

  def isEmpty
    true
  end

  def ==(other)
    other.is_a? Nil
  end

  def map(&mapping)
    self
  end
end

class Cons
  include FunctionalList

  attr_reader :head, :tail

  def initialize(head, tail)
    @head = head
    @tail = tail
  end

  def isEmpty
    false
  end

  def ==(other)
    head == other.head && tail == other.tail
  end

  def map(&mapping)
    FunctionalList.cons(mapping.call(head), tail.map(&mapping))
  end
end
