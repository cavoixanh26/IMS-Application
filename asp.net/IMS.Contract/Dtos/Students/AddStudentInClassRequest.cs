namespace IMS.Contract.Dtos.Students;

public class AddStudentInClassRequest
{
    public List<Guid> StudentIds { get; set; }
    public int ClassId { get; set; }
}
