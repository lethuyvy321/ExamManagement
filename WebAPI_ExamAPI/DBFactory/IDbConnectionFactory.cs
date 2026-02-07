using System.Data;

namespace WebAPI_ExamAPI.DBFactory
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
