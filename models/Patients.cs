using Microsoft.EntityFrameworkCore;

namespace Auth.Models
{
    [PrimaryKey(nameof(PatientId))]
    public class Patient
    {
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? LoginID { get; set; }
    }
}
