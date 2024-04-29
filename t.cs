using System;
using System.IO;

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
        public int schoolarship;

        public override  string ToString()
        {
            return surName + " " + firstName + " " + patronymic + " " + dateOfBirth;
        }

        public Student(string line)
        {
            string[] fields = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            surName = fields[0];
            firstName = fields[1];
            patronymic = fields[2];
            sex = char.Parse(fields[3]);
            dateOfBirth = fields[4];
            Marks = new char[] { char.Parse(fields[5]), char.Parse(fields[6]), char.Parse(fields[7]) };
            schoolarship = int.Parse(fields[8]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = ReadData("input.txt");
            ProcessData(students);
            WriteData(students, "data_new.txt");
            Console.WriteLine("Дані були успішно переписані у файл data_new.txt");
        }

        static Student[] ReadData(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            Student[] students = new Student[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                students[i] = new Student(lines[i]);
            }

            return students;
        }

      static void ProcessData(Student[] students)
        {
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i].sex == 'M' || students[i].sex == 'м' || students[i].sex == 'Ч')
            students[i].sex = 'Ч';
            else if (students[i].sex == 'F' || students[i].sex == 'ж' || students[i].sex == 'Ж')
            students[i].sex = 'Ж';
        }
}

        static void WriteData(Student[] students, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.surName,-20} {student.firstName,-20} {student.patronymic,-20} " +
                                     $"{student.sex,-5} {student.dateOfBirth,-12} {student.Marks[0],-5} {student.Marks[1],-5} {student.Marks[2],-5} " +
                                     $"{student.schoolarship}");
                }
            }
        }
    }
}
