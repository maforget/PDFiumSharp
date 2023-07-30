using System.IO;
using PDFiumSharp;

namespace Test.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var doc = new PdfDocument("TestDoc.pdf", "password"))
            {
                var i = 0;
                foreach (var page in doc.Pages)
                {
                    using (page)
                    {
                        using (var bitmap = new PDFiumBitmap((int)page.Width, (int)page.Height, true))
                        using (var stream = new FileStream($"{i++}.bmp", FileMode.Create))
                        {
                            page.Render(bitmap);
                            bitmap.Save(stream);
                        }
                    }
                }
            }

            System.Console.ReadKey();
        }
    }
}