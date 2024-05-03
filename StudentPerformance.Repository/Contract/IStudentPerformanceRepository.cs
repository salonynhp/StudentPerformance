using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentPerformance.Entity.Models;
using StudentPerformance.Entity;
using StudentPerformance.ViewModel.ViewModel;

namespace StudentPerformance.Repository.Contract
{
    public interface IStudentPerformanceRepository
    {
        public Task<StudentMaster> GetTotalMarkObtained(Guid studentId);

        public Task<StudentMasterDTO> GetTotalPercentageObtained(Guid StudenId);

        //Getlist of marks obtained for a student in 4 subjects individualy.
        public Task<StudentMasterDTO> GetAllMarksById(Guid StudenId);

        Task AddMarks(StudentMasterDTO payload);
        
        Task UpdateById(StudentMasterDTO payloadstudent);

        Task DeleteById(Guid id);


    }
}
