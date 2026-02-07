using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ExamModelLibrary
{
    public class GetExamsResponseType : APIResponseType
    {
        public DataTable Exams { get; set; }
    }
}
