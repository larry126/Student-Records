using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Student_Record
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] studentRecords = new string[0];
			bool exitProgram = false;
			Console.WriteLine("Welcome to Student Records\n");
			Console.WriteLine("Menu");
			Console.WriteLine("1. Read File");
			Console.WriteLine("2. Output 1 Student Record");
			Console.WriteLine("3. Output all Student Record");
			Console.WriteLine("Enter E to exit");
			while (exitProgram == false)
			{
				Console.WriteLine("\nEnter your option:");
				string opt = Console.ReadLine().ToLower();
				if (opt == "1")
				{
					studentRecords = readFile();
				}
				else if (opt == "2")
				{
					outputSingle(studentRecords);
				}
				else if (opt == "3")
				{
					outputAll(studentRecords);
				}
				else if (opt == "e")
				{
					exitProgram = true;
				}
				else
				{
					Console.WriteLine("Invalid Input");
				}
			}
			Console.ReadLine();
		}

		static private string[] readFile()
		{
			string[] studentRecordLocal = new string[100];
			bool fileFound = false;
			while (fileFound == false)
			{
				Console.WriteLine("\nPlease enter the file name with extension:");
				string fileName = Console.ReadLine();
				try
				{
					using (StreamReader reader = new StreamReader(fileName))
					{
						int i = 0;
						while (!reader.EndOfStream)
						{
							studentRecordLocal[i] = reader.ReadLine();
							i++;
						}
					}
					fileFound = true;
				}
				catch (FileNotFoundException)
				{
					Console.WriteLine("\n\tFile not found");
				}
			}
			return studentRecordLocal;
		}

		static private void outputSingle(string[] studentRecords)
		{
			Console.WriteLine("\nPlease enter the index value");
			int index;
			while (true)
			{
				try
				{
					index = Convert.ToInt32(Console.ReadLine());
					break;
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid Input");
				}
			}
			string studentDetails = studentRecords[index].Replace(",","\t");
			Console.WriteLine("\n"+studentDetails);
		}
		static private void outputAll(string[] studentRecords)
		{
			Console.WriteLine();
			foreach (var details in studentRecords)
			{
				Console.WriteLine(details);
			}
		}
	}
}
