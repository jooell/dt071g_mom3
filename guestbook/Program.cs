

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



            // frågeställning för alternativ

            Console.WriteLine("Välkommen till gästboken \n");

            Console.WriteLine("Gör ett val nedan \n\n");

            Console.WriteLine("1 för att visa alla poster \n");
            Console.WriteLine("X för att avsluta \n");


            // readkey är samma som readline men man slipper enter
            int input = (int)Console.ReadKey(true).Key;
            switch (input) {
                case '1':
                    printPosts();
                    break;
                case '2':
                    Console.WriteLine("Du har valt 2");
                    break;

                case 88:
                    Environment.Exit(0);
                    break;
            }










            void printPosts()
            {
                // testa filsökväg
                if (File.Exists(@"C:\Users\46703\source\repos\guestbook\guestbook/posts.json") == true)
                {   // spara i lokal variabel
                    Console.WriteLine("Filsökväg hittad");
                    string jsonString = File.ReadAllText(@"C:\Users\46703\source\repos\guestbook\guestbook/posts.json");
                    // deserialisera som objekt
                    poster = JsonSerializer.Deserialize<List<object>>(jsonString);

                    // skriv ut
                    foreach (object a in poster)
                    {
                        Console.WriteLine(a);
                    }
                }
                else // om inte hittat fil
                {
                    Console.WriteLine("\nhittade inte filen");
                }
            }
            



        }
    }



}