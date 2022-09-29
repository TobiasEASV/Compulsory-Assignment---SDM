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
        var movieList = new List<int>();
        foreach (var review in _repo.GetAll().FindAll(review => review.Grade == 5))
        {
            if (!movieList.Contains(review.Movie))
            {
                movieList.Add(review.Movie);
            }
        }
        return movieList;
    }

    public List<int> GetMostProductiveReviewers()
    {
        var productiveReviewerList = new List<int>();
        var dictList = new Dictionary<int, int>();
        var setList = new List<int>();
        var allReview = _repo.GetAll();
        
        var orderReviews = allReview.OrderBy(review => review.Reviewer);
        foreach (var review in allReview) { if (!setList.Contains(review.Reviewer))setList.Add(review.Reviewer);}
        
        
        foreach (var reviewer in setList)
        {
            var c = 0;
            foreach (var orderReview in orderReviews)
            {
                if (orderReview.Reviewer == reviewer)
                {
                    c++;
                }
            }
            dictList.Add(reviewer,c);
        }
        
        var sortedDict = from entry in dictList orderby entry.Value ascending select entry;
        
        
        foreach (var keyValuePair in sortedDict)
        {
            productiveReviewerList.Add(keyValuePair.Key);
        }
        return productiveReviewerList;

    }

    public List<int> GetTopRatedMovies(int amount)
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopMoviesByReviewer(int reviewerId)
    {
        throw new NotImplementedException();
    }

    public List<int> GetReviewersByMovie(int movieId)
    {
        throw new NotImplementedException();
    }
}