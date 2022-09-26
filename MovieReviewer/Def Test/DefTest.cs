namespace Def_Test;

public class DefTest
{
    [Fact]
    public void Test1()
    {
    }

    [Theory]
    [InlineData(2)]
    public void Test2(int id)
    {
    }
}