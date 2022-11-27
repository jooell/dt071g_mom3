

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;


namespace guestbook
{
    public class PostClass
    {
        // file path and declaration of list
        private string fileLocation = @"C:\Users\46703\source\repos\guestbook\guestbook/posts.json";
        private List<object> listOfPosts = new List<object>();

        public PostClass() // Denna funktion körs vid initiering av klassen
        {   
            getPosts();
            printPosts();
        }

        //
        public void getPosts()
        {   
            if (File.Exists(@"C:\Users\46703\source\repos\guestbook\guestbook/posts.json") == true)
            {   // save conntents of file to variable
                string jsonString = File.ReadAllText(@"C:\Users\46703\source\repos\guestbook\guestbook/posts.json");
                // deserialisera som objekt
                listOfPosts = JsonSerializer.Deserialize<List<object>>(jsonString);
            }
            // om inte hittat fil, printa felmeddelande
            else { Console.WriteLine("\nhittade inte filen"); }
        }

        // loops through list and prints to console
        public void printPosts()
        {   // FUNCTION PRINT POSTS TO CONSOLE
            SinglePost singlePost = new SinglePost();
            int i = 0;
            foreach (object a in listOfPosts)
            {
                Console.WriteLine(i.ToString() + a);
                i++;
            }
        }

        // adds post as class item and adds to list
        public void addPost(SinglePost item)
        {
            listOfPosts.Add(item);
            writeToFile();
        }

        public void removePost(int listIndex)
        {
            listOfPosts.RemoveAt(listIndex);
            writeToFile();
            getPosts();
            printPosts();

        }

        //  serializes list to json and overwrites file
        private void writeToFile()
        {
            string jsonString = JsonSerializer.Serialize(listOfPosts);
            File.WriteAllText(fileLocation, jsonString);
        }



        // Nu funkar det. Värdena för guest och message sparas tillsammans. Lägg in indexering ??

    }
    
    public class SinglePost
    {
        private string guest;
        public string Guest
        {
            set { this.guest = value; }
            get { return this.guest; }
        }

        private string message;
        public string Message
        {
            set { this.message = value; }
            get { return this.message; }
        }
    }
    
 
    class Program //********* MAIN PROGRAM EXECUTION ***********
    {
        static void Main(string[] args)
        {   
            // new instance of PostClass
            PostClass postClass = new PostClass();

            // PRESENTATION 
            Console.WriteLine("Välkommen till gästboken \nGör ett val nedan \n\n");
            Console.WriteLine("'1' för att lägga till en ny post \n'2' för att testa \n'X' för att avsluta\n");

            // new instance of class
            SinglePost obj = new SinglePost();


            // SWITCH BY INPUT CHOISE
            int input = (int)Console.ReadKey(true).Key;
            switch (input) {
                case '1':
     
                    Console.WriteLine("skriv in username");
                    string userinput = Console.ReadLine();
                    obj.Guest = userinput;

                    Console.WriteLine("skriv in message");
                    string hej = Console.ReadLine();
                    obj.Message = hej;
                    postClass.addPost(obj);
                    break;
                case '2':
                    Console.WriteLine("Vilken post vill du ta bort?");
                    int listIndex = Convert.ToInt32(Console.ReadLine());
                    postClass.removePost(listIndex);

                    break;
                case 88:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

