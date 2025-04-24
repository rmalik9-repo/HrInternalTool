using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HrInternalTool.Domain.Entities
{
    [PrimaryKey("Id")]
    public class EmployeesEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Department { get; set; } = default!;
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; }
    }
}
