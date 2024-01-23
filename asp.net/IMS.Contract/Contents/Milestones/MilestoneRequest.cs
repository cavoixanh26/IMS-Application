using IMS.Contract.Common.Paging;
using IMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Milestones
{
    public class MilestoneRequest : PagingRequestBase
    {
        public int? ProjectId { get; set; }
        public int? ClassId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public MileStoneStatus? Status { get; set; }
        public bool? IsActive { get; set; }
    }
}
