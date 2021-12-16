using System.ComponentModel.DataAnnotations;

namespace LeaveManagementV2.Web.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
