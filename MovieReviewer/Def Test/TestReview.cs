using Application;
using Application.Interfaces;
using Domain.Interfaces;
using Moq;
using Domain;

namespace Def_Test;

public class TestReview
{
    /// <summary>
    /// Test Case 1.1
    /// </summary>
    [Fact]
    public void CreateValidServiceTest()
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        // Act
        IService service = new Service(mockRepo.Object);
        

        // Assert
        Assert.NotNull(service);
        Assert.True(service is Service);
    }
    
    /// <summary>
    /// Test case 1.2
    /// </summary>
    [Fact]
    public void CreateInvalidServiceTest()
    {
        // Arrange
        IService service;
        string expected = "Repository is null";
        
        // Act + Assert
        var ex = Assert.Throws<NullReferenceException>(() => service = new Service(null));
        Assert.Equal(expected, ex.Message);
    }
    
    /// <summary>
    /// Test case 2.1 - 2.3
    /// </summary>
    [Theory]
    [InlineData(1337, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public void GetNumberOfReviewsFromReviewerTest(int reviewerId, int expected)
    {
        // Arrange
        int[] intarray = new[]
        {
            5
        };
        
        BEReview[] mockData = new[]
        {
            new BEReview()
        };

        // Act


        // Assert

        
    }
}