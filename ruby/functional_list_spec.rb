require_relative 'functional_list'

describe "FunctionalList" do
  it "returns true comparing two empty lists" do
    Nil.new.should == Nil.new
  end

  it "returns true comparing two lists with the same values" do
    list_one = FunctionalList.of(1, 2, 3)
    list_two = FunctionalList.of(1, 2, 3)
    list_one.should == list_two
  end
end
