require_relative '../lib/functional_list'

describe 'a functional list' do
  it 'is equal to another list containing the same values' do
    one = FunctionalList.of(1, 3, 5, 7, 9)
    two = FunctionalList.of(1, 3, 5, 7, 9)
    one.should == two
  end

  it 'is not equal to another list containg different values' do
    one = FunctionalList.of(1, 1, 2, 3, 5)
    two = FunctionalList.of(1, 3, 5, 7, 9)
    one.should_not == two
  end

  it 'can be mapped over a function' do
    numbers = FunctionalList.of(3, 7, 10)
    mapped = numbers.map { |x| x + 6 }
    mapped.should == FunctionalList.of(9, 13, 16)
  end

  def add amount
    lambda do |input|
      input + amount
    end
  end
end
