using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Projects
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ClassId {  get; set; }

    }
}
