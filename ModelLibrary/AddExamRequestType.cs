namespace ExamModelLibrary
{
    public class Exam
    {
        public string ExamCode;
        public string ExamName;
    }
    public class AddExamRequestType : APIRequestType
    {
        public Exam Exam;
    }
}
