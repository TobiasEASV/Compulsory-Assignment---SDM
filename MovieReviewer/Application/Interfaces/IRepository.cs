using System.Collections.Generic;
using Domain;

namespace Application.Interfaces;

public interface IRepository
{
    //Returns a list containing all the review in the repository.
    List<Review> GetAll();
}