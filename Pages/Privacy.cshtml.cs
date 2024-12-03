using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Complaint_Form_Neo_BBB.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public readonly QuestionService _questionService;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }




        [HttpGet]
        public async Task<IActionResult> GetFileById()
        {
            string path = @"C:\Users\Neo\source\repos\Complaint Form Neo BBB\Complaint Form Neo BBB\resources\pdfOutput\25e8b132-af06-4588-997d-6a31cf05c50f.pdf";


            if (System.IO.File.Exists(path))
            {
                return File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
            }
            return NotFound();
        }

        public void /*FileStreamResult*/ OnGet() //here file download when submit is pressed
        {
            /*leave this out
            string? path = AnswerService.PDFMaker(_questionService.answers);
            return File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));*/
            
        }

    }

}
