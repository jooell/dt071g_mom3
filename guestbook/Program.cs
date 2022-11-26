

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace guestbook
{
    public class Post
    {
        // sökväg för fil
        private string filename = @"posts.json";


        public Post() {
            if (File.Exists(filename) == true ) {
                Console.WriteLine("Filsökväg hittad");
                string jsonString = File.ReadAllText(filename);

            }
        }



        private string user1;
        public string message1;






    }

    class Program
    {
        static void Main(string[] args)
        {
            // inom <> finsn det som ska lagras, objekt för json
            List <object> poster = new List <object> ();
            Console.WriteLine("theja");
            


            // testa filsökväg
            if (File.Exists(@"C:\Users\46703\source\repos\guestbook\guestbook/posts.json") == true) {
                Console.WriteLine("Filsökväg hittad");
                string jsonString = File.ReadAllText(@"C:\Users\46703\source\repos\guestbook\guestbook/posts.json");
                // deserialisera som objekt
                poster = JsonSerializer.Deserialize<List<object>>(jsonString);

                foreach (object a in poster)
                {
                    Console.WriteLine(a);
                }

            }
            else {
                Console.WriteLine("\nhittade itne filen");
            }

            



        }
    }



}