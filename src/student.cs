namespace struct_lab_student
{
	public struct Student
	{
		public string surName;
		public string firstName;
		public string patronymic;
		public char sex;
		public string dateOfBirth;
		public char[] Marks;
		public int scholarship;
		
		public Student(string line)
		{
			string[] fields = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			surName = fields[0];
			firstName = fields[1];
			patronymic = fields[2];
			sex = char.Parse(fields[3]);
			dateOfBirth = fields[4];
			Marks = [
		//math
		char.Parse(fields[5]),
		//physics
		char.Parse(fields[6]),
		// computer science
		char.Parse(fields[7])
			];
			scholarship = int.Parse(fields[8]);
		}
	}
}
