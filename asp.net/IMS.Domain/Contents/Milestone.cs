using IMS.Domain.Abstracts;
using IMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IMS.Domain.Contents
{
    public class Milestone : Auditable
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public MileStoneStatus Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [JsonIgnore]
        public virtual Project? Project { get; set; }
        public int? ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        [JsonIgnore]
        public virtual Class? Class { get; set; }
        [JsonIgnore]
        public virtual ICollection<Issue>? Issues { get; set; } 

    }
}
