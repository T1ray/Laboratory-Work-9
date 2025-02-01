using Lab9_1;

namespace TestProgram;

[TestClass]
public class TestStudentArray
{
    private StudentArray baseStudentArray;
    private StudentArray randomStudentArray;
    private StudentArray studentArrayManual;
    private StudentArray copyStudentArrayManual;

    [TestInitialize]
    public void Initialize()
    {
        baseStudentArray = new StudentArray();
        randomStudentArray = new StudentArray(5);
        studentArrayManual = new StudentArray(
            new Student("Антон", 19, 6.29),
            new Student("Павел", 20, 7.33),
            new Student("Варя", 21, 8.93));
        copyStudentArrayManual = new StudentArray(studentArrayManual);
    }
    
    [TestMethod]
    public void TestBuilder1()
    {
        Student student = baseStudentArray[0];
        Assert.AreEqual("Вася", student.Name);
        Assert.AreEqual(19, student.Age);
        Assert.AreEqual(8.92, student.Gpa, 0.01);
    }

    [TestMethod]
    public void TestBuilder2()
    {
        Assert.AreEqual(5, randomStudentArray.Length);
    }
    
    [TestMethod]
    public void TestBuilder3()
    {
        Assert.AreEqual(3, studentArrayManual.Length);
        Assert.AreEqual("Антон", studentArrayManual[0].Name);
        Assert.AreEqual(19, studentArrayManual[0].Age);
        Assert.AreEqual(6.29, studentArrayManual[0].Gpa, 0.01);
        Assert.AreEqual("Павел", studentArrayManual[1].Name);
        Assert.AreEqual(20, studentArrayManual[1].Age);
        Assert.AreEqual(7.33, studentArrayManual[1].Gpa, 0.01);
        Assert.AreEqual("Варя", studentArrayManual[2].Name);
        Assert.AreEqual(21, studentArrayManual[2].Age);
        Assert.AreEqual(8.93, studentArrayManual[2].Gpa, 0.01);
    }

    [TestMethod]
    public void TestBuilder4()
    {
        Assert.IsTrue(StudentArray.Equals(studentArrayManual, copyStudentArrayManual));
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestIndexer1()
    {
        Student student = studentArrayManual[4];
    }
    
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestIndexer2()
    {
        Student student = studentArrayManual[-1];
    }
}