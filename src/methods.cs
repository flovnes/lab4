namespace struct_lab_student {
	public partial class Program {
		static void Var9(List<Student> students) { }

		static void Var10(List<Student> students) {
            foreach (var student in Filter(students, IsTalentedPhysician))
				Console.WriteLine($"{student.surName} {student.firstName} {student.patronymic} {EvalAverage(student):0.0} {student.scholarship}");
		}

        static void Var24(List<Student> students) {
			var summer_kids = Filter(students, IsSummer);
			foreach (var dude in summer_kids)
				Console.WriteLine($"{dude.surName} {dude.firstName} {EvalAverage(dude)}");
		}

		public static IEnumerable<Student> Filter(List<Student> students, Func<Student, bool> Condition) {
			return students.Where(Condition);
		}

        private static bool IsSummer(Student student) {
            int month = int.Parse(student.dateOfBirth[3..4]);
            return month >= 6 && month <= 8;
        }

        private static bool IsTalentedPhysician(Student student) {
            return student.Marks[1] == '5';
        }

        public static double EvalAverage(Student student) {
            double sum = 0;
            foreach (var c in student.Marks) sum += (c == '-') ? 2 : double.Parse(c.ToString());
            return Math.Round(sum / 3, 1);
		}
	}
}
