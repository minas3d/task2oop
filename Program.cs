using System.Net.Http.Metrics;
using task2oop;
using static System.Reflection.Metadata.BlobBuilder;
namespace task2oop
{
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> courses { get; set; }
        public Student(int studentid, string name, int age, List<Course> courses)
        {
            StudentId = studentid;
            this.Name = name;
            this.Age = age;
            this.courses = courses;
        }
        public bool Enroll(Course course)
        {
            if (course == null)
            {
                return false;
            }

            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }
            courses.Add(course);
            return true;
        }

        public override string ToString()
        {
            return $"student id is {StudentId}:   the name {Name}:  age {Age} ";
        }

    }
    class Instructor
    {
        public int InstructorId { get; set; }
        public string NameInstructor { get; set; }
        public string Specialization { get; set; }

        public Instructor(int instructorId, string nameInstructor, string specialization)
        {
            InstructorId = instructorId;
            NameInstructor = nameInstructor;
            Specialization = specialization;
        }


        public override string ToString()
        {
            return $"Instructor id is {InstructorId} : the name {NameInstructor} :  specialization {Specialization} ";
        }
    }
    class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor instructor { get; set; }

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            this.instructor = instructor;
        }
        public override string ToString()
        {
            return $"Course id is {CourseId} : the title {Title} :  instructor {instructor} ";
        }
    }

}
     class StudentManager
{
    public List<Student> Students { get; set; }
    public List<Course> Courses { get; set; }
    public List<Instructor> Instructors { get; set; }
    public StudentManager(List<Student> students, List<Course> courses, List<Instructor> instructors)
    {
        Students = students;
        Courses = courses;
        Instructors = instructors;
    }


    public bool AddStudent(Student student)
    {
        foreach (var s in Students)
        {
            if (s.StudentId == student.StudentId)
            {
                return false;

            }
        }
        Students.Add(student);
        return true;
    }
    public bool AddCourse(Course course)
    {
        foreach (var c in Courses)
        {
            if (c.CourseId == course.CourseId)
            {
                return false;

            }

        }
        Courses.Add(course);
        return true;
    }
    public bool AddInstructor(Instructor instructor)
    {


        foreach (var i in Instructors)
        {
            if (i.InstructorId == instructor.InstructorId)
            {
                return false;

            }

        }
        Instructors.Add(instructor);
        return true;
    }
    public Student FindStudent(int studentId)
    {
        foreach (var s in Students)
        {
            if (s.StudentId == studentId)
            {
                return s;

            }
        }
        return null;
    }
    public Course FindCourse(int courseId)
    {
        foreach (var c in Courses)
        {
            if (c.CourseId == courseId)
            {
                return c;

            }

        }
        return null;
    }
    public Instructor FindInstructor(int instructorId)
    {
        foreach (var i in Instructors)
        {
            if (i.InstructorId == instructorId)
            {
                return i;

            }

        }
        return null;
    }
    public bool EnrollStudentInCourse(int studentId, int courseId)
    {
        Student student = FindStudent(studentId);
        Course course = FindCourse(courseId);
        if (student == null || course == null)
        {
            return false;
        }
        foreach (var c in student.courses)
        {
            if (c.CourseId == courseId)
                return false;
        }
        return student.Enroll(course);
    }

}
internal class Program
{
    static void Main(string[] args)
    {
        StudentManager managschool = new StudentManager(new List<Student>(), new List<Course>(), new List<Instructor>());
        while (true)
        {
            Console.WriteLine("Press 'A' to add Student");
            Console.WriteLine("Press 'B' to add Instructor");
            Console.WriteLine("Press 'C' to add Course");
            Console.WriteLine("Press 'E' toEnroll Student in Course");
            Console.WriteLine("Press 'S' to Show All Students");
            Console.WriteLine("Press 'O' to Show All Courses");
            Console.WriteLine("Press 'I' to Show All Instructors");
            Console.WriteLine("Press 'F' to Find the student by id or name");
            Console.WriteLine("Press 'R' to Find the Instructors by id or name");
            Console.WriteLine("Press 'U' to Find the course by id or name");
            Console.WriteLine("Press 'Q' to Exit");
            Console.WriteLine("Please choose ");
            char c = Convert.ToChar(Console.ReadLine());

            switch (c)
            {
                case 'A':
                    Console.WriteLine(" eter id  ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" eter name  ");
                    string y = Console.ReadLine();
                    Console.WriteLine(" eter age  ");
                    int z = Convert.ToInt32(Console.ReadLine());

                    Student stu = new Student(x, y, z, new List<Course>());
                    managschool.AddStudent(stu);
                    break;

                case 'B':
                    Console.WriteLine(" enter id  ");
                    int instid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" enter name  ");
                    string nameist = Console.ReadLine();
                    Console.WriteLine(" enter  Specialization");
                    string instsspi = Console.ReadLine();
                    Instructor inst = new Instructor(instid, nameist, instsspi);
                    managschool.AddInstructor(inst);
                    break;

                case 'C':
                    Console.WriteLine("Enter course ID: ");
                    int cid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter course name: ");
                    string cname = Console.ReadLine();
                    Console.WriteLine("Enter instructor ID: ");
                    int iid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter instructor name: ");
                    string iname = Console.ReadLine();
                    Console.WriteLine("Enter instructor specialization: ");
                    string ispi = Console.ReadLine();
                    Course co = new Course(cid, cname, new Instructor(iid, iname, ispi));
                    managschool.AddCourse(co);
                    break;

                case 'E':
                    Console.WriteLine("Enter Student ID to enroll: ");
                    int stId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Course ID to enroll in: ");
                    int crId = Convert.ToInt32(Console.ReadLine());

                    bool enr = managschool.EnrollStudentInCourse(stId, crId);
                    if (enr == false )
                    {
                        Console.WriteLine("Failed to enroll (student or course not found, or already enrolled).");
                        break;
                    }
                    Console.WriteLine("Successfully enrolled.");
                    break;

                case 'S':

                    for (int i = 0; i < managschool.Students.Count; i++)
                    {
                        Console.WriteLine(managschool.Students[i]);
                    }
                    break;

                case 'O':
                    for (int i = 0; i < managschool.Courses.Count; i++)
                    {
                        Console.WriteLine(managschool.Courses[i]);
                    }

                    break;

                case 'I':
                    for (int i = 0; i < managschool.Instructors.Count; i++)
                    {
                        Console.WriteLine(managschool.Instructors[i]);
                    }

                    break;

                case 'F':
                    Console.WriteLine("Enter ID to search student ");
                    int stuid = Convert.ToInt32(Console.ReadLine());
                  Student stud = managschool.FindStudent(stuid);
                    if (stud == null)
                    {
                        Console.WriteLine("not found ");
                        break;
                    }
                    Console.WriteLine("found ");
                    break;

                case 'R':
                    Console.WriteLine("Enter ID to search Instructors");
                    int insid = Convert.ToInt32(Console.ReadLine());
                    Instructor instr = managschool.FindInstructor(insid);
                    if (instr == null)
                    {
                        Console.WriteLine("not found ");
                        break;
                    }
                    Console.WriteLine("found ");
                    break;

                case 'U':
                    Console.WriteLine("Enter ID to search course");
                    int couid = Convert.ToInt32(Console.ReadLine());
                    Course cors = managschool.FindCourse(couid);
                    if (cors == null)
                    {
                        Console.WriteLine("not found ");
                        break;
                    }
                    Console.WriteLine("found ");
                    break;

                default:
                    Console.WriteLine("This operation is not available");
                    Console.WriteLine("==============================================================");
                    break;

            }
            if (c == 'Q')
            {
                Console.WriteLine("ok godby");
                break;
            }
        }
    }
}













