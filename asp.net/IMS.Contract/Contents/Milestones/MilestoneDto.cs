using IMS.Domain.Contents;
using IMS.Domain.Enums;
using Newtonsoft.Json;

namespace IMS.Contract.Contents.Milestones
{
    public class MilestoneDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MileStoneStatus Status { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int? ClassId { get; set; }
        public string? ClassName { get; set; }
    }
}
