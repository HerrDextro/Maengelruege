using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace Complaint_Form_Neo_BBB
{
    public class AnswerService
    {
        public static string? PDFMaker(string[] answers)
        {
            string filepath = @"C:\Users\Neo\source\repos\Complaint Form Neo BBB\Complaint Form Neo BBB\resources\Templates\pdfTemplate.txt";
            string filePathSave = @"C:\Users\Neo\source\repos\Complaint Form Neo BBB\Complaint Form Neo BBB\resources\pdfOutput\";

            // Read the template file with UTF-8 encoding
            string text = File.ReadAllText(filepath, Encoding.Default);

            // Split the text into lines using ';' as delimiter
            string[] lines = text.Split(new string[] { ";" }, StringSplitOptions.None);

            // Regex pattern to match placeholders in the form of ;index;
            string pattern = @";(\d+);";

            // Replace placeholders with corresponding answers
            string result = Regex.Replace(text, pattern, match =>
            {
                int index = int.Parse(match.Groups[1].Value);
                return (index >= 0 && index < answers.Length) ? answers[index] : match.Value;
            });

            // Split the result into lines
            string[] newLines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Create a new document
            Document document = new Document();
            Section section = document.AddSection();

            // Set the font to Arial which supports German umlauts
            string fontName = "Times New Roman";

            foreach (string line in newLines)
            {
                Paragraph paragraph = section.AddParagraph();
                TextRange textRange = paragraph.AppendText(line);
                textRange.CharacterFormat.FontName = fontName;
            }

            // Generate a unique file name using GUID
            Guid uuid = Guid.NewGuid();
            string fullFilePath = Path.Combine(filePathSave, $"{uuid}.pdf");

            // Save the document as PDF
            try
            {
                document.SaveToFile(fullFilePath, FileFormat.PDF);
                Console.WriteLine("Dokument erstellt");
                return fullFilePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern des Dokuments: {ex.Message}");
                return null;
            }
        }
    }
}
