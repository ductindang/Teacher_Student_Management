using BLL.DTOs.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public EAccountStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }
    }
}
