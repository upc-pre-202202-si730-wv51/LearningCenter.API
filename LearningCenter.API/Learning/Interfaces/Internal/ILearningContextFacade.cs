using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Interfaces.Internal;

public interface ILearningContextFacade
{
    Task<int> TotalTutorials();
    Category AddCategory(string name);
}