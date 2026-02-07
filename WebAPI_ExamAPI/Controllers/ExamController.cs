using ExamModelLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebAPI_ExamAPI.Service;

namespace WebAPI_ExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ExamService _examService;
        public ExamController(ExamService examService)
        {
            _examService = examService;
        }
        [HttpGet]
        public async Task<GetExamsResponseType> Get(string categoryCode)
        {
            GetExamsRequestType getExamsRequestType = new GetExamsRequestType
            {
                CategoryCode = categoryCode,
            };
            var result = await _examService.GetExamsAsync(getExamsRequestType);
            return result;
        }
        //[HttpPost("AddExam")]
        //public async Task<IActionResult> AddExam(AddExamRequestType addExamRequest)
        //{
        //    var result = await _examService.AddExamAsync(addExamRequest);
        //    return Ok(result);
        //}
    }
}
