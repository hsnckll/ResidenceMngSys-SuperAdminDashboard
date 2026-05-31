using System.ComponentModel.DataAnnotations.Schema;

namespace SuperAdminDashboard.Models
{
    public class UserRoles
    {
        [Column("İd")]
        public int Id { get; set; }
        [Column("User_İd")]
        public int User_Id { get; set; }
        [Column("Roles_İd")]
        public int Roles_Id { get; set; }

    }
}
