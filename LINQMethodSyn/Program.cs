using System;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace LINQMethod {
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double Tuition { get; set; }
    }
    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }
    }
    public class StudentGPA
    {
        public int StudentID { get; set; }
        public double GPA { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 2, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 5, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 6, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 7, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };
            // Student GPA Collection
            IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
            IList<StudentClubs> studentClubList = new List<StudentClubs>() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
        };

            //LINQ

            //!! Couldn't get the first two to work properly :/
            /*var groupedGPA = from s in studentGPAList
                             orderby s.GPA
                             group s by s.GPA;
            foreach (var s in groupedGPA)
            {
                Console.WriteLine(s.StudentID);
            }
            Console.WriteLine("Here are the students' ID grouped by GPA");
            Console.WriteLine(" ");


            var groupedClub = from s in studentClubList
                             orderby s.ClubName
                             group s by s.ClubName;
            foreach (var s in groupedClub)
            {
                Console.WriteLine(s.StudentID);
            }
            Console.WriteLine("Here are the students' ID grouped by Club");
            Console.WriteLine(" ");*/


            var countGPA = studentGPAList.Count(s => s.GPA >= 2.5 && s.GPA<= 4.0);
            Console.WriteLine("Here's the number of students with a GPA of 2.5-4.0: " + countGPA);
            Console.WriteLine(" ");



            var avgNum = studentList.Average(s => s.Tuition);
            Console.WriteLine("Here's the average tuition: " + avgNum);
            Console.WriteLine(" ");

            var innerJoin = studentList.Join(studentGPAList,
                                student => student.StudentID,
                                gpa => gpa.StudentID,
                                (student, gpa) => new
                                {
                                    StudentName = student.StudentName,
                                    Major = student.Major,
                                    GPA = gpa.GPA
                                });
            foreach (var s in innerJoin)
            {
                Console.WriteLine($"Name: {s.StudentName}   \t\tMajor: {s.Major}\t\tGPA: {s.GPA}");
                Console.WriteLine();
            }
            Console.WriteLine(" ");


            var innerJoin2 = studentList.Join(studentClubList,
                                student => student.StudentID,
                                club => club.StudentID,
                                (student, club) => new
                                {
                                    StudentName = student.StudentName
                                });

            var inGame = from s in studentClubList
                          where s.ClubName.Contains("Game")
                          select s;
            Console.WriteLine("These people are in game club");
            foreach (var s in innerJoin2)
            {
                Console.WriteLine($"Name: {s.StudentName}");
                Console.WriteLine();
            }
            Console.WriteLine(" ");


        }
    }
}
