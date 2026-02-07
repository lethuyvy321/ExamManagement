using ExamModelLibrary;

namespace WebAPI_ExamAPI.Responsitories
{
    public interface IExamRepository
    {
        Task<AddExamResponseType> AddExamAsync(Exam examRequestType);
        Task<GetExamsResponseType> GetExamsAsync(string categoryCode);

    }
}
