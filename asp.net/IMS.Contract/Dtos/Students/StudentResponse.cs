using IMS.Contract.Common.Paging;

namespace IMS.Contract.Dtos.Students;

public class StudentResponse : PagingResponsse
{
    public List<StudentDto> Students { get; set; }
}
