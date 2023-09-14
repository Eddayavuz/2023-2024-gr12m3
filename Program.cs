using System;
using System.IO;

namespace Playground
{
    class HandleFiles // define class
    {

/*** DIRECTORY METHOD - DIRECTORY METHOD - DIRECTORY METHOD - DIRECTORY METHOD - DIRECTORY METHOD - DIRECTORY METHOD ***/

        public void CreateDir()
        {
            Directory.CreateDirectory("/Users/eda/Desktop/myFile");
        }

        public void CreateTxt()
        {
            string path = @"/Users/eda/Desktop/myFile/myText.txt";
            StreamWriter text = File.CreateText(path);
        }

/*** WRITE METHOD - WRITE METHOD - WRITE METHOD - WRITE METHOD - WRITE METHOD - WRITE METHOD ***/

        public void Write() // define Write method
        {
            StreamWriter write = new StreamWriter("/Users/eda/Desktop/myFile/myText.txt"); //create a new stream writer object named write and tell the object the path of the text file.
            write.WriteLine("Ms. Yavuz is the best!");//write the message in the text file.
            write.Close();//close the stream writer object.
        }

/*** READ METHOD - READ METHOD - READ METHOD - READ METHOD - READ METHOD - READ METHOD - READ METHOD  ***/

        public void Read() // define Read method
        {
            StreamReader read = new StreamReader("/Users/eda/Desktop/myFile/myText.txt"); //create a new stream reader object named read and tell the object the path of the text file.
            string line = read.ReadLine(); // define line variable and assign the readline method's value to it.

            /* while (line != null)         THERE'S A MISTAKE HERE. SEE IF YOU CAN FIND IT YOU HAVE 5 MINS.
           {
               Console.WriteLine(line);
               line = read.ReadLine();
           }
           Console.ReadLine();*/

            Console.WriteLine(line); // display line in the console.
            read.Close(); // close the stream reader object.
        }

        public static void Main(String[] args)
        {
            HandleFiles wr = new HandleFiles();
            HandleFiles rd = new HandleFiles();
            HandleFiles dr = new HandleFiles();
            HandleFiles tx = new HandleFiles();
            dr.CreateDir();
            tx.CreateTxt();
            wr.Write();
            rd.Read();


            Console.ReadKey();
        }
    }

}