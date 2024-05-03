using StudentPerformance.Entity.Models;
using StudentPerformance.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.Business.Contract
{
    public interface IStudentPerformanceBusiness
    {
        Task<StudentMaster> GetTotalMarkObtained(Guid studentId);

        Task<StudentMasterDTO> GetTotalPercentageObtained(Guid StudenId);

        public Task<StudentMasterDTO> GetAllMarksById(Guid StudenId);

        Task AddMarks(StudentMasterDTO payload);
       
        Task UpdateById(StudentMasterDTO payloadstudent);

        Task DeleteById(Guid id);

    }
}
