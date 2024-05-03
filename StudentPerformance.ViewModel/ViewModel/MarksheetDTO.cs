using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.ViewModel.ViewModel
{
    public class MarksheetDTO
    {
        public Guid MarkSheetId { get; set; }
        public Guid StudentId { get; set; }
        public string Subject { get; set; }
        public decimal TotalMark { get; set; }
        public decimal MarksObtained { get; set; }
    }
}
