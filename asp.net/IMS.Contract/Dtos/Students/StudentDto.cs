namespace IMS.Contract.Dtos.Students;

public class StudentDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDay { get; set; }
    public string? Avatar { get; set; }
}
