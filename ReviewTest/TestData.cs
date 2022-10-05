using System.Numerics;
using Domain;

namespace TestReview;

public class TestData
{
    public static IEnumerable<Object[]> GetMoviesWithHighestNumberOfTopRatesTestData()
    {
        yield return new object[] // Movie has 0 reviews	- test case 8.1
        {
            new List<BEReview>()
            {
                new BEReview(1, 1, 5, DateTime.Now),
                new BEReview(2, 2, 5, DateTime.Now),
                new BEReview(6, 5, 2, DateTime.Now), 
                new BEReview(35, 3, 4, DateTime.Now),
                new BEReview(354, 2, 1, DateTime.Now),
            },
            
            new List<int>() { 1, 2 }
        };
        
        yield return new object[] //Movie has 1 review with rating 3	- test case 8.2
        {
            new List<BEReview>()
            {
                new BEReview(1, 2, 3, DateTime.Now),
                new BEReview(2, 8, 3, DateTime.Now),
                new BEReview(6, 12, 4, DateTime.Now),
                new BEReview(3, 1, 3, DateTime.Now)
            },
            new List<int>() {-1}
        };
        
        yield return new object[] //Movie has 2 review with rating 3 and 3	- test case 8.3
        {
            new List<BEReview>()
            {
                new BEReview(1, 2, 3, DateTime.Now),
                new BEReview(7, 2, 3, DateTime.Now),
                new BEReview(3, 1, 5, DateTime.Now),
                new BEReview(6, 3, 3, DateTime.Now)
            },
            new List<int>() {1}
        };

    }
    
    public static IEnumerable<Object[]> GetMostProductiveReviewersTestData()
    {
        yield return new object[] // Mock data is empty - test case 9.1
        {
            new List<BEReview>()
            {
            },
            
            new List<int>() { -1}
        };
        
        yield return new object[] //Mock data only contains reviewers with 1 review - test case 9.2
        {
            new List<BEReview>()
            {
                new BEReview(1, 2, 3, DateTime.Now),
                new BEReview(2, 8, 3, DateTime.Now),
                new BEReview(3, 12, 4, DateTime.Now)
            },
            new List<int>() {1, 2, 3}
        };
        
        yield return new object[] //Mock data contains one reviewer with two reviews- test case 9.3
        {
            new List<BEReview>()
            {
                new BEReview(1, 2, 5, DateTime.Now),
                new BEReview(2, 2, 5, DateTime.Now),
                new BEReview(2, 1, 5, DateTime.Now)
            },
            new List<int>() {2}
        };

    }
    
    public static IEnumerable<Object[]> GetTopRatedMovieTestData()
    {
        yield return new object[] // Mock data is empty - test case 10.1
        {
            
            new List<BEReview>()
            {
            },
            new BigInteger(1),
            new List<int>() { -1}
        };
        
        yield return new object[] //Mock data only contains reviewers with 1 review - test case 10.2
        {
            new List<BEReview>()
            {
                new BEReview(1, 1, 5, DateTime.Now),
                
            },
            new BigInteger(5),
            new List<int>() {1}
        };
        
        yield return new object[] //Mock data contains one reviewer with two reviews- test case 10.3
        {
            new List<BEReview>()
            {
                new BEReview(1, 1, 5, DateTime.Now),
                new BEReview(2, 2, 5, DateTime.Now),
                new BEReview(2, 4, 4, DateTime.Now),
                new BEReview(2, 3, 5, DateTime.Now),
                new BEReview(2, 7, 2, DateTime.Now)
            },
            new BigInteger(3),
            new List<int>() {1,2,3}
        };

    }
    
    public static IEnumerable<Object[]> GetTopMoviesByReviewerTestData()
    {
        yield return new object[] // Mock Data with 0 reviews from reviewer 3 - test case 11.1
        {
            
            new List<BEReview>()
            {
            },
            new BigInteger(3),
            new List<int>() { -1}
        };
        
        yield return new object[] //Mock data only contains reviwers with 1 review from reviewer 2	- test case 11.2
        {
            new List<BEReview>()
            {
                new BEReview(2, 1, 5, DateTime.Now),
                
            },
            new BigInteger(2),
            new List<int>() {1}
        };
        
        yield return new object[] //Mock data with multiple reviews by reviewer 1 with movie 2 rated highest,
                                  //and 1 and 3 rated equally but 3 was rated first.	- test case 11.3
        {
            new List<BEReview>()
            {
                new BEReview(1, 1, 4, DateTime.Now.AddDays(-5)),
                new BEReview(1, 2, 5, DateTime.Now),
                new BEReview(1, 3, 4, DateTime.Now.AddDays(-2)),
                
            },
            new BigInteger(1),
            new List<int>() {2,3,1}
        };

    }
}