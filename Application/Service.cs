using Application.Interfaces;
using Domain;
using Domain.Interfaces;

namespace Application;

public class Service : IService
{
    private IRepository _repo;
    public Service(IRepository repo)
    {
        if (repo is null)
            throw new NullReferenceException("Repository is null");
        _repo = repo;
    }

    public int GetNumberOfReviewsFromReviewer(int reviewerId)
    {
        return _repo.GetAll().FindAll(review => review.Reviewer == reviewerId).Count;
    }

    public double GetAverageRateFromReviewer(int reviewerId)
    {
        return _repo.GetAll().FindAll(review => review.Reviewer == reviewerId).Average(review => review.Grade);
    }

    public int GetNumberOfRatesByReviewer(int reviewerId, int rate)
    {
        return _repo.GetAll().FindAll(review => review.Reviewer == reviewerId && rate == review.Grade).Count;
    }

    public int GetNumberOfReviews(int movieId)
    {
        return _repo.GetAll().FindAll(review => review.Movie == movieId).Count;
    }

    public double GetAverageRateOfMovie(int movieId)
    {
        return Math.Round(_repo.GetAll().FindAll(review => review.Movie == movieId).Average(review => review.Grade), 2);
    }

    public int GetNumberOfRates(int movieId, int rate)
    {
        return _repo.GetAll().FindAll(review => review.Movie == movieId && review.Grade == rate).Count;
    }

    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        var movies = _repo.GetAll().FindAll(review => review.Grade == 5);
        
        if (movies.Count == 0) return new List<int>() { -1 };
            
        var returnList = new List<int>();
        foreach (var review in movies)
        {
            if (!returnList.Contains(review.Movie))
            {
                returnList.Add(review.Movie);
            }
        }
        return returnList;
    }

    public List<int> GetMostProductiveReviewers()
    {
        var productiveReviewerList = new List<int>();
        var dictList = new Dictionary<int, int>();
        var setList = new List<int>();
        var allReview = _repo.GetAll();
        
        var orderReviews = allReview.OrderBy(review => review.Reviewer);
        foreach (var review in allReview) { if (!setList.Contains(review.Reviewer))setList.Add(review.Reviewer);}
        
        foreach (var setReview in setList)
        {
            var count = 0;
            foreach (var orderReview in orderReviews)
            {
                if (orderReview.Reviewer == setReview)
                {
                    count++;
                }
            }
            dictList.Add(setReview,count);
        }
        
        var sortedDict = from entry in dictList orderby entry.Value descending select entry;
        
        
        foreach (var keyValuePair in sortedDict)
        {
            productiveReviewerList.Add(keyValuePair.Key);
        }
        return productiveReviewerList;
    }

    public List<int> GetTopRatedMovies(int amount)
    {
        var sortReview = _repo.GetAll().OrderByDescending(review => review.Grade).ThenBy(review => review.ReviewDate);
        var listOfRate = new List<int>();

        foreach (var review in sortReview.Take(amount))
        {
            listOfRate.Add(review.Movie);
        }
        return listOfRate;
    }

    public List<int> GetTopMoviesByReviewer(int reviewerId)
    {
        var sortReview = _repo.GetAll().Where(review => review.Reviewer == reviewerId && review.Grade == 5)
            .OrderByDescending(review => review.Movie);
        
        var listOfRate = new List<int>();

        foreach (var review in sortReview)
        {
            listOfRate.Add(review.Movie);
        }
        return listOfRate;
    }

    public List<int> GetReviewersByMovie(int movieId)
    {
        var sortReview = _repo.GetAll().Where(review => review.Movie == movieId)
            .OrderByDescending(review => review.Reviewer);
        
        var listOfRate = new List<int>();

        foreach (var review in sortReview)
        {
            listOfRate.Add(review.Reviewer);
        }
        return listOfRate;
    }
}