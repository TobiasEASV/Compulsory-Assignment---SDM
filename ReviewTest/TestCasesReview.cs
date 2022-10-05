
using System.Diagnostics;
using System.Numerics;
using Application;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Xunit.Abstractions;


namespace TestReview;

public class TestCasesReview
{

    private readonly ITestOutputHelper _testOutputHelper;

    public TestCasesReview(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

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
    [InlineData(1337, 0)]//Reviewer with 0 reviews - test case 2.1
    [InlineData(1, 1)]//Reviewer with 1 review - test case 2.2
    [InlineData(2, 2)]//Reviewer with 2 reviews	- test case 2.3
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
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
    
    
    
    /// <summary>
    /// Test case 3.1 - 3.3
    /// Test cases for number of reviews from reviewer					
    /// </summary>
    [Theory]
    [InlineData(0, -1)]//Reviewer with 0 reviews - test case 3.1
    [InlineData(1, 5.0)]//Reviewer with 1 review - test case 3.2
    [InlineData(2, 4.5)]//Reviewer with 2 reviews	- test case 3.3
    public void GetAverageRateFromReviewerTest(int reviewerId, double expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),
            new BEReview(2, 1, 4, DateTime.Now),
            new BEReview(2, 2, 5, DateTime.Now)
        };

        
        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        double result = service.GetAverageRateFromReviewer(reviewerId);

        // Assert
        Assert.Equal(expected,result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }

    /// <summary>
    /// Test case 4.1-4.3
    /// Test cases for number of rates by reviewer
    /// </summary>
    [Theory]
    [InlineData(3,3, 0)]//Reviewer with 0 reviews - test case 4.1
    [InlineData(1,5,1)]//Reviewer with 2 reviews with one movie rated 5	- test case 4.2
    [InlineData(2,4,2)]//Reviewer with 2 reviews, that gave 4 and 4	 - test case 4.3
    public void GetNumberOfRatesByReviewerTest(int reviewerId, int rate, int expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),
            new BEReview(1, 2, 3, DateTime.Now),
            new BEReview(2, 1, 4, DateTime.Now),
            new BEReview(2, 2, 4, DateTime.Now)
        };

        
        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        int result = service.GetNumberOfRatesByReviewer(reviewerId,rate);

        // Assert
        Assert.Equal(expected,result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
        
    }
    
    /// <summary>
    /// Test case 5.1-5.3
    /// Test cases for number of reviews on movie					
    /// </summary>
    [Theory]
    [InlineData(3,0)]//Movie has 0 reviews	- test case 5.1
    [InlineData(1,1)]//Movie has 1 review	- test case 5.2
    [InlineData(2,2)]//Movie has 2 review	- test case 5.3
    public void GetNumberOfReviewsOnMovieTest(int movieId, int expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),
            new BEReview(1, 2, 3, DateTime.Now),
            new BEReview(2, 2, 4, DateTime.Now)
        };

        
        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetNumberOfReviews(movieId);

        // Assert
        Assert.Equal(expected,result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
        
    }

    /// <summary>
    /// Test case 6.1-6.3
    /// Test cases for number of reviews on movie					
    /// </summary>
    [Theory]
    [InlineData(3,-1)]//Movie has 0 reviews	- test case 6.1
    [InlineData(1,3)]//Movie has 1 review with rating 3	- test case 6.2
    [InlineData(2,4)]//Movie has 2 review with rating 3 and 5	- test case 6.3
    public void GetAverageRateOfMovieTest(int movieId, int expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 2, 5, DateTime.Now),
            new BEReview(2, 2, 3, DateTime.Now),
            new BEReview(2, 1, 3, DateTime.Now)
        };

        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetAverageRateOfMovie(movieId);

        // Assert
        Assert.Equal(expected,result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
        
    }
    
    /// <summary>
    /// Test case 7.1-7.4
    /// Test cases for number of reviews on movie					
    /// </summary>
    [Theory]
    [InlineData(3, 5, 0)]//Movie has 0 reviews	- test case 7.1
    [InlineData(1, 3, 1)]//Movie has 1 review with rating 3	- test case 7.2
    [InlineData(2, 3, 2)]//Movie has 2 review with rating 3 and 3	- test case 7.3
    [InlineData(2, 5, 0)]//Movie has 3 review with rating 3, 3 and 4	- test case 7.4
    public void GetNumberOfRatesTest(int movieId, int rate, int expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 2, 3, DateTime.Now),
            new BEReview(2, 2, 3, DateTime.Now),
            new BEReview(2, 2, 4, DateTime.Now),
            new BEReview(2, 1, 3, DateTime.Now)
        };

        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetNumberOfRates(movieId, rate);

        // Assert
        Assert.Equal(expected,result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
        
    }

    
    /// <summary>
    /// Test case 8.1-8.3
    /// Test cases for number of reviews on movie					
    /// </summary>
    [Theory]
    [MemberData(nameof(TestData.GetMoviesWithHighestNumberOfTopRatesTestData), MemberType = typeof(TestData))]
    public void GetMoviesWithHighestNumberOfTopRatesTest(List<BEReview> data, List<int> expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repository => repository.GetAll()).Returns(data);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetMoviesWithHighestNumberOfTopRates();

        // Assert
        Assert.True(expected.All(result.Contains) && result.All(expected.Contains));
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
    /// <summary>
    /// Test case 9.1-9.3
    /// Test cases for number of reviews on movie					
    /// </summary>
    [Theory]
    [MemberData(nameof(TestData.GetMostProductiveReviewersTestData), MemberType = typeof(TestData))]
    public void GetMostProductiveReviewersTest(List<BEReview> data, List<int> expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repository => repository.GetAll()).Returns(data);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetMostProductiveReviewers();

        
        // Assert
        Assert.True(expected.All(result.Contains) && result.All(expected.Contains));
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
    /// <summary>
    /// Test case 10.1-10.3
    /// Test cases for number of reviews on movie					
    /// </summary>
    [Theory]
    [MemberData(nameof(TestData.GetTopRatedMovieTestData), MemberType = typeof(TestData))]
    public void GetTopRatedMoviesTest(List<BEReview> data, BigInteger topN ,List<int> expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repository => repository.GetAll()).Returns(data);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetTopRatedMovies((int)topN);

        
        // Assert
        Assert.True(expected.All(result.Contains) && result.All(expected.Contains));
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
    /// <summary>
    /// Test case 11.1-11.3
    /// Test cases for number of reviews on movie					
    /// </summary>
    [Theory]
    [MemberData(nameof(TestData.GetTopMoviesByReviewerTestData), MemberType = typeof(TestData))]
    public void GetTopMoviesByReviewerTest(List<BEReview> data, BigInteger reviewer ,List<int> expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repository => repository.GetAll()).Returns(data);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetTopMoviesByReviewer((int)reviewer);

        
        // Assert
        Assert.True(expected.All(result.Contains) && result.All(expected.Contains));
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
}