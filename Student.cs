using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Records
{
	public class Student
	{
		public int Number { get; private set; }

		public string firstName { get; private set; }

		public string lastName { get; private set; }

		public DateTime DateOfBirth { get; private set; }

		public char grade { get; set; }

		public Student(int number, string first, string last, DateTime date)
		{
			Number = number;
			firstName = first;
			lastName = last;
			DateOfBirth = date;
		}
		public static void Output(Student st)
		{
			Console.WriteLine(Convert.ToString(st.Number) + "\t" + st.firstName + "\t" + st.lastName + "\t" + st.DateOfBirth + "\t" + st.grade);
		}
		public string ConvertToString()
		{
			return Number.ToString()+firstName+lastName+DateOfBirth+grade.ToString();
		}
		public bool IsOverAge(int requiredAge)
		{
			return DateOfBirth.AddYears(requiredAge) <= DateTime.Today;
		}
	}
}