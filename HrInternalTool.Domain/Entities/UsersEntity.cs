using Microsoft.EntityFrameworkCore;

namespace HrInternalTool.Domain.Entities
{
    [PrimaryKey("Id")]
    public class UsersEntity
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = string.Empty;
    }
}
