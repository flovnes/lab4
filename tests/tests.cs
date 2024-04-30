using Xunit;
using struct_lab_student;

namespace student_tests
{
	public partial class Tests
	{
		[Fact]
		public static void Student_Constructor_ReturnStudentList()
		{
			List<Student> students = [];
			students.Add(new("Прізвище1 Ім'я1 По-батькові1 M 02.02.2000 3 4 5 1234"));
			students.Add(new("surname FIRST_NAME 🔥 F 02.02.2000 4 - 2 1234"));
			students.Add(new("1 2 3 4 5 - - - 6"));
			Console.WriteLine(students.Count < 3 ? "this is a test, stupid" : "no way!");
		}

		[Fact]
		public static void Student_Var10_ReturnStudents()
		{
			List<Student> students = [];
			students.Add(new("Андрущенко Вадим Миколайович M 23.06.2004 2 1 - 1285"));
			students.Add(new("Стакан Єгор Олександрович Ч 04.01.2006 4 5 3 4319"));
			students.Add(new("Кірпіч Влад Шварцович Ч 12.06.1998 4 4 5 3538"));
			students.Add(new("Муха Саня Респектович F 12.11.1999 3 5 4 3392"));

			int counter = 0;
			foreach (Student student in students)
			{
				if (Program.IsTalentedPhysician(student))
					counter++;
			}
			Assert.Equal(2, counter);
		}

		[Fact]
		public static void Student_EvalAverage_ReturnDouble() 
		{
			int counter = 0;
			List<Student> students = [];
			students.Add(new("Прізвище1 Ім'я1 По-батькові1 M 02.02.2000 - 4 5 1234"));
			students.Add(new("surname FIRST_NAME 🔥 F 02.02.2000 3 1 3 1234"));
			students.Add(new("1 2 3 4 5 - 5 - 6666"));
			double[] expectedAverages = [3.7, 2.3, 3.0];
			foreach (var (student, average) in students.Zip(expectedAverages))
			{
				Assert.Equal(average, Program.EvalAverage(student));
				counter++;
			}
		}
		
		[Fact]
		public static void Student_FilterSummer_ReturnStudents() 
		{
			List<Student> students = [];
			students.Add(new("Прізвище1 Ім'я1 По-батькові1 M 02.02.4000 3 5 2 1234"));
			students.Add(new("surname FIRST_NAME 🔥 F 02.06.3220 3 3 3 1234"));
			students.Add(new("1 2 3 4 29.08.2002 - 5 - 6666"));
			
			int count = 0;
			foreach (Student student in students)
			{
				if (Program.IsBornInSummer(student))
					count++;
			}
			Assert.Equal(2, count);
		}
	}
}
