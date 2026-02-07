using ExamModelLibrary;
using WebAPI_ExamAPI.Responsitories;

namespace WebAPI_ExamAPI.Service
{
    public class ExamService
    {
        private readonly IExamRepository _examRepository;
        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }
        public async Task<AddExamResponseType> AddExamAsync(AddExamRequestType addExamRequestType)
        {
            return await _examRepository.AddExamAsync(addExamRequestType.Exam);
        }
        public async Task<GetExamsResponseType> GetExamsAsync(GetExamsRequestType getExamsRequestType)
        {
            return await _examRepository.GetExamsAsync(getExamsRequestType.CategoryCode);
        }
    }
}
