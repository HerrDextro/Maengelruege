namespace Complaint_Form_Neo_BBB
{
    public class QuestionService
    {
        public string[] questions { get; set; } //nullable on purpose
        public string[]? answers { get; set; }//for OnPost

        private string[] questionArray;

        public QuestionService()
        {
            questionArray = File.ReadAllLines(@"C:\Users\Neo\source\repos\Complaint Form Neo BBB\Complaint Form Neo BBB\resources\QuestionUserInput.txt"); //change to relative path
            questions = questionArray;
        }

        static public void ShowAnswerArray(string[] answers) //DEBUGGING BEDUGGING GEBUNING BRUHHHH
        {
            for (int i = 0; i < answers.Length; i++)
            {
                Console.Write(answers[i] + " "); //space for spacing between tokens
            }
        }

    }
}
