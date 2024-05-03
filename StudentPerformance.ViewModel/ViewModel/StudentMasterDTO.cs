using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.ViewModel.ViewModel
{
    public class StudentMasterDTO
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTimeOffset StudentJoinDate { get; set; }
        public int Class { get; set; }
        public decimal TotalMark { get; set; }
        public decimal TotalMarkObtained { get; set; }
        public decimal TotalPercentage { get; set; }


    }
}
