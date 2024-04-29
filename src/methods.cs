namespace struct_lab_student {
	public partial class Program {
		static void Var9(List<Student> students) 
		{
			var processedStudents = ProcessData(students);
			WriteData(processedStudents, "data_new.txt");
			Console.WriteLine("Дані були успішно переписані у файл data_new.txt");
		}

		static List<Student> ProcessData(List<Student> students)
		{
			List<Student> processedStudents = new List<Student>();

			foreach (var student in students)
			{
				char sex = student.sex;
				if (sex == 'M' || sex == 'м' || sex == 'Ч')
					sex = 'Ч';
				else if (sex == 'F' || sex == 'ж' || sex == 'Ж')
					sex = 'Ж';

				Student processedStudent = new Student {
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
				using (StreamWriter writer = new StreamWriter(filename))
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
		static void Var10(List<Student> students) { }
		static void Var24(List<Student> students) { }
    }
}