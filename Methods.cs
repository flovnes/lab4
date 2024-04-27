namespace struct_lab_student {
	partial class Program {
		static void var9(List<Student> students) {}
		static void var10(List<Student> students) {}
		static void var24(List<Student> students) {
			List<double> averages = new();
			foreach (var dude in students) {
				int[] marks = new int[3];
				int sum = 0;
				foreach (char mark in dude.Marks) {
					for (int i = 0; i < 3; i++)
						marks[i] = (mark == '-') ? 2 : mark - '0';
				}
				for (int i = 0; i < 3; i++)
					sum += marks[i]; 
				averages.Add(sum / 3.0);
			}
			// wip
			foreach (double n in averages) {Console.WriteLine(n);}
		}
	}
}