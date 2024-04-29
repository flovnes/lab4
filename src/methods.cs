namespace struct_lab_student
{
	public partial class Program
	{
		static void Var9(List<Student> students) 
		{
			WriteData(ProcessData(students), "../data_new.txt");
			Console.WriteLine("\nДані збережено у data_new.txt");
		}

		static void Var10(List<Student> students)
		{
			Console.WriteLine("\nСписок студентів з відмінними оцінками з фізики:");
			foreach (var student in Filter(students, IsTalentedPhysician))
				Console.WriteLine($"{student.surName} {student.firstName} {student.patronymic} {EvalAverage(student):0.0} {student.scholarship}");
		}

		static void Var24(List<Student> students)
		{
			Console.WriteLine("\nСписок студентів, які народились влітку:");
			var summer_kids = Filter(students, IsSummer);
			foreach (var dude in summer_kids)
				Console.WriteLine($"{dude.surName} {dude.firstName} {EvalAverage(dude):0.0}");
		}

		static List<Student> ProcessData(List<Student> students)
		{
			List<Student> processedStudents = [];

			foreach (var student in students)
			{
				var newStudent = student;
				processedStudents.Add(newStudent);
				newStudent.sex = (student.sex == 'M' || student.sex == 'Ч') ? 'Ч' : (student.sex == 'F' || student.sex == 'Ж') ? 'Ж' : '?';
			}
			
			return processedStudents;
		}

		static void WriteData(List<Student> students, string filename)
		{
			var max_len = students.Max(s=>s.surName.Length);
			using (StreamWriter writer = new(filename)) {
				foreach (var student in students)
				{
					writer.WriteLine($"{student.surName.PadRight(max_len+2)} {student.firstName.PadRight(max_len+2)} {student.patronymic.PadRight(max_len+2)} " +
									$"{student.sex,-3} {student.dateOfBirth,-12} {student.Marks[0],-3} {student.Marks[1],-3} {student.Marks[2],-3} " +
									$"{student.scholarship}");
				}
			}
		}
		
		public static IEnumerable<Student> Filter(List<Student> students, Func<Student, bool> Condition)
		{
			return students.Where(Condition);
		}

		private static bool IsSummer(Student student)
		{
			int month = int.Parse(student.dateOfBirth[3..5]);
			return month >= 6 && month <= 8;
		}

		private static bool IsTalentedPhysician(Student student)
		{
			return student.Marks[1] == '5';
		}

		public static double EvalAverage(Student student)
		{
			double sum = 0;
			foreach (var c in student.Marks) sum += (c == '-') ? 2 : double.Parse(c.ToString());
			return Math.Round(sum / 3, 1);
		}
	}
}
