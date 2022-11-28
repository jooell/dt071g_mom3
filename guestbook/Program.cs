/*
 *      JOLI 2114 för moment 3 i kursen dt071g - mittuniversitetet
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// sleep functionality to delay
using System.Threading;

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
        }

        // get posts from file
        public void getPosts()
        {   
            if (File.Exists(fileLocation) == true)
            {   // save conntents of file to variable
                string jsonString = File.ReadAllText(@"C:\Users\46703\source\repos\guestbook\guestbook/posts.json");
                // deserialize and save as objecgs to list
                listOfPosts = JsonSerializer.Deserialize<List<object>>(jsonString);
            }
            // if file not found, print error and exit
            else { Console.WriteLine("\nFilen kunde inte hittas. Avslutar..."); Environment.Exit(0); }
        }

        // loops through list and prints to console
        public void printPosts()
        {
            Console.Clear();
            Console.WriteLine("VÄLKOMMEN TILL GÄSTBOKEN - dt071g - Joel Lindh \n\n");
            SinglePost singlePost = new SinglePost();           // new instance of class
            
            int i = 0;                                          // int for printing index
            foreach (object post in listOfPosts)
            {
                // format output and print with index
                string formatedMessage = Convert.ToString(post);
                formatedMessage = formatedMessage.Remove(0, 10);
                int index = formatedMessage.IndexOf(",");
                formatedMessage = formatedMessage.Remove(index, 12);
                formatedMessage = formatedMessage.Replace("\"}", string.Empty).Replace("\"", " - ");
                Console.WriteLine("[" + i.ToString() + "] " + formatedMessage);
                i++;
            }
        }

        // adds post as class item and adds to list
        public void addPost(SinglePost item)
        {
            listOfPosts.Add(item);
            writeToFile();
        }

        // removes post based on index
        public void removePost(int listIndex)
        {
            // check validity of input
            if (listIndex > listOfPosts.Count)
            {
                Console.WriteLine("\nFel inmatning. (index stämmer inte) Applikationen återstartas om 3 sekunder.");
                System.Threading.Thread.Sleep(3000);
                return;
            } else
            {
                listOfPosts.RemoveAt(listIndex);
                writeToFile();
                getPosts();
                printPosts();
            }
        }

        // serializes list to json and writes to file
        private void writeToFile()
        {
            string jsonString = JsonSerializer.Serialize(listOfPosts);
            File.WriteAllText(fileLocation, jsonString);
        }
    }
    
    // class single post to handle username and post
    public class SinglePost
    {
        private string guest;
        public string Guest
        { set { this.guest = value; } get { return this.guest; } }

        private string message;
        public string Message
        { set { this.message = value; } get { return this.message; } }
    }
 
    class Program //********* MAIN PROGRAM EXECUTION ***********//
    {
        static void Main(string[] args)
        {
            // new instance of PostClass
            PostClass postClass = new PostClass();

            while(true) {   // while true keeps function alive until exit

                Console.CursorVisible = false;  // removes cursor
                
                postClass.printPosts();         // prints posts and welcome messages
                Console.WriteLine("\nGör ett val nedan:\n");
                Console.WriteLine("'1' för att lägga till en ny post \n'2' för att testa \n'X' för att avsluta\n");

                // new instance of SinglePost
                SinglePost obj = new SinglePost();

                // swtich cases based on user key input
                int input = (int)Console.ReadKey(true).Key;
                switch (input) {
                    case '1':

                        Console.CursorVisible = true;
                        Console.WriteLine("Lägg till i gästboken!");
                        Console.WriteLine("Skriv in ditt användarnamn");
                        string userinput = Console.ReadLine();
                        obj.Guest = userinput;

                        Console.WriteLine("Skriv in ditt meddelande");
                        string usermessage = Console.ReadLine();
                        obj.Message = usermessage;

                        if (userinput == "" || usermessage == "")
                        {
                            {
                                Console.WriteLine("\nFel inmatning. (inget namn/meddelande angett) Applikationen stängs....");
                                System.Threading.Thread.Sleep(3000);
                                return;
                            }
                        } else
                        {
                            // calls on postClass functions to process input
                            postClass.addPost(obj); postClass.getPosts(); postClass.printPosts();
                            break;
                        }
                        return;
                    case '2':

                        Console.CursorVisible = true;
                        Console.WriteLine("Ta bort post från gästboken!");
                        Console.WriteLine("Vilken post vill du ta bort? Välj baserat på index.");

                        int listIndex = Convert.ToInt32(Console.ReadLine());
                        postClass.removePost(listIndex);

                        break;
                    case 88:    // if user input = "X", exit program
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}

