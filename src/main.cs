namespace struct_lab_student
{
	public partial class Program
	{
		static List<Student> ReadData(string fileName)
		{
			List<Student> students = [];
			try
			{
				StreamReader reader = new(fileName);
				string? line;
				while ((line = reader.ReadLine()) != null)
					students.Add(new(line));
			}
			catch (IOException e) { Console.WriteLine($"idk -> {e.Message}"); }
			return students;
		}

		static void RunMenu(List<Student> students)
		{
			int match;
			do
			{
				Console.Write("\n<- Вихід [0]\nВиконати варіант 9 студента Попов Антон [1]\nВиконати варіант 10 студента Дмитро Киба [2]\nВиконати варіант 24 студента Волощук Влад [3]\nНомер > ");
				string? s = Console.ReadLine();
				if (int.TryParse(s, out match))
				{
					switch (match)
					{
						case 1:
							Var9(students);
							break;
						case 2:
							Var10(students);
							break;
						case 3:
							Var24(students);
							break;
						case 0:
							break;
						default:
							Console.WriteLine("Немає такого варіанту.");
				            	break;
					}
				}
			} while (match != 0);
		}
    
		static void Main()
		{
			Console.OutputEncoding = UTF8Encoding.UTF8;
			List<Student> students = ReadData("../input.txt");
			RunMenu(students);
		}
	}
}
