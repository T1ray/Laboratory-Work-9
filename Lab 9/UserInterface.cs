namespace Lab9_1;

public class UserInterface
{
    public static void TextSeparator() => Console.WriteLine("-----------------------------------");
        public static void PrintStudentComparassion(Student firstStudent, Student secondStudent, (string, string) comparassion)
        {
            string ageComprassion, gpaComrassion;
            (ageComprassion, gpaComrassion) = comparassion;
            Console.WriteLine($"{firstStudent.Name} {ageComprassion} {secondStudent.Name}");
            Console.WriteLine($"gpa {firstStudent.Name} {gpaComrassion} {secondStudent.Name}");
        }

        public static void PrintStudentCourse(Student student)
        {
            int courseNumber = (int) student;
            Console.WriteLine($"{student.Name} на {courseNumber} курсе");
        }

        public static void PrintStudentProgressIsGood(Student student)
        {
            bool isGoodProgress = student;
            Console.WriteLine(isGoodProgress ? 
                $"{student.Name} имеет хорошую успеваемость!" : 
                $"{student.Name} имеет плохую успеваемость!");
        }
        
        public static string OldestHonorsStudent(StudentArray students)
        {
            int oldestStudentIndex = -1;
            int currentOldestStudentIndex = 0;
            for (int curIndex = 0; curIndex < students.Students.Length; curIndex++)
            {
                if (students.Students[curIndex].Age > students.Students[currentOldestStudentIndex].Age && 
                    students.Students[curIndex].Gpa > 8)
                {
                    oldestStudentIndex = curIndex;
                }
            }
            return oldestStudentIndex > -1 ? students.Students[oldestStudentIndex].Name : "-1";
        }

        public static void Part1()
        {
            TextSeparator();
            Student student = new Student();
            Student studentPetya = new Student("петя", 19, 8.57);
            Student studentKatya = new Student("Катя", 18, 9.27);
            Student studentKostya = new Student("Костя", 20, 5.23);
            Student test1 = new Student("Тест1", 10, 1);
            Student test2 = new Student("Тест2", 19, 11);
            
            Console.WriteLine("Конструктор без параметров");
            student.Info();
            Console.WriteLine("Конструкторы с параметрами");
            studentPetya.Info();
            studentKatya.Info();
            Console.WriteLine("Ошибки при создании объекта класса");
            test1.Info();
            test2.Info();
            Console.WriteLine($"Количество созданных объектов {Student.numberStudents}");
            
            (string, string) comparassion1 = studentPetya.CompareStudents(studentKatya);
            PrintStudentComparassion(studentPetya, studentKatya, comparassion1);
            (string, string) comprassion2 = Student.CompareStudents(student, studentKostya);
            PrintStudentComparassion(student, studentKostya, comprassion2);
        }

        public static void Part2()
        {
            TextSeparator();
            Student student = new Student();
            Student studentPetya = new Student("петя", 19, 8.57);
            Student studentKatya = new Student("Катя", 18, 9.27);
            Student studentKostya = new Student("Костя", 20, 5.23);
            
            Console.WriteLine("Созданные студенты");
            student.Info();
            studentPetya.Info();
            studentKatya.Info();
            studentKostya.Info();

            Console.WriteLine("Изменение первой буквы имени на заглавную:");
            studentPetya = ~studentPetya;
            studentPetya.Info();

            Console.WriteLine("Увеличение возраста на 1 год");
            studentPetya++;
            studentPetya.Info();
            
            PrintStudentCourse(studentPetya);
            PrintStudentCourse(studentKatya);
            
            PrintStudentProgressIsGood(studentPetya);
            PrintStudentProgressIsGood(studentKatya);

            Console.WriteLine("Попытка убавить оценку");
            studentPetya = studentPetya - 8.243;
            studentPetya.Info();
            
            Console.WriteLine("Попытка убавить оценку");
            try
            {
                studentPetya = studentPetya - 1;
                studentPetya.Info();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Изменение имени студента");
            studentPetya = studentPetya % "Гриша";
            studentPetya.Info();
        }

        public static void Test()
        {
            Student schoolStudent = new Student("Владимир", 15, 8);
            int course = (int)schoolStudent;
            Console.WriteLine(course);
        }

        public static void Part3()
        {
            TextSeparator();
            Console.WriteLine("Создание рандомной коллекции студентов");
            StudentArray studentArray = new StudentArray(5);
            studentArray.PrintStudents();
            
            TextSeparator();
            Console.WriteLine("Изменение 4-го студента на стандартного студента");
            studentArray[3] = new Student();
            studentArray.PrintStudents();
            
            TextSeparator();
            StudentArray studentArray1 = new StudentArray(studentArray);
            studentArray[0] = new Student();
            studentArray.PrintStudents();
            Console.WriteLine("---");
            Console.WriteLine("Созданная глубокая копия предыдущего класса до его изменения");
            studentArray1.PrintStudents();
            TextSeparator();
            
            Console.WriteLine("Создание коллекции вручную");
            StudentArray studentArray2 = new StudentArray(
                new Student("Антон", 19, 6.29),
                new Student("Павел", 20, 7.33),
                new Student("Варя", 21, 8.93));
            studentArray2.PrintStudents();
            
            TextSeparator();
            Console.WriteLine($"Получение студента с индесом 1 из коллекции:");
            studentArray2[1].Info();
            Console.WriteLine("---");
            Console.WriteLine("Запись нового студента по индексу 1");
            studentArray2[1] = new Student("София", 19, 7.21);
            studentArray2.PrintStudents();
            Console.WriteLine("---");
            Console.WriteLine("Получение значения коллекции, выходящего за пределы длины коллекции");
            try
            {
                Console.WriteLine(studentArray2[-1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Не получилось взять значение с индексом -1 из коллекции");
            }
            try
            {
                Console.WriteLine(studentArray2[5]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Не получилось взять значение с индексом 5 из коллекции");
            }
            Console.WriteLine("---");
            Console.WriteLine("Запись элемента в коллекцию по индексу, выходящего за пределы длины коллекции");
            try
            {
                studentArray2[-1] = studentArray2[1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Не получилось записать значение по индексу -1 в коллекции");
            }
            Console.WriteLine("---");
            Console.WriteLine($"Количество объектов коллекции: {StudentArray.numberObjects}");
            
            TextSeparator();
            Console.WriteLine("Выполнение задания 3-ей часть");
            studentArray.PrintStudents();
            Console.WriteLine("Поиск студента с наибольшим возрастом и gpa >= 8 в первой коллекции");
            string studentArrayHonor = OldestHonorsStudent(studentArray);
            Console.WriteLine(studentArrayHonor != "-1" ?
                $"Студента с наибольшим возрастом и gpa >= 8 в первой коллекции: {studentArrayHonor}" :
                "Не найден студент с gpa >= 8");
            
            Console.WriteLine("---");
            studentArray1.PrintStudents();
            Console.WriteLine("Поиск студента с наибольшим возрастом и gpa >= 8 во второй коллекции");
            string studentArrayHonor1 = OldestHonorsStudent(studentArray1);
            Console.WriteLine(studentArrayHonor1 != "-1" ?
                $"Студента с наибольшим возрастом и gpa >= 8 во второй коллекции: {studentArrayHonor1}" :
                "Не найден студент с gpa >= 8");
            
            Console.WriteLine("---");
            studentArray2.PrintStudents();
            Console.WriteLine("Поиск студента с наибольшим возрастом и gpa >= 8 во второй коллекции");
            string studentArrayHonor2 = OldestHonorsStudent(studentArray2);
            Console.WriteLine(studentArrayHonor2 != "-1" ?
                $"Студента с наибольшим возрастом и gpa >= 8 во второй коллекции: {studentArrayHonor2}" :
                "Не найден студент с gpa >= 8");
        }
}