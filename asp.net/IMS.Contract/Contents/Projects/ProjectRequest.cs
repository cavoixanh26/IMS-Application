﻿using IMS.Contract.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Contract.Contents.Projects
{
    public class ProjectRequest : PagingRequestBase
    {
        public int? ClassId { get; set; }
    }
}
