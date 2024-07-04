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

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Due Date is required")]
        
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(50, ErrorMessage = "Status cannot be longer than 50 characters")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Priority Level is required")]
        [StringLength(50, ErrorMessage = "Priority Level cannot be longer than 50 characters")]
        public string PriorityLevel { get; set; }

       
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}