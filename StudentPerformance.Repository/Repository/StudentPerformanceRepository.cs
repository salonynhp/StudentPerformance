using StudentPerformance.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPerformance.Repository.Contract;
using StudentPerformance.Repository.Common;
using StudentPerformance.Entity.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentPerformance.ViewModel.ViewModel;

namespace StudentPerformance.Repository.Repository
{
    public class StudentPerformanceRepository : IStudentPerformanceRepository
    {
        private readonly StudentAssgnContext _dbContext;
        private readonly IMapper _mapper;

        public StudentPerformanceRepository(StudentAssgnContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        

        public async Task<StudentMaster> GetTotalMarkObtained(Guid studentId)
        {
            StudentMaster std = new();
            var student = await _dbContext.StudentMasters
                 .Where(_ => _.StudentId == studentId).FirstOrDefaultAsync();


            decimal totalMarkObtained = student.Marksheets
                .Where(m => m.StudentId == studentId)
                .Sum(m => m.MarksObtained);

            return student;
        
        }

        public async Task<StudentMasterDTO> GetTotalPercentageObtained(Guid StudentId)
        {
            StudentMasterDTO std = new();
            //var student = await _dbContext.StudentMasters
            //    .Where(_ => _.StudentId == StudentId).FirstOrDefaultAsync();


            //var totalMarkObtained = student.Marksheets
            //    .Where(m => m.StudentId == StudentId);
            //var totalMarks =student.Marksheets
            //    .Sum(m => m.MarksObtained);
            //var totalMarksObtained = MarkSheets.Sum(ms => ms.SubjectTotalMark);
            //var marksObtained = markSheets.Sum(ms => ms.MarksObtained);
            //return (double)marksObtained / totalMarks * 100;


            var student = await _dbContext.StudentMasters
                .Include(s => s.Marksheets)
                .FirstOrDefaultAsync(s => s.StudentId == StudentId);

            if (student == null)
            {
                throw new Exception($"Student with ID {StudentId} not found.");
            }

            var subjects = new[] { "Maths", "English", "Science", "Hindi" };
            decimal totalMarksObtained = student.Marksheets
                .Where(m => subjects.Contains(m.Subject))
                .Sum(m => m.MarksObtained);

            decimal totalMaxMarks = student.Marksheets
                .Where(m => subjects.Contains(m.Subject))
                .Sum(m => m.TotalMark);

            decimal totalPercentageObtained = (totalMarksObtained / totalMaxMarks) * 100;

            var studentModel = _mapper.Map<StudentMasterDTO>(student);
            studentModel.TotalPercentage = totalPercentageObtained;
            studentModel.TotalMark= totalMaxMarks;
            studentModel.TotalMarkObtained = totalMarksObtained;
            return studentModel;
        }


        public Task<StudentMasterDTO> GetAllMarksById(Guid StudenId)
        {
            StudentMaster std = new();
            var stu = await _dbContext.StudentMasters
                .Where(_ => _.StudentId == ID).FirstOrDefaultAsync();
            if (stu == null)
                return std;
            return stu;
        }


        public async Task AddMarks(StudentMasterDTO payloadstudent)
        {
            try
            {
                var newmark1 = _mapper.Map<StudentMasterDTO>(payloadstudent);
            }
            catch (Exception)
            {

                throw;
            }
            var newmark = _mapper.Map<StudentMasterDTO>(payloadstudent);
            _dbContext.StudentMasters.Add(newmark);
            await _dbContext.SaveChangesAsync();
            //return Created("/Studentdetails/{newmark.StudentId}", newmark);    


        }

        //PUT
        public async Task UpdateById(StudentMasterDTO payloadstudent)
        {
            var updateStudent = _mapper.Map<StudentMasterDTO>(payloadstudent);
            _dbContext.StudentMasters.Update(updateStudent);
            await _dbContext.SaveChangesAsync();


        }


        public async Task DeleteById(Guid id)
        {
            try
            {

                var studentdelete = await _dbContext
                    .StudentMasters.Include(_ => _.Marksheet)
                    .FirstOrDefaultAsync();


                _dbContext.StudentMasters.Remove(studentdelete);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return;

            }
        }

    }
}
