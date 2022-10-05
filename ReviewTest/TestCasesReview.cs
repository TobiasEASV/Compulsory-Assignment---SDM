using Application;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
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
    
    private bool CompareLists(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count) return false;
        
        for (var i = 0; i < list2.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                return false;
            }
        }
        return true;
    }
    
    private bool ContainList(List<int> list1, List<int> list2)
    {
        foreach (var l2 in list2)
        {
            if (list1.Contains(l2))
            {
                return false;
            }
        }

        return true;
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
    [InlineData(1337, 0)] //Reviewer with 0 reviews	
    [InlineData(1, 1)] //Reviewer with 1 review	
    [InlineData(2, 2)] //Reviewer with 2 reviews	
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
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 5)]
    [InlineData(2, 4.5)]
    [InlineData(3, 3)]
    public void GetAverageRateFromReviewerTest(int reviewerId, double expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),
            new BEReview(1, 1, 5, DateTime.Now),

            new BEReview(2, 1, 6, DateTime.Now),
            new BEReview(2, 1, 3, DateTime.Now),

            new BEReview(3, 2, 4, DateTime.Now),
            new BEReview(3, 2, 2, DateTime.Now)
        };

        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetAverageRateFromReviewer(reviewerId);


        // Assert
        Assert.Equal(expected, result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }

    [Theory]
    [InlineData(1, 5, 2)]
    [InlineData(2, 4, 0)]
    [InlineData(3, 4, 1)]
    public void GetNumberOfRatesByReviewerTest(int reviewerId, int rate, int expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),
            new BEReview(1, 1, 5, DateTime.Now),

            new BEReview(2, 1, 6, DateTime.Now),
            new BEReview(2, 1, 3, DateTime.Now),

            new BEReview(3, 2, 4, DateTime.Now),
            new BEReview(3, 2, 2, DateTime.Now)
        };

        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetNumberOfRatesByReviewer(reviewerId, rate);

        // Assert
        Assert.Equal(expected, result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }

    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    public void GetNumberOfReviewsTest(int movieId, int expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),

            new BEReview(2, 1, 6, DateTime.Now),

            new BEReview(3, 2, 4, DateTime.Now),

            new BEReview(4, 1, 3, DateTime.Now),

            new BEReview(5, 3, 2, DateTime.Now)
        };


        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetNumberOfReviews(movieId);

        // Assert
        Assert.Equal(expected, result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }

    [Theory]
    [InlineData(1, 4.67)]
    [InlineData(2, 4)]
    [InlineData(3, 2)]
    public void GetAverageRateOfMovieTest(int movieId, double expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),

            new BEReview(2, 1, 6, DateTime.Now),

            new BEReview(3, 2, 4, DateTime.Now),

            new BEReview(4, 1, 3, DateTime.Now),

            new BEReview(5, 3, 2, DateTime.Now)
        };


        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetAverageRateOfMovie(movieId);

        // Assert
        Assert.Equal(expected, result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    

    [Theory]
    [InlineData(1, 5, 2)]
    [InlineData(2, 2, 0)]
    [InlineData(3, 2, 1)]
    public void GetNumberOfRatesTest(int movieId, int rate, int expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();
        List<BEReview> fakeRepo = new List<BEReview>
        {
            new BEReview(1, 1, 5, DateTime.Now),

            new BEReview(2, 1, 5, DateTime.Now),
            
            new BEReview(3, 2, 4, DateTime.Now),

            new BEReview(4, 1, 3, DateTime.Now),
            
            new BEReview(5, 3, 2, DateTime.Now)
        };


        mockRepo.Setup(repository => repository.GetAll()).Returns(fakeRepo);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetNumberOfRates(movieId, rate);
        
        // Assert
        Assert.Equal(expected,result);
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
   
        
    

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
       Assert.True(CompareLists(result, expected));
       mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
    
    
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

        for (int i = 0; i < expected.Count; i++)
        {
            _testOutputHelper.WriteLine($"{result[i]} <- Result : {expected[i]} <- Expected");
        }

        // Assert
        Assert.True(CompareLists(result, expected));
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
    [Theory]
    [MemberData(nameof(TestData.GetTopRatedMoviesTestData), MemberType = typeof(TestData))]
    public void GetTopRatedMoviesTest(List<BEReview> data, int[] amount, List<int> expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repository => repository.GetAll()).Returns(data);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetTopRatedMovies(amount.First());
        for (int i = 0; i < expected.Count; i++)
        {
            _testOutputHelper.WriteLine($"{result[i]} <- Result : {expected[i]} <- Expected");
        }
        // Assert
        Assert.True(CompareLists(result, expected));
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
    [Theory]
    [MemberData(nameof(TestData.GetTopMoviesByReviewerTestData), MemberType = typeof(TestData))]
    public void GetTopMoviesByReviewerTest(List<BEReview> data, int[] reviewerId, List<int> expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repository => repository.GetAll()).Returns(data);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetTopMoviesByReviewer(reviewerId.First());
        for (int i = 0; i < expected.Count; i++)
        {
            _testOutputHelper.WriteLine($"{result[i]} <- Result : {expected[i]} <- Expected");
        }
        // Assert
        Assert.True(CompareLists(result, expected));
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);
    }
    
    [Theory]
    [MemberData(nameof(TestData.GetReviewersByMovieTestData), MemberType = typeof(TestData))]
    public void GetReviewersByMovieIdTest(List<BEReview> data, int[] movieId, List<int> expected)
    {
        // Arrange
        Mock<IRepository> mockRepo = new Mock<IRepository>();
        
        mockRepo.Setup(repository => repository.GetAll()).Returns(data);

        IService service = new Service(mockRepo.Object);

        // Act
        var result = service.GetReviewersByMovie(movieId.First());
        for (int i = 0; i < expected.Count; i++)
        {
            _testOutputHelper.WriteLine($"{result[i]} <- Result : {expected[i]} <- Expected");
        }
        // Assert
        Assert.True(CompareLists(result, expected));
        mockRepo.Verify(repository => repository.GetAll(), Times.Once);  
    }
}