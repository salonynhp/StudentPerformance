using AutoMapper;
using StudentPerformance.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPerformance.Entity.Models;
using StudentPerformance.Repository.Repository;
namespace StudentPerformance.Repository.Common
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<StudentMaster, StudentMasterDTO>();
            CreateMap<StudentMaster, StudentMasterDTO>().ReverseMap();

            CreateMap<Marksheet, MarksheetDTO>();
            CreateMap<Marksheet, MarksheetDTO>().ReverseMap();    
        }
    }
}
