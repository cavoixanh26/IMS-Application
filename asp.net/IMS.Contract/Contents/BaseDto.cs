namespace IMS.Contract.Contents;

public class BaseDto
{
    public int Id { get; set; }
    public DateTime? CreationTime { get; set; }
    public string? CreatedBy { get; set; }
    public bool? IsActive { get; set; }
}
