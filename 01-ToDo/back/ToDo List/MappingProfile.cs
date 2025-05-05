using ToDo_List.Models;
using ToDo_List.Models.dto;
using AutoMapper;

namespace ToDo_List
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDTO>();
            CreateMap<TaskItemDTO, TaskItem>();
            CreateMap<TaskCreateDTO, TaskItem>();
            CreateMap<TaskUpdateDTO, TaskItem>();
            CreateMap<TaskItem, TaskUpdateDTO>();
        }
        }
}
