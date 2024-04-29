namespace struct_lab_student
{
	public partial class Program
	{
		static void Var9(List<Student> students) { }

		static void Var10(List<Student> students)
		{
			static double CountAverageScore(Student student)
			{
				char[] marks = student.Marks;
				double sum = 0;
				foreach (var c in marks)
				{
					sum += (c == '-') ? 2 : double.Parse(c.ToString());
				}

				return Math.Round(sum / 3, 1);
			}

			static IEnumerable<Student> FilterTalentedPhysicians(List<Student> students)
			{
				return students.Where(student => student.Marks[1] == '5');
			}

			foreach (var student in FilterTalentedPhysicians(students))
			{
				Console.WriteLine($"{student.surName} {student.firstName} {student.patronymic} {CountAverageScore(student):0.0} {student.scholarship}");
			}
		}

		static void Var24(List<Student> students)
		{
			var summer_kids = FilterSummerKids(students);
			foreach (var (dude, avg) in summer_kids.Zip(EvalAverages(summer_kids)))
				Console.WriteLine($"{dude.surName} {dude.firstName} {avg:0.0}");
		}

		public static IEnumerable<Student> FilterSummerKids(List<Student> students)
		{
			return students.Where(student =>
			{
				if (DateTime.TryParseExact(student.dateOfBirth, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None,
					out DateTime date)
					)
				{
					return date.Month >= 6 && date.Month <= 8;
				}
				return false;
			});
		}

		public static List<double> EvalAverages(IEnumerable<Student>? students)
		{
			List<double> averages = [];
			if (students != null)
			{
				foreach (var dude in students)
				{
					int sum = 0;
					for (int i = 0; i < 3; i++) sum += (dude.Marks[i] == '-') ? 2 : dude.Marks[i] - '0';
					averages.Add(sum / 3.0);
				}
			}
			return averages;
		}
	}
}
