using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileWriteExample
{
    class Simple
    {
        public Simple()
        {
            string strLine; // Variable to hold file data

            // This line creats a file called myFile for the program and
            // called TestFile.dat in the disk. The false value will force
            // the file to rewrite over any existing data. A true value will
            // append data to the end of the file or creat the file if it does
            // not exist.
            // StreamWriter opens a file for output from the program.
            StreamWriter myFileOut = new StreamWriter("TestFile.dat", false);

            // Write data to a file.
            // .Write() command sends data to the file without the newline command.
            myFileOut.Write("Hello, today is {0}, ", DateTime.Now.ToShortDateString());

            // .WriteLine() command sends data to the file with the newline command.
            myFileOut.WriteLine(" and this is a line check.");
            myFileOut.WriteLine("Check Line 1");
            myFileOut.WriteLine("Check Line 2");
            myFileOut.WriteLine("Check Line 3");

            // .Close()close a file for output.
            myFileOut.Close();

            // Opens a file for input to the program.
            StreamReader myFileIn = new StreamReader("TestFile.Dat");

            Console.WriteLine("Read by lines");
            Console.WriteLine();
            strLine = myFileIn.ReadLine(); // Prime the input Stream

            while (strLine != null) // Check for file data before outputing data
            {
                Console.WriteLine(strLine);
                strLine = myFileIn.ReadLine();
            }

            // .Close() close a file for input.
            myFileIn.Close();

            Console.WriteLine(); // Put black line to screen

            // Opens a file for input to the program.
            StreamReader myFile = new StreamReader("TestFile.Dat");

            Console.WriteLine("Read by Chars");
            Console.WriteLine();
            int fChar;
            fChar = myFile.Read();
            while (fChar != -1)
            {
                Console.Write(Convert.ToChar(fChar));
                fChar = myFile.Read();
            }

            myFile.Close();
            Console.WriteLine("Please press enter to see the Complex Example.");
            //Console.ReadLine(); Turned off in XNA
        }
    }
}

