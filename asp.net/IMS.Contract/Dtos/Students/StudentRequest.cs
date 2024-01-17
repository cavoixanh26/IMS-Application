using IMS.Contract.Common.Paging;

namespace IMS.Contract.Dtos.Students;

public class StudentRequest : PagingRequestBase
{
    // have a group yet?
    public bool? ExcludedHasAGroup { get; set; }
}
