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
    public class PerformanceReviewsEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Reviewer { get; set; } = default!;
        public double Score { get; set; } // 1 to 5
        public string Comments { get; set; } = default!;
        public EmployeesEntity Employee { get; set; } = default!;
    }
}
