using System;
using System.Collections.Generic;
using System.Text;

namespace ExamModelLibrary
{
    public class APIResponseType
    {
        public int ReturnCode;
        public string ReturnMessage;
    }
    public enum ErrorType
    {
        ErrorType_Success = 1,
        ErrorType_Unknown = 4,
        ErrorType_Warning = 2,
        ErrorType_Fail = 3
    }
}
