using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Resources;

namespace LearningCenter.API.Learning.Mapping;

public class ModelToResourceProfile : Profile
{
    protected ModelToResourceProfile()
    {
        CreateMap<Category, CategoryResource>();
    }
}