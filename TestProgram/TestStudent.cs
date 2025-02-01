using Lab9_1;

namespace TestProgram
{
    
    [TestClass]
    public sealed class TestStudent
    {
        private Student baseStudent;
        private Student schoolStudent;
        private Student firstCourseGoodMarksStudent;
        private Student firstCourseBadMarksStudent;
        private Student secondCourseGoodMarksStudent;
        private Student secondCourseBadMarksStudent;
        private Student brokenGpaStudent2;
        private Student brokenGpaStudent1;

        (string, string) StudentComparison(Student student1, Student student2) => Student.CompareStudents(student1, student2);
        (string, string) StaticStudentComparison(Student student1, Student student2) => student1.CompareStudents(student2);
        
        [TestInitialize]
        public void InitializeStudent()
        {
            baseStudent = new Student();
            schoolStudent = new Student("Владимир", 15, 8);
            brokenGpaStudent1 = new Student("Валерия", 19, -2.26);
            brokenGpaStudent2 = new Student("Афанасий", 19, 12.79);
            firstCourseGoodMarksStudent = new Student("Ольга", 18, 8.39);
            firstCourseBadMarksStudent = new Student("артем", 18, 4.69);
            secondCourseGoodMarksStudent = new Student("данил", 19, 8.39);
            secondCourseBadMarksStudent = new Student("Татьяна", 19, 3.94);
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("Вася", baseStudent.Name);
            Assert.AreEqual(18, baseStudent.Age);
            Assert.AreEqual(0, baseStudent.Gpa);
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(-1, schoolStudent.Age);
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(-1, brokenGpaStudent1.Gpa);
        }
        
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(-1, brokenGpaStudent2.Gpa);
        }

        [TestMethod]
        public void TestComparsion1()
        {
            (string, string) comparison = StudentComparison(firstCourseGoodMarksStudent, firstCourseBadMarksStudent);
            Assert.AreEqual("ровесник", comparison.Item1);
            Assert.AreEqual("выше", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion2()
        {
            (string, string) comparison = StudentComparison(firstCourseBadMarksStudent, firstCourseGoodMarksStudent);
            Assert.AreEqual(comparison.Item1, "ровесник");
            Assert.AreEqual(comparison.Item2, "ниже");
        }
        
        [TestMethod]
        public void TestComparsion3()
        {
            (string, string) comparison = StudentComparison(firstCourseGoodMarksStudent, secondCourseGoodMarksStudent);
            Assert.AreEqual("младше", comparison.Item1);
            Assert.AreEqual("равен", comparison.Item2);
        }
        
        [TestMethod]
        public void TestComparsion4()
        {
            (string, string) comparison = StudentComparison(secondCourseGoodMarksStudent, firstCourseGoodMarksStudent);
            Assert.AreEqual("старше", comparison.Item1);
            Assert.AreEqual("равен", comparison.Item2);
        }
        
        [TestMethod]
        public void TestComparsion5()
        {
            (string, string) comparison =
                StaticStudentComparison(firstCourseGoodMarksStudent, firstCourseBadMarksStudent);
            Assert.AreEqual("ровесник", comparison.Item1);
            Assert.AreEqual("выше", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion6()
        {
            (string, string) comparison = StaticStudentComparison(firstCourseBadMarksStudent, firstCourseGoodMarksStudent);
            Assert.AreEqual(comparison.Item1, "ровесник");
            Assert.AreEqual(comparison.Item2, "ниже");
        }
        
        [TestMethod]
        public void TestComparsion7()
        {
            (string, string) comparison = StaticStudentComparison(firstCourseGoodMarksStudent, secondCourseGoodMarksStudent);
            Assert.AreEqual("младше", comparison.Item1);
            Assert.AreEqual("равен", comparison.Item2);
        }
        
        [TestMethod]
        public void TestComparsion8()
        {
            (string, string) comparison = StaticStudentComparison(secondCourseGoodMarksStudent, firstCourseGoodMarksStudent);
            Assert.AreEqual("старше", comparison.Item1);
            Assert.AreEqual("равен", comparison.Item2);
        }

        [TestMethod]
        public void TestOverloadedOperations1()
        {
            firstCourseBadMarksStudent = ~firstCourseBadMarksStudent;
            Assert.AreEqual("Артем", firstCourseBadMarksStudent.Name);
        }
        
        [TestMethod]
        public void TestOverloadedOperations2()
        {
            secondCourseBadMarksStudent++;
            Assert.AreEqual(20, secondCourseBadMarksStudent.Age);
        }
        
        [TestMethod]
        public void TestOverloadedOperations3()
        {
            int course = (int)secondCourseBadMarksStudent;
            Assert.AreEqual(2, course);
        }
        
        [TestMethod]
        public void TestOverloadedOperations4()
        {
            int course = (int)schoolStudent;
            Assert.AreEqual(-1, course);
        }
        
        [TestMethod]
        public void TestOverloadedOperations5()
        {
            bool isGoodMarks = secondCourseGoodMarksStudent;
            Assert.AreEqual(true, isGoodMarks);
        }
        
        [TestMethod]
        public void TestOverloadedOperations6()
        {
            bool isGoodMarks = secondCourseBadMarksStudent;
            Assert.AreEqual(false, isGoodMarks);
        }
        
        [TestMethod]
        public void TestOverloadedOperations7()
        {
            secondCourseGoodMarksStudent -= 4;
            Assert.AreEqual(4.39, secondCourseGoodMarksStudent.Gpa, 0.01);
        }
        
        [TestMethod]
        public void TestOverloadedOperations8()
        {
            baseStudent %= "Петр";
            Assert.AreEqual("Петр", baseStudent.Name);
        }

        [TestMethod]
        public void TestOverloadedOperations9()
        {
            try
            {
                secondCourseGoodMarksStudent -= 10;
            }
            catch (Exception e)
            {
                Assert.AreEqual("Gpa не может стать отрицательным", e.Message);
            }
        }

        [TestMethod]
        public void TestOverloadedOperations10()
        {
            StringWriter output = new StringWriter();
            Console.SetOut(output);
            secondCourseBadMarksStudent.Info();
            Assert.AreEqual("Имя: Татьяна, Возраст:19, gpa: 3,94\r\n", output.ToString());
        }
    }
}
