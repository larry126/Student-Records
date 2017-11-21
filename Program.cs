using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Student_Records
{
	class Program
	{
		static List<Student> records = new List<Student>();
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Student Records");
			bool keepGoing = true;
			while (keepGoing)
			{
				ReadInFile();
				Console.WriteLine("1 - ");
				Console.WriteLine("2 - Find Student by index No.");
				Console.WriteLine("3 - Find First Match");
				Console.WriteLine("4 - Output All Records");
				Console.WriteLine("5 - Find Student by Student No.");
				Console.WriteLine("9 - Quit");
				Console.Write("Select an option: ");
				char menuChoice = Console.ReadLine().ToCharArray()[0];
				Console.WriteLine();
				switch (menuChoice)
				{
					case '2':
						FindRecordByIndex();
						break;
					case '3':
						FindFirstMatch();
						break;
					case '4':
						ListedAllRecords();
						break;
					case '5':
						FindRecordByStudentNumber();
						break;
					case '9':
						keepGoing = false;
						break;
					default:
						Console.WriteLine("Invalid menu choice");
						break;
				}
			}
		}

		static void ReadInFile()
		{
			while (true)
			{
				Console.Write("Please Enter FileName: ");
				string fileName = Console.ReadLine() + ".csv";
				try
				{
					ReadFileIntoRecordsArray(fileName);
					break;
				}
				catch (FileNotFoundException)
				{
					Console.WriteLine("File does not exist");
				}
			}
		}

		static void FindRecordByIndex()
		{
			Console.Write("Enter Index No. :");
			try
			{
				int index = Convert.ToInt32(Console.ReadLine());
				WriteRecordToConsole(records[index]);
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Not a valid index");
			}
			catch (FormatException)
			{
				Console.WriteLine("Not a number");
			}
		}

		static void FindFirstMatch()
		{
			Console.Write("Enter a search string: ");
			string searchString = Console.ReadLine();
			var record = FindFirstMatch(searchString);
			WriteRecordToConsole(record);
		}

		static string FindFirstMatch(string searchString)
		{
			return records.Where(r => r.Contains(searchString)).First();
		}

		static void ReadFileIntoRecordsArray(string fileName)
		{
			using (StreamReader reader = new StreamReader(fileName))
			{
				int i = 0;
				while (!reader.EndOfStream)
				{
					//records.Add(reader.ReadLine());
					string[] details = reader.ReadLine().Split(',');
					records.Add(new Student(Convert.ToInt32(details[0]), details[1], details[2], Convert.ToDateTime(details[3])));
					records[i].grade = Convert.ToChar(details[4]);
					i++;
				}
			}
		}

		static void WriteRecordToConsole(string record)
		{
			var formatted = record.Replace(",", "\t");
			Console.WriteLine(formatted);
		}

		static void ListedAllRecords()
		{
			foreach (var record in records.OrderBy(g => g.Number))
			{
				Student.Output(record);
			}
		}

		static void FindRecordByStudentNumber()
		{
			Console.Write("Enter Student No. :");
			int number = Convert.ToInt32(Console.ReadLine());
			//Get the number from the user
			var record = records.Where(s => Convert.ToInt32(s.Split(',')[0]) == number).FirstOrDefault();
			if (record != null)
			{
				WriteRecordToConsole(record);
			}
			else
			{
				Console.WriteLine("Invalid Number");
			}
		}
	}
}