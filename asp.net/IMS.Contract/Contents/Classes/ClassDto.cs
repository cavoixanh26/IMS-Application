using IMS.Domain.Contents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Classes
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }
        public string? TeacherName { get; set; }
        public string? Description { get; set; }
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public int SettingId { get; set; }
        public string? Semester { get; set; }
        public int NumberOfStudent { get; set; }
    }
}
