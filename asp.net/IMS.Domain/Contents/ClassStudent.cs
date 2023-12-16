using IMS.Domain.Abstracts;
using IMS.Domain.Systems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Contents
{
    public class ClassStudent : Auditable
    {
        public Guid StudentId { get; set; }
        public int ClassId { get; set; }


        [ForeignKey(nameof(ClassId))]
        public virtual Class? Class { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual AppUser? Students{ get; set; }
    }
}
