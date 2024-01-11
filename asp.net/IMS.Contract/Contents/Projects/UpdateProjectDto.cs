using IMS.Domain.Contents;
using IMS.Domain.Enums;

namespace IMS.Contract.Contents.Projects;

public class UpdateProjectDto
{
    public string Name { get; set; }
    public string? Description { get; set; }  
    public string? AvatarUrl { get; set; }
    public ProjectStatus Status { get; set; }
}
