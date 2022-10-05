using Domain;

namespace TestReview;

public class TestData
{

    public static IEnumerable<object[]> GetMoviesWithHighestNumberOfTopRatesTestData()
    {

        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(1, 1, 5, DateTime.Now),
                new BEReview(2, 2, 5, DateTime.Now),
                new BEReview(3, 2, 4, DateTime.Now),
                new BEReview(4, 1, 3, DateTime.Now),
                new BEReview(5, 5, 2, DateTime.Now),
            },
            new List<int>() { 1, 2 }

        };

        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(1, 1, 2, DateTime.Now),
                new BEReview(2, 1, 1, DateTime.Now),
                new BEReview(3, 2, 4, DateTime.Now),
                new BEReview(4, 1, 3, DateTime.Now),
                new BEReview(5, 5, 2, DateTime.Now),
            },
            new List<int>() { -1 }

        };

        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(1, 1, 5, DateTime.Now),
                new BEReview(2, 12, 4, DateTime.Now),
                new BEReview(8, 61, 2, DateTime.Now),
                new BEReview(4, 11, 2, DateTime.Now),
                new BEReview(5, 50, 1, DateTime.Now),
            },
            new List<int>() { 1 }

        };
    }

    public static IEnumerable<object[]> GetMostProductiveReviewersTestData()
    {
        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(-1, 4, 3, DateTime.Now),
                new BEReview(-1, 6, 3, DateTime.Now),
                new BEReview(0, 7, 3, DateTime.Now),
                new BEReview(4, 9, 3, DateTime.Now),
            },
            new List<int>(){-1,0,4}
        };
        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(4, 4, 3, DateTime.Now),
                new BEReview(4, 6, 2, DateTime.Now),
                new BEReview(4, 9, 4, DateTime.Now),
                new BEReview(4, 9, 1, DateTime.Now),
                new BEReview(3, 2, 5, DateTime.Now),
                new BEReview(3, 4, 3, DateTime.Now),
                new BEReview(2, 67, 5, DateTime.Now),
                new BEReview(2, 4, 1, DateTime.Now),
                new BEReview(2, 89, 2, DateTime.Now),
            },
            new List<int>(){4,2,3}
        };

        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(4, 4, 3, DateTime.Now),
                new BEReview(4, 6, 3, DateTime.Now),
                new BEReview(3, 9, 3, DateTime.Now),
                new BEReview(3, 7, 3, DateTime.Now),
            },
            new List<int>(){4,3}
        };
    }
    
    public static IEnumerable<object[]> GetTopRatedMoviesTestData()
    {
        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(2, 4, 5, DateTime.Now),
                new BEReview(3, 6, 4, DateTime.Now),
                new BEReview(0, 7, 3, DateTime.Now),
                new BEReview(4, 9, 1, DateTime.Now),
            },
            new int[1]{3},
            new List<int>(){4,6,7}
        };
        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(4, 4, 2, DateTime.Now),
                new BEReview(4, 6, 5, DateTime.Now),
                new BEReview(4, 9, 4, DateTime.Now),
                new BEReview(3, 7, 2, DateTime.Now),
                new BEReview(3, 2, 5, DateTime.Now),
                new BEReview(3, 85, 1, DateTime.Now),
                new BEReview(3, 34, 3, DateTime.Now),
                new BEReview(3, 10, 3, DateTime.Now.Subtract(TimeSpan.FromHours(2)))
            },
            new int[1]{5},
            new List<int>(){6,2,9,10,34}
        };

        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(4, 4, 2, DateTime.Now),
                new BEReview(4, 6, 5, DateTime.Now),
                new BEReview(3, 9, 4, DateTime.Now),
                new BEReview(3, 7, 2, DateTime.Now),
            },
            new int[1]{2},
            new List<int>(){6,9}
        };

    }
    
    public static IEnumerable<object[]> GetTopMoviesByReviewerTestData()
    {
        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(2, 5, 3, DateTime.Now),// 
                new BEReview(3, 2, 3, DateTime.Now),// <- data
                new BEReview(1, 6, 5, DateTime.Now),//
                new BEReview(4, 7, 3, DateTime.Now),//
            },
            new int[] {1}, // <- Reviewer id
            new List<int>(){6} // <- expected result form data
        };
        
        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(3, 1, 5, DateTime.Now),// 
                new BEReview(3, 2, 5, DateTime.Now),// <- data
                new BEReview(1, 3, 3, DateTime.Now),//
                new BEReview(4, 3, 3, DateTime.Now),//
            },
            new int[] {3}, // <- Reviewer id
            new List<int>(){2,1} // <- expected result form data
        };

        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(10, 10, 5, DateTime.Now),// 
                new BEReview(10, 3, 5, DateTime.Now),// <- data
                new BEReview(10, 5, 5, DateTime.Now),//
                new BEReview(10, 2, 5, DateTime.Now),//
            },
            new int[] {10}, // <- Reviewer id
            new List<int>(){10,5,3,2} // <- expected result form data
        };

    }
    
    public static IEnumerable<object[]> GetReviewersByMovieTestData()
    {
        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(2, 1, 3, DateTime.Now),// 
                new BEReview(3, 1, 3, DateTime.Now),// <- data
                new BEReview(1, 1, 3, DateTime.Now),//
                new BEReview(4, 1, 3, DateTime.Now),//
            },
            new int[1] {1}, // <- Movie id
            new List<int>(){4,3,2,1} // <- expected result form data
        };
        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(2, 1, 3, DateTime.Now),// 
                new BEReview(3, 1, 3, DateTime.Now),// <- data
                new BEReview(1, 3, 3, DateTime.Now),//
                new BEReview(4, 3, 3, DateTime.Now),//
            },
            new int[1] {3}, // <- Movie id
            new List<int>(){4,1} // <- expected result form data
        };

        yield return new object[]
        {
            new List<BEReview>()
            {
                new BEReview(2, 1, 3, DateTime.Now),// 
                new BEReview(3, 2, 3, DateTime.Now),// <- data
                new BEReview(1, 2, 3, DateTime.Now),//
                new BEReview(4, 3, 3, DateTime.Now),//
            },
            new int[1] {10}, // <- Movie id
            new List<int>(){} // <- expected result form data
        };

    }
}