namespace struct_lab_student
{
	public partial class Program
	{
		static void Var9(List<Student> students) 
		{
			WriteData(ProcessData(students), "data_new.txt");
			Console.WriteLine("Дані були успішно записані у файл data_new.txt");
		}

		static void Var10(List<Student> students)
		{
			foreach (var student in Filter(students, IsTalentedPhysician))
				Console.WriteLine($"{student.surName} {student.firstName} {student.patronymic} {EvalAverage(student):0.0} {student.scholarship}");
		}

		static void Var24(List<Student> students)
		{
			var summer_kids = Filter(students, IsSummer);
			foreach (var dude in summer_kids)
				Console.WriteLine($"{dude.surName} {dude.firstName} {EvalAverage(dude)}");
		}

		static List<Student> ProcessData(List<Student> students)
		{
			List<Student> processedStudents = [];

			foreach (var student in students)
			{
				char sex = student.sex;
				if (sex == 'M' || sex == 'м' || sex == 'Ч')
					sex = 'Ч';
				else if (sex == 'F' || sex == 'ж' || sex == 'Ж')
					sex = 'Ж';

				Student processedStudent = new()
                {
					surName = student.surName,
					firstName = student.firstName,
					patronymic = student.patronymic,
					sex = sex,
					dateOfBirth = student.dateOfBirth,
					Marks = student.Marks,
					scholarship = student.scholarship
				};

				processedStudents.Add(processedStudent);
			}

			return processedStudents;
		}

		static void WriteData(List<Student> students, string filename)
		{
			try
			{
				StreamWriter writer = new(filename);
				{
					foreach (var student in students)
					{
						writer.WriteLine($"{student.surName,-20} {student.firstName,-20} {student.patronymic,-20} " +
										 $"{student.sex,-5} {student.dateOfBirth,-12} {student.Marks[0],-5} {student.Marks[1],-5} {student.Marks[2],-5} " +
										 $"{student.scholarship}");
					}
				}
			}
			catch (IOException e)
			{
				Console.WriteLine($"Помилка запису у файл: {e.Message}");
			}
		}

		public static IEnumerable<Student> Filter(List<Student> students, Func<Student, bool> Condition)
		{
			return students.Where(Condition);
		}

		private static bool IsSummer(Student student)
		{
			int month = int.Parse(student.dateOfBirth[3..4]);
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
