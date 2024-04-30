
namespace struct_lab_student
{
	public partial class Program
	{
		public static void Var9(List<Student> students)
		{
			WriteData(ProcessData(students), "../data_new.txt");
			Console.WriteLine("\nДані збережено у data_new.txt");
		}

		public static void Var10(List<Student> students)
		{
			Console.WriteLine("\nСписок студентів з відмінними оцінками з фізики:");
			foreach (var student in students.Where(IsTalentedPhysician))
				Console.WriteLine($"{student.surName} {student.firstName} {student.patronymic} {Average(student):0.0} {student.scholarship}");
		}


		public static void Var24(List<Student> students)
		{
			Console.WriteLine("\nСписок студентів, які народились влітку:");
			var summer_kids = students.Where(IsBornInSummer);
			foreach (var student in summer_kids)
				Console.WriteLine($"\r{student.surName} {student.firstName} {Average(student):0.0}");
		}
		
		public static void Var26(List<Student> students)
		{
			var maleStudents = students.Where(s => IsMale(s));
			
			if (!maleStudents.Any())
			{
				Console.WriteLine("Немає студентів чоловічої статі.");
				return;
			}
			
			double maleSum = 0.0;
			
			foreach (var student in maleStudents)
				maleSum += Average(student);
		
			double maleAverage = maleSum / maleStudents.Count();
			
			var result = students.Where(s => Average(s) > maleAverage && IsFemale(s));
			
			if (!result.Any())
			{
				Console.WriteLine("Немає студенток, які задовольняють умову.");
				return;
			}
			
			foreach (var student in result)
				Console.WriteLine($"\r{student.surName} {student.firstName} {student.patronymic}");
		}

		public static void Var27(List<Student> students)
		{
			var studentsByDayAndYear = GroupStudentsByDayAndYear(students);
			var studentsByDayOnly = GroupStudentsByDayOnly(students);

			Console.WriteLine("\nСтуденти, народжені в один день та рік:");
			foreach (var group in studentsByDayAndYear)
			{
				if (group.Students.Count > 1) 
				{
					Console.WriteLine($"Дата: {group.Date}");
					foreach (var student in group.Students)
					{
						Console.WriteLine($"\t{student.surName} {student.firstName} {student.patronymic}");
					}
				}
			}

			Console.WriteLine("\nСтуденти, народжені в один день (різні роки):");
			foreach (var group in studentsByDayOnly)
			{
				if (group.Students.Count > 1) 
				{
					Console.WriteLine($"Дата: {group.Day}");
					foreach (var student in group.Students)
					{
						Console.WriteLine($"\t{student.surName} {student.firstName} {student.patronymic} ({student.dateOfBirth[6..]})");
					}
				}
			}
		}

		private static List<(string Date, List<Student> Students)> GroupStudentsByDayAndYear(List<Student> students)
		{
			var groups = new List<(string Date, List<Student> Students)>();

			var groupedStudents = students.GroupBy(s => s.dateOfBirth[..2] + " " + s.dateOfBirth[6..]); // Concatenate day and year

			foreach (var group in groupedStudents)
			{
				groups.Add((group.Key, group.ToList()));
			}

			return groups;
		}


		private static List<(string Day, List<Student> Students)> GroupStudentsByDayOnly(List<Student> students)
		{
			var groups = new List<(string Day, List<Student> Students)>();

			var groupedStudents = students.GroupBy(s => s.dateOfBirth[..2]); // Extract day

			foreach (var group in groupedStudents)
			{
				groups.Add((group.Key, group.ToList()));
			}

			return groups;
		}

		private static List<Student> ProcessData(List<Student> students)
		{
			List<Student> processedStudents = [];
	  
			foreach (var student in students)
			{
				var newStudent = student;
				processedStudents.Add(newStudent);
				newStudent.sex = IsMale(student) ? 'Ч' : IsFemale(student) ? 'Ж' : '?';
			}

			return processedStudents;
		}

		private static void WriteData(List<Student> students, string filename)
		{
			var max_len = students.Max(s => s.surName.Length);
			using (StreamWriter writer = new(filename))
			{
				foreach (var student in students)
				{
					writer.WriteLine($"{student.surName.PadRight(max_len + 2)} {student.firstName.PadRight(max_len + 2)} {student.patronymic.PadRight(max_len + 2)} " +
									$"{student.sex,-3} {student.dateOfBirth,-12} {student.Marks[0],-3} {student.Marks[1],-3} {student.Marks[2],-3} " +
									$"{student.scholarship}");
				}
			}
		}

		public static bool IsBornInSummer(Student student)
		{
			int month = int.Parse(student.dateOfBirth[3..5]);
			return month >= 6 && month <= 8;
		}

		public static bool IsTalentedPhysician(Student student)
		{
			return student.Marks[1] == '5';
		}

		public static double Average(Student student)
		{
			double sum = 0;
			foreach (var c in student.Marks) sum += (c == '-') ? 2 : double.Parse(c.ToString());
			return Math.Round(sum / 3, 1);
		}

			private static bool IsFemale(Student student)
		{
			return student.sex == 'F' || student.sex == 'Ж';
		}

		private static bool IsMale(Student student)
		{
			return student.sex == 'M' || student.sex == 'Ч';
		}
	}
}
