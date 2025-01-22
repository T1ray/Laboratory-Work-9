namespace Lab9_1
{
    internal class Program
    {
        static void TextSeparator() => Console.WriteLine("-----------------------------------");
        static void PrintStudentComparassion(Student firstStudent, Student secondStudent, (string, string) comparassion)
        {
            string ageComprassion, gpaComrassion;
            (ageComprassion, gpaComrassion) = comparassion;
            Console.WriteLine($"{firstStudent.Name} {ageComprassion} {secondStudent.Name}");
            Console.WriteLine($"gpa {firstStudent.Name} {gpaComrassion} {secondStudent.Name}");
        }
        static void Main(string[] args)
        {
            Student student = new Student();
            Student studentPetya = new Student("петя", 19, 8.57);
            Student studentKatya = new Student("Катя", 18, 9.27);
            Student test1 = new Student("Тест1", 10, 1);
            Student test2 = new Student("Тест2", 19, 9);
            
            Console.WriteLine(Student.numberStudents);
            student.Info();
            studentPetya.Info();
            studentKatya.Info();
            test1.Info();
            test2.Info();
            
            TextSeparator();
            studentPetya = ~studentPetya;
            studentPetya++;
            studentPetya.Info();
            
            TextSeparator();
            (string, string) comparassion1 = studentPetya.CompareStudents(studentKatya);
            PrintStudentComparassion(studentPetya, studentKatya, comparassion1);
            
            (string, string) comprassion2 = Student.CompareStudents(student, test2);
            PrintStudentComparassion(student, test2, comprassion2);
            
            TextSeparator();
            studentPetya = studentPetya - 8.243;
            studentPetya.Info();
            
            studentPetya = studentPetya - 1;
            studentPetya.Info();

            studentPetya = studentPetya % "Гриша";
            studentPetya.Info();
        }
    }
}