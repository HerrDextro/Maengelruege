using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Reflection;

namespace Complaint_Form_Neo_BBB.Pages
{
    public class IndexModel : PageModel
    {
        // This property will hold your questions
        public readonly QuestionService _questionService;
        public string[]? answers { get; set; }//for OnPost

        public IndexModel(QuestionService questionService)
        {
            _questionService = questionService;
        }
        public void OnGet()
        {
            // question array (later imported from backend Alex programs
            
            Console.WriteLine("hello world");
        }
        public IActionResult OnPost()
        {
            Console.WriteLine("OnPost success");
            //Console.WriteLine(Request.Form["question_3"]); //this works but afterwards its still null???
            _questionService.answers = new string[_questionService.questions.Length]; //makeing answers array same size and indexes as question one 
            for (int i = 0; i < _questionService.questions.Length; i++) //putting Questionarray into
            {
                _questionService.answers[i] = Request.Form[$"question_{i}"];
            }
            
            QuestionService.ShowAnswerArray(_questionService.answers); //debugging bedunging gebunging
            string? path = AnswerService.PDFMaker(_questionService.answers);
            return File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
            RedirectToPage("Privacy");
            //return RedirectToPage("Privacy"); //redirects to "submitted form" page
        }

        /*public FileStreamResult Download()
        {
            string? path = AnswerService.PDFMaker(_questionService.answers);
            return File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
        }*/
    }

}
