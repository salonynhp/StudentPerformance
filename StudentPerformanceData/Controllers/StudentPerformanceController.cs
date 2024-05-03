using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentPerformance.Business.Contract;
using StudentPerformance.Business.Business;
using StudentPerformance.ViewModel.ViewModel;
using StudentPerformance.Entity.Models;
namespace StudentPerformanceData.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentPerformanceController : ControllerBase
    {
        private readonly IStudentPerformanceBusiness _studentPerformanceBusiness;
        private readonly IMapper _mapper;
        public StudentPerformanceController(IStudentPerformanceBusiness StudentPerformanceBusiness, IMapper mapper)
        {
            _studentPerformanceBusiness = StudentPerformanceBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<StudentMaster> GetTotalMarkObtained([FromHeader]Guid studentId)
        {
            var result = await _studentPerformanceBusiness.GetTotalMarkObtained(studentId);
           
            return result;         

        }

        [HttpGet("GetTotalPercentageObtained")]
        public async Task<IActionResult> GetTotalPercentageObtained([FromHeader] Guid studentId)
        {
            try
            {
                var studentModel = await _studentPerformanceBusiness.GetTotalPercentageObtained(studentId);
                return Ok(studentModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllMarksById(Guid id)
        {
            var result = await _studentPerformanceBusiness.GetAllMarksById(id);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            await _studentPerformanceBusiness.DeleteById(id);
            return Ok("DELETED");

        }



    }
}
