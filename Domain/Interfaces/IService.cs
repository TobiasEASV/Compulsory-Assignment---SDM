namespace Domain.Interfaces;

public interface IService
{
    /// <summary>
    /// Get the number of reviews the reviewer has made.
    /// </summary>
    /// <param name="reviewer">Id from a reviewer</param>
    /// <returns>Return the number for reviews. </returns>
    int GetNumberOfReviewsFromReviewer(int reviewer);
    
    /// <summary>
    /// Get the total average rate from Reviewer
    /// </summary>
    /// <param name="reviewer">Id from a reviewer</param>
    /// <returns>Return the average rate number </returns>
    double GetAverageRateFromReviewer(int reviewer);
    
    /// <summary>
    /// Get the number for times a reviewer has given a certain rate..
    /// </summary>
    /// <param name="reviewer">Id from a reviewer</param>
    /// <param name="rate">The specific rate to fine</param>
    /// <returns>Return the number for times the specific rate was given</returns>
    int GetNumberOfRatesByReviewer(int reviewer, int rate);
    
    /// <summary>
    /// Get how many reviewer have rated this movie
    /// </summary>
    /// <param name="movie">Id from a movie</param>
    /// <returns>Return number of reviewers who has rated the movie</returns>
    int GetNumberOfReviews(int movie);
    
    /// <summary>
    /// Get the average for this movie
    /// </summary>
    /// <param name="movie">Id from a movie</param>
    /// <returns>Return the average</returns>
    double GetAverageRateOfMovie(int movie);
    
    /// <summary>
    /// Get how many times this movie has got a certain rate.
    /// </summary>
    /// <param name="movie">Id from a movie</param>
    /// <param name="rate">Certain rate</param>
    /// <returns>Return number of times the movie got the certain rate</returns>
    int GetNumberOfRates(int movie, int rate);
    
    /// <summary>
    /// Get the TopRate movie(s) with the most rate 5
    /// </summary>
    /// <returns>Return a list of movie(s) with the most rate 5</returns>
    List<int> GetMoviesWithHighestNumberOfTopRates();
    
    /// <summary>
    /// Get the reviewer(s) who has made the most reviews
    /// </summary>
    /// <returns>return a list with reviewer who has made the most reviews.
    /// The first in the list is the ones with the most reviews </returns>
    List<int> GetMostProductiveReviewers();
    
    /// <summary>
    /// Get a list the top rate movies, 
    /// </summary>
    /// <param name="amount">The number of movies, that is in the return list </param>
    /// <returns>Return a list of a certain length (amount), where the one with the best rate is first (decreasing order)</returns>
    List<int> GetTopRatedMovies(int amount);
    
    
    /// <summary>
    /// Get the top rate movies, that a reviewer has review.
    /// </summary>
    /// <param name="reviewer">Id from a reviewer</param>
    /// <returns>Return a list for top rate movies in decreasing order (orderBy Rate first, and Date secondly)</returns>
    List<int> GetTopMoviesByReviewer(int reviewer);
    
    /// <summary>
    /// Get the reviewers who has review the movie
    /// </summary>
    /// <param name="movie">Id from a movie</param>
    /// <returns>Return a list of reviewers decreasing order (orderBy Rate first, and Date secondly)</returns>
    List<int> GetReviewersByMovie(int movie);
}