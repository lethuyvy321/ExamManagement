using ExamModelLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebAPI_ExamAPI.DBFactory;
using WebAPI_ExamAPI.Responsitories;

namespace WebAPI_ExamAPI.Reponsitories
{
    public class ExamRepository : IExamRepository
    {
        private readonly IDbConnectionFactory _db;
        public ExamRepository(IDbConnectionFactory db)
        {
            _db = db;
        }
        public Task<AddExamResponseType> AddExamAsync(Exam objRequestType)
        {
            AddExamResponseType addExamResponse = new AddExamResponseType
            {
                ReturnCode = (int)ErrorType.ErrorType_Success,
                ReturnMessage = "Success"
            };

            using var conn = _db.Create();
            SqlCommand sqlCommand = (SqlCommand)conn.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.CreateExam";
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 500).Value = objRequestType.ExamName;
            sqlCommand.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            int returnValue = (int)sqlCommand.Parameters["@Return"].Value;
            if (returnValue != 1)
            {
                addExamResponse.ReturnCode = returnValue;
                addExamResponse.ReturnMessage = "Error occurred while adding exam.";
                return Task.FromResult(addExamResponse);
            }

            return Task.FromResult(addExamResponse);
        }

        public Task<GetExamsResponseType> GetExamsAsync(string categoryCode)
        {
            GetExamsResponseType getExamsResponse = new GetExamsResponseType
            {
                ReturnCode = (int)ErrorType.ErrorType_Success,
                ReturnMessage = "Success"
            };

            using var conn = _db.Create();
            SqlCommand sqlCommand = (SqlCommand)conn.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.GetExams";
            if (!string.IsNullOrEmpty(categoryCode))
            {
                sqlCommand.Parameters.Add("@CategoryCode", SqlDbType.VarChar, 64).Value = categoryCode;
            }
            sqlCommand.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            conn.Open();
            var result = new DataTable();
            using (var reader = sqlCommand.ExecuteReader())
            {
                result.Load(reader);
            }

            int returnValue = (int)sqlCommand.Parameters["@Return"].Value;
            if (returnValue != 1)
            {
                getExamsResponse.ReturnCode = returnValue;
                getExamsResponse.ReturnMessage = "Error occurred while adding exam.";
                return Task.FromResult(getExamsResponse);
            }
            getExamsResponse.Exams = result;
            return Task.FromResult(getExamsResponse);
        }
    }
}
