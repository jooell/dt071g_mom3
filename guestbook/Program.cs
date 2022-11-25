

using System;
using System.Collections.Generic;
using System.IO;

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
            Console.WriteLine("theja");
            string userinput = Console.ReadLine();
            Console.Write(userinput);
        }
    }



}