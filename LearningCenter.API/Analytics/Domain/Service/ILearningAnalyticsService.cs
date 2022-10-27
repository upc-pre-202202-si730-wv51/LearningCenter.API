using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Analytics.Domain.Service;

public interface ILearningAnalyticsService
{
    Category AddCategory(string name);
}