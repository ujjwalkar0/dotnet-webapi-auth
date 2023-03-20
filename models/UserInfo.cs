using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{

    [PrimaryKey(nameof(UserId))]
    public class UserInfo
    {
        public int UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}