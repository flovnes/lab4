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
				double n = marks.Length;
				foreach (var c in marks)
				{
					if (c == '-')
					{
						sum += 2;
					}
					else { sum += double.Parse(c.ToString()); }

				}

				return sum / n;
			}
			foreach (var student in students)
			{
				if (student.Marks[1] == '5')
				{
					Console.WriteLine($"{student.surName} {student.firstName} {student.patronymic} {CountAverageScore(student)} {student.scholarship}");
				}
			};
		}
		static void Var24(List<Student> students) { }
	}
}
