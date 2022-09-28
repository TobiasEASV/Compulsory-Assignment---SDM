
using System.Diagnostics;
using Application;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;


namespace TestReview;

public class TestCasesReview
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
    /// Test cases for number of reviews from reviewer					
    /// </summary>
    [Theory]
    [InlineData(1337, 0)]//Reviewer with 0 reviews	
    [InlineData(1, 1)]//Reviewer with 1 review	
    [InlineData(2, 2)]//Reviewer with 2 reviews	
    public void GetNumberOfReviewsFromReviewerTest(int reviewerId, int expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),
            new BEReview(2, 1, 3, DateTime.Now),
            new BEReview(2, 2, 1, DateTime.Now)
        };

        
        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        int result = service.GetNumberOfReviewsFromReviewer(reviewerId);

        // Assert
        Assert.Equal(expected,result);



    }
}