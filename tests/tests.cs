using Xunit;
using struct_lab_student;

namespace student_tests {
	public partial class Tests {
		[Fact]
		public static void Student_Constructor_ReturnStudentList() {
			List<Student> students = [];
			students.Add(new("Прізвище1 Ім'я1 По-батькові1 M 02.02.2000 3 4 5 1234"));
			students.Add(new("surname FIRST_NAME 🔥 F 02.02.2000 4 - 2 1234"));
			students.Add(new("1 2 3 4 5 - - - 6"));
			Console.WriteLine(students.Count < 3 ? "this is a test, stupid" : "no way!");
		}
	}
}