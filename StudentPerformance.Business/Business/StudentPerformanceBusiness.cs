using AutoMapper;
using StudentPerformance.Business.Contract;
using StudentPerformance.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPerformance.Repository.Contract;
using StudentPerformance.Repository.Repository;
using StudentPerformance.ViewModel.ViewModel;

namespace StudentPerformance.Business.Business
{
    public class StudentPerformanceBusiness:  IStudentPerformanceBusiness
    {
        private readonly IStudentPerformanceRepository _studentPerformanceRepository;
        private readonly IMapper _mapper;
        public StudentPerformanceBusiness(IStudentPerformanceRepository studentPerformanceRepository, IMapper mapper)
        {
            _studentPerformanceRepository = studentPerformanceRepository;
            _mapper = mapper;
        }

        public Task<StudentMasterDTO> GetAllMarksById(Guid StudenId)
        {
            StudentMaster studentData = new();

            var result = await _studentPerformanceRepository.GetAllMarksById(StudenId);

            studentData = _mapper.Map<StudentMaster>(result);


            return studentData;
        }

        public async Task<StudentMaster> GetTotalMarkObtained(Guid studentId)
        {   
            StudentMaster marksheets = new();
            marksheets = await _studentPerformanceRepository.GetTotalMarkObtained(studentId);
            marksheets= _mapper.Map<StudentMaster>(marksheets);
            return marksheets;
               
         
        }

        public async Task<StudentMasterDTO> GetTotalPercentageObtained(Guid StudenId)
        {
            return await _studentPerformanceRepository.GetTotalPercentageObtained(StudenId);
        }

        public async Task AddMarks(StudentMasterDTO payloadstudent)
        {

            await _studentPerformanceRepository.AddMarks(payloadstudent);
            return;
        }



        public async Task UpdateById(StudentMasterDTO payloadstudent)
        {
            await _studentPerformanceRepository.UpdateById(payloadstudent);
            return;
        }


        public async Task DeleteById(Guid id)
        {
            await _studentPerformanceRepository.DeleteById(id);
            return;
        }


    }
}
   