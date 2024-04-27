using System.Text;
namespace struct_lab_student {
	public partial class Program {
		static List<Student> ReadData(string fileName) {
			List<Student> students = [];
			try {
				StreamReader reader = new(fileName);
				string line;
				while ((line = reader.ReadLine()) != null) {
					Student student = new(line);
					students.Add(student);
				}
			}
			catch (DirectoryNotFoundException) { Console.WriteLine($"\n\nno input\n\n"); }
			catch (IOException e) { Console.WriteLine($"idk -> {e.Message}"); }
			return students;
		}

		static void RunMenu(List<Student> students) {
			int match;			
			do {
 				Console.WriteLine("Виберіть варіант форматування\nПопов Антон [1]\nВолощук Влад [2]\nДмитро Киба [3]\nНомер > ");
				match = int.Parse(Console.ReadLine());
					switch (match) {
					case 1:
						Var9(students);
						break;
					case 2:
						Var10(students);
						break;
					case 3:
						Var24(students);
						break;
					default:
						Console.WriteLine("Немає такого варіанту.");
						break;
					}
			} while (match != 0);
		}

		static void Main() {
	  		Console.OutputEncoding = UTF8Encoding.UTF8;
			List<Student> students = ReadData("../input.txt");
			RunMenu(students);
		}
	}
}