using Domain;

namespace TestReview;

public class TestData
{
    public static IEnumerable<Object[]> GetMoviesWithHighestNumberOfTopRatesTestData()
    {
        yield return new object[] // Movie has 0 reviews	- test case 7.1
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
        
        yield return new object[] //Movie has 1 review with rating 3	- test case 7.2
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
        
        yield return new object[] //Movie has 2 review with rating 3 and 3	- test case 7.3
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
}