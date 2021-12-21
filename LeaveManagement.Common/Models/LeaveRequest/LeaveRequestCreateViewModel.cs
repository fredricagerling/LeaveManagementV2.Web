using LeaveManagement.Common.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
        [DisplayFormat(DataFormatString = DateFormat.DateOnly)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = DateFormat.DateOnly)]
        public DateTime? EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The start date cannot be after end date.", new[] { nameof(StartDate), nameof(EndDate) });
            }
            if (RequestComment?.Length > 250)
            {
                yield return new ValidationResult("The comment is way too long yo", new[] { nameof(RequestComment) });

            }
        }
    }
}
