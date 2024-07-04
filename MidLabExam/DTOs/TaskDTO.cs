using MidLabExam.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidLabExam.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
       
        public System.DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string PriorityLevel { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}