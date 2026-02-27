using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // Must add for this example to work
using System.Data; // Must first include as part of framework then add here

namespace FileWriteExample
{
    class Complex
    {
        public Complex()
        {
            Console.WriteLine();

            DataSet myDataSet = GetData();
            foreach (DataColumn c in myDataSet.Tables["TheData"].Columns)
                Console.Write("{0,-20}", c.ColumnName);
            Console.WriteLine();

            foreach (DataRow r in myDataSet.Tables["TheData"].Rows)
            {
                foreach (DataColumn c in myDataSet.Tables["TheData"].Columns)
                    Console.Write("{0,-20}", r[c]);
                Console.WriteLine();
            }
            Console.WriteLine("Please press enter to exit program.");
           // Console.ReadLine(); Turned OFF in XNA
        }

        // This function will take a file's data and separate it by ',' found in the
        // file. This is not my function but I will try to explain it's code.

        private static DataSet GetData()
        {
            string strLine;
            string[] strArray;
            char[] charArray = new char[] { ',' };
            int I;

            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("TheData");

            // Open the File for program input
            StreamReader myFileC = new StreamReader("TestFile2.dat");

            // Read the Column Headings from the first line
            strLine = myFileC.ReadLine();

            // Split the row of data into the string array
            strArray = strLine.Split(charArray);

            for (I = 0; I <= strArray.GetUpperBound(0); I++)
            {
                dt.Columns.Add(strArray[I]);
            }
            strLine = myFileC.ReadLine();
            while (strLine != null)
            {
                // Split next row of data into string array
                strArray = strLine.Split(charArray);

                DataRow dr = dt.NewRow();
                for (I = 0; I <= strArray.GetUpperBound(0); I++)
                    dr[I] = strArray[I];

                dt.Rows.Add(dr);
                strLine = myFileC.ReadLine();
            }
            myFileC.Close();
            return ds;
        }
    }
}
