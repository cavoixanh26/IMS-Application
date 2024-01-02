using IMS.Contract.Common.Paging;

namespace IMS.Contract.Systems.Users;

public class UserRequest : PagingRequestBase
{
    public string? RoleName { get; set; }
}
