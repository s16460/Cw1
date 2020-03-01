using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1 {
    class Program {


        public static async Task Main(string[] args)
        {


            var g = 1;
            var h = "gggg";
            var t = true;
            string path = @"C:\Users\s16460\Desktop\projektApd\Cw1";
            Console.WriteLine($"{g} {h}");
            Console.WriteLine(g + h + t);
            Console.WriteLine(path);

            Person newPerson = new Person { FirstName = "mietek", LastName = "brodek" };

            //string url = args.Length > 0 ?args[0] : "https://www.pja.edu.pl";
            string url = args[0];
            Console.WriteLine("Hello World!");

            if (url == null)
            {
                throw new ArgumentNullException("brak argow");
            }



            using (HttpClient http = new HttpClient())  //using zwalnia zasoby
            {
                using (var response = await http.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode) //cheking if http resp is 200 or so
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();
                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var item in matches)
                        {
                            Console.WriteLine(item.ToString());
                        }

                    }
                }


            }

        }
         
    }
}
