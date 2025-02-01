namespace Lab9_1;

public class StudentArray
{
    // Переменные
    private string[] randomNames = new string[]
    {
    "Александр",
    "Сергей",
    "Дмитрий",
    "Елена",
    "Андрей",
    "Анастасия",
    "Анна",
    "Екатерина",
    "Алексей",
    "Наталья"
    };

    public static int numberObjects;
    
    // Свойства
    public Student[] Students { get; set; }
    // Индексатор 
    public Student this[int index]
    {
        get
        {
            if (index < 0 || index >= Students.Length) throw new IndexOutOfRangeException();
            else return Students[index];
        }
        set
        {
            if (index < 0 || index >= Students.Length) throw new IndexOutOfRangeException();
            else Students[index] = value;
        }
    }
    // Конструкторы
    public StudentArray()
    {
        Students = new Student[1];
        Students[0] = new Student("Вася", 19, 8.92);
        numberObjects += 1;
    }

    public StudentArray(int numberStudents)
    {
        Students = new Student[numberStudents];
        Random random = new Random();
        for (int i = 0; i < numberStudents; i++)
        {
            Students[i] = new Student(randomNames[random.Next(0, randomNames.Length)], 
                random.Next(18,23), random.NextDouble()*10);
        }
        numberObjects += 1;
    }

    public StudentArray(params Student[] students)
    {
        Students = new Student[students.Length];
        for (int i = 0; i < students.Length; i++)
        {
            Students[i] = students[i];
        }
        numberObjects += 1;
    }

    public StudentArray(StudentArray students)
    {
        Students = new Student[students.Students.Length];
        for (int i = 0; i < Students.Length; i++)
        {
            Students[i] = students[i];
        }
        numberObjects += 1;
    }
    // Методы класса
    public void PrintStudents()
    {
        for (int i = 0; i < Students.Length; i++)
        {
            Students[i].Info();
        }
    }
    
    // Статические функции
}