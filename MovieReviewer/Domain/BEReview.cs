namespace Domain;

public class Review
{
    public int Reviewer { get; set; }
    
    public int Movie { get; set; }
    
    public int Grade { get; set; }

    public DateTime ReviewDate { get; set; }

    public Review(int reviewer, int movie, int grade, DateTime reviewDate)
    {
        Reviewer = reviewer;
        Movie = movie;
        Grade = grade;
        ReviewDate = reviewDate;
    }
}