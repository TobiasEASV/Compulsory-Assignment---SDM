using Application.Interfaces;
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
        var count = 0;
        foreach (var x in _repo.GetAll())
        {
            if (x.Reviewer == reviewerId)
            {
                count++;
            }
            
        }

        return count;
    }

    public double GetAverageRateFromReviewer(int reviewerId)
    {
        var testSource = _repo.GetAll().FindAll(e => e.Reviewer == reviewerId);
        
        if (testSource.Count == 0)
            return -1;

        return testSource.Average(review => review.Grade);
    }

    public int GetNumberOfRatesByReviewer(int reviewerId, int rate)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfReviews(int movieId)
    {
        throw new NotImplementedException();
    }

    public double GetAverageRateOfMovie(int movieId)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfRates(int movieId, int rate)
    {
        throw new NotImplementedException();
    }

    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        throw new NotImplementedException();
    }

    public List<int> GetMostProductiveReviewers()
    {
        throw new NotImplementedException();
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