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

        static void PrintStudentCourse(Student student)
        {
            int courseNumber = (int) student;
            Console.WriteLine($"{student.Name} на {courseNumber} курсе");
        }

        static void PrintStudentProgressIsGood(Student student)
        {
            bool isGoodProgress = student;
            Console.WriteLine(isGoodProgress ? 
                $"{student.Name} имеет хорошую успеваемость!" : 
                $"{student.Name} имеет плохую успеваемость!");
        }

        static void Part1()
        {
            TextSeparator();
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
        }

        static void Part2()
        {
            TextSeparator();
            Student student = new Student();
            Student studentPetya = new Student("петя", 19, 8.57);
            Student studentKatya = new Student("Катя", 18, 9.27);
            Student test1 = new Student("Тест1", 10, 1);
            Student test2 = new Student("Тест2", 19, 9);
            
            studentPetya = ~studentPetya;
            studentPetya++;
            studentPetya.Info();
            
            (string, string) comparassion1 = studentPetya.CompareStudents(studentKatya);
            PrintStudentComparassion(studentPetya, studentKatya, comparassion1);
            (string, string) comprassion2 = Student.CompareStudents(student, test2);
            PrintStudentComparassion(student, test2, comprassion2);
            
            PrintStudentCourse(studentPetya);
            PrintStudentCourse(studentKatya);
            
            PrintStudentProgressIsGood(studentPetya);
            PrintStudentProgressIsGood(studentKatya);
            
            studentPetya = studentPetya - 8.243;
            studentPetya.Info();
            
            studentPetya = studentPetya - 1;
            studentPetya.Info();

            studentPetya = studentPetya % "Гриша";
            studentPetya.Info();
        }

        static void Part3()
        {
            TextSeparator();
            StudentArray studentArray = new StudentArray(5);
            studentArray.PrintStudents();
            TextSeparator();
            studentArray[3] = new Student();
            studentArray.PrintStudents();
            TextSeparator();
            StudentArray studentArray1 = new StudentArray(studentArray);
            studentArray[0] = new Student();
            studentArray.PrintStudents();
            TextSeparator();
            studentArray1.PrintStudents();
            TextSeparator();    
            StudentArray studentArray2 = new StudentArray(
                new Student("Антон", 19, 6.29),
                new Student("Павел", 20, 7.33),
                new Student("Варя", 21, 8.93));
            studentArray2.PrintStudents();
        }
        static void Main(string[] args)
        {
            string input;
            while (true)
            {
                Console.WriteLine("Выберите часть, которую хотите вывести\n" +
                                  "1. Часть 1\n" +
                                  "2. Часть 2\n" +
                                  "3. Часть 3");
                input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                    {
                        Part1();
                        break;
                    }
                    case "2":
                    {
                        Part2();
                        break;
                    }
                    case "3":
                    {
                        Part3();
                        break;
                    } 
                }
                TextSeparator();
            }
        }
    }
}