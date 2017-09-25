using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;


namespace DemoTesseract
{
    class Program
    {
        static void Main(string[] args)
        {
            var testImage = "./captcha.jpg";

            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImage))
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();

                            Console.WriteLine("Precisión : {0}", page.GetMeanConfidence());
                            Console.WriteLine("Texto: {0}", texto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                throw;
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
