using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var categories = await _categoryService.ListAsync();
        return categories;
    }
    
    
}