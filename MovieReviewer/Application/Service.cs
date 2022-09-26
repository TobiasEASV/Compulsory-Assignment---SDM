using Domain.Interfaces;

namespace Application;

public class Service : IService
{
    public int GetNumberOfReviewsFromReviewer(int reviewerId)
    {
        throw new NotImplementedException();
    }

    public double GetAverageRateFromReviewer(int reviewerId)
    {
        throw new NotImplementedException();
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