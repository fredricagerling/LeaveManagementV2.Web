﻿using LeaveManagementV2.Web.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementV2.Web.Models
{
    public class LeaveRequestCreateViewModel : IValidatableObject
    {
        public SelectList? LeaveTypes { get; set; }

        [Display(Name = "Request")]
        public int LeaveTypeId { get; set; }

        [Display(Name = "Comment")]
        public string? RequestComment { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartDate > EndDate)
            {
                yield return new ValidationResult("The start date cannot be after end date.", new[] { nameof(StartDate), nameof(EndDate) });
            }
            if(RequestComment?.Length > 250)
            {
                yield return new ValidationResult("The comment is way too long yo", new[] { nameof(RequestComment)});

            }
        }
    }
}
