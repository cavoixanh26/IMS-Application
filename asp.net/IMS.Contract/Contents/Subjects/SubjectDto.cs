using IMS.Domain.Contents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Subjects
{
    public class SubjectDto : BaseDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ManagerId { get; set; }
        public string? ManagerName { get; set; }
    }
}
