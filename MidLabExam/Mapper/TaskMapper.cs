using MidLabExam.DTOs;
using MidLabExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidLabExam.Mapper
{
    public class TaskMapper : IMapper<Task, TaskDTO>
    {
        public Task Map(TaskDTO entity)
        {
            return new Task
            {
                Id = entity.Id,
                Title = entity.Title,
                DueDate = entity.DueDate,
                Status = entity.Status,
                PriorityLevel = entity.PriorityLevel,
                CreatedAt = (DateTime)entity.CreatedAt,
                UpdatedAt = DateTime.Now,
                CategoryId = entity.CategoryId,
                Category = entity.Category != null ? new Category { Id = entity.CategoryId, Name = entity.Category.Name } : null
            };
        }

        public TaskDTO Map(Task entity)
        {
            return new TaskDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                DueDate = entity.DueDate,
                Status = entity.Status,
                PriorityLevel = entity.PriorityLevel,
                CreatedAt = (DateTime)entity.CreatedAt,
                UpdatedAt = (DateTime)entity.UpdatedAt,
                CategoryId = entity.CategoryId,
                Category = entity.Category

            };
        }

        public List<TaskDTO> Map(List<Task> entities)
        {
            var tasks = new List<TaskDTO>();
            foreach (var entity in entities)
            {
                tasks.Add(Map(entity));
            }
            return tasks;
        }
      }
    }