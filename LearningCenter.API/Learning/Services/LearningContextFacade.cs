using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Interfaces.Internal;

namespace LearningCenter.API.Learning.Services;

public class LearningContextFacade : ILearningContextFacade
{
    private readonly TutorialService _tutorialService;
    private readonly CategoryService _categoryService;

    public LearningContextFacade(TutorialService tutorialService, CategoryService categoryService)
    {
        _tutorialService = tutorialService;
        _categoryService = categoryService;
    }

    public async Task<int> TotalTutorials()
    {
        return _tutorialService.ListAsync().Result.Count();
    }

    public Category AddCategory(string name)
    {
        return _categoryService.SaveAsync(new Category { Name = name }).Result.Resource;
    }
}