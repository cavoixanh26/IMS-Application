namespace IMS.Contract.Dtos.Members;

public class MemberInProjectRequest
{
    public int ProjectId { get; set; }
    public List<MemberDto> Members { get; set; }

}

public class MemberDto
{
    public Guid MemberId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public bool IsTeamleader { get; set; }
}
