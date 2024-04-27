namespace struct_lab_student {
	public partial class Program {
		static void Var9(List<Student> students) { }
		static void Var10(List<Student> students) { }
		static void Var24(List<Student> students) {
            List<double> averages = EvalAverages(students);
            foreach (double n in averages) { Console.WriteLine(n); }
        }

        public static List<double> EvalAverages(List<Student> students) {
            List<double> averages = [];
            foreach (var dude in students)
            {
                int[] marks = new int[3];
                int sum = 0;
                foreach (char mark in dude.Marks)
                {
                    for (int i = 0; i < 3; i++)
                        marks[i] = (mark == '-') ? 2 : mark - '0';
                }
                for (int i = 0; i < 3; i++)
                    sum += marks[i];
                averages.Add(sum / 3.0);
            }

            return averages;
        }
    }
}