using Xunit;
using struct_lab_student;

namespace student_tests {
	public partial class Tests {
		[Fact]
		public static void Student_EvalAverages_ReturnDoubleList() {
			try 
			{
				Student a = new("Прізвище1 Ім'я1 По-батькові1 F 02.02.2000 4 4 - 1234");
				Student b = new("Прізвище2 Ім'я2 По-батькові2 F 02.02.2000 4 - 2 1234");
				Student c = new("Прізвище3 Ім'я3 По-батькові3 F 03.03.2000 3 - - 2413");
				List<double> avgs = Program.EvalAverages([a,b,c]);
				bool fail = false;
				foreach (double avg in avgs) {
					if (avg < 2.0) {
						fail = true;
						break;
					}
				}
				Console.WriteLine(fail ? "Student_EvalAverages_ReturnDoubleList epic fail!!!" : "cool!");
			}
			catch (Exception e) 
			{
				Console.WriteLine($"\n\n uhoh somethin dun gone wrong! \n {e} \n\n");
			}
		}
		[Fact]
		public static void Student_EvalAverages_ReturnDoubleList() {
			try 
			{
				Student a = new("Прізвище1 Ім'я1 По-батькові1 F 02.02.2000 4 4 - 1234");
				Student b = new("Прізвище2 Ім'я2 По-батькові2 F 02.02.2000 4 - 2 1234");
				Student c = new("Прізвище3 Ім'я3 По-батькові3 F 03.03.2000 3 - - 2413");
				List<double> avgs = Program.EvalAverages([a,b,c]);
				bool fail = false;
				foreach (double avg in avgs) {
					if (avg < 2.0) {
						fail = true;
						break;
					}
				}
				Console.WriteLine(fail ? "Student_EvalAverages_ReturnDoubleList epic fail!!!" : "cool!");
			}
			catch (Exception e) 
			{
				Console.WriteLine($"\n\n uhoh somethin dun gone wrong! \n {e} \n\n");
			
	}
}