using LearningCenter.API.Analytics.Domain.Service;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Interfaces.Internal;

namespace LearningCenter.API.Analytics.Service;

public class LearningAnalyticsService : ILearningAnalyticsService
{

    private readonly ILearningContextFacade _learningContextFacade;

    public LearningAnalyticsService(ILearningContextFacade learningContextFacade)
    {
        _learningContextFacade = learningContextFacade;
    }


    public Category AddCategory(string name)
    {
        return _learningContextFacade.AddCategory(name);

    }
}