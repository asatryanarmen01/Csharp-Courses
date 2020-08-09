using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lesson5.Exercise
{
    /// <summary>
    /// LINQ Exercise model
    /// </summary>
    public class LINQExercise
    {
        /// <summary>
        /// Run LINQ Exercise
        /// </summary>
        public void Run()
        {
            // init temp data
            var disciplines = this.InitDisciplines();

            // 1. Find the count of all students
            var allStudentsCount = disciplines.Select(discipline => discipline.GetStudents()).Sum(st => st.Count());

            Console.WriteLine("1. Students count is {0}", allStudentsCount);
            Console.WriteLine();

            // 2. The names of students for a specific discipline.
            string discName = "C#";
            var studentsByDisciplines = disciplines.Where(discipline => discipline.Name == discName).SelectMany(discipline => discipline.GetStudents().Select(g => (g.Name, g.Surname)));

            Console.WriteLine("2. Students of {0} discipline are:", discName);
            foreach (var std in studentsByDisciplines)
            {
                Console.WriteLine(" - {0} {1}", std.Name, std.Surname);
            }
            Console.WriteLine();

            // 3. Find the names of students for a discipline which has the maximum number of students
            // option 1
            var maxStudentCount = disciplines.Max(discipline => discipline.GetStudents().Count());
            var biggestDisciplineOp1 = disciplines
                .Where(discipline => discipline.GetStudents().Count() == maxStudentCount)
                .FirstOrDefault();

            Console.WriteLine("3. Biggest Discipine student Names are:");
            foreach (var std in biggestDisciplineOp1.GetStudents())
            {
                Console.WriteLine(" - {0} {1}", std.Name, std.Surname);
            }
            Console.WriteLine();

            // option 2
            var biggestDisciplineOp2 = disciplines.OrderByDescending(o => o.GetStudents().Count()).FirstOrDefault();

            // 4. The lesson with the earliest start date.
            var earliestDate = disciplines.SelectMany(discipline => discipline.GetLessons()).Min(d => d.StartDate);
            var earliestLessons = disciplines.SelectMany(discipline => discipline.GetLessons().Where(d => d.StartDate == earliestDate));

            Console.WriteLine("4. {0} is the earliest lesson and starts on {1}.", earliestLessons.ToList().FirstOrDefault().Name, earliestDate.ToShortDateString());
            Console.WriteLine();

            // 5. Find the name of the discipline with the lesson which has the earliest start date

            var earliestDiscipline = disciplines.Where(discipline => discipline.GetLessons().Any(a => earliestLessons.Contains(a)));

            Console.WriteLine("5. {0} is the earliest discipline", earliestDiscipline.ToList().FirstOrDefault().Name);
            Console.WriteLine();

            // 6. The names of lecturers which teach the discipline which has the maximum number of students.
            var biggestDisciplineLecturers = disciplines.Where(discipline => discipline.Name == biggestDisciplineOp1.Name)
                .SelectMany(discipline => discipline.GetLecturers())
                .Select(g => new { g.Name, g.Surname });
            
            Console.WriteLine("6. {0} is the biggest discipline and the lecturers are:", biggestDisciplineOp1.Name);
            foreach (var lct in biggestDisciplineLecturers)
            {
                Console.WriteLine(" - {0} {1}", lct.Name, lct.Surname);
            }
            Console.WriteLine();

            // 7. Find the name of the student who participates in the maximum number of disciplines
            var mostActiveStudent = disciplines.SelectMany(discipline => discipline.GetStudents())
                                               .GroupBy(g => (g.Name, g.Surname))
                                               .OrderByDescending(o => o.Count())
                                               .Select(s => s.Key)
                                               .FirstOrDefault();

            // 8. The pairs of student name and discipline name(students are assigned to discipline).
            var pairsStudentDiscipline = disciplines.SelectMany(discipline => discipline.GetStudents().Select(g => new { g.Name, g.Surname})).Distinct();

            Console.WriteLine("8. Student-Discipline pairs.");
            foreach (var dsc in pairsStudentDiscipline)
            {
                Console.WriteLine(" - {0} {1} - {2}", dsc.Name, dsc.Surname);
            }
            Console.WriteLine();

            // 9. Find the names of disciplines sorted by the number of students assigned to the discipline
            var sortedDiscipline = disciplines.OrderByDescending(discipline => discipline.GetStudents().Count());

            Console.WriteLine("9. Biggest Disciplines sorted by students count.");
            foreach (var dsc in sortedDiscipline)
            {
                Console.WriteLine(" - {0}, {1} students", dsc.Name, dsc.GetStudents().Count());
            }
            Console.WriteLine();

            // 10. The names of all students which age is less than 30.
            var studentsYounger30 = disciplines.SelectMany(discipline => discipline.GetStudents().Where(g => g.Age <= 30))
                                               .Select(g => new { g.Name, g.Surname, g.Age }).Distinct();

            Console.WriteLine("10. Students that are younger than 30 years.");
            foreach (var std in studentsYounger30)
            {
                Console.WriteLine(" - {0} {1}", std.Name, std.Surname);
            }
            Console.WriteLine();


        }

        /// <summary>
        /// Create disciplines
        /// </summary>
        /// <returns></returns>
        private List<Discipline> InitDisciplines()
        {
            // create C# students, lecturers and lessons
            var cSharpStudents = this.InitCSharpStudents();
            var cSharpLecturers = this.InitCSharpLecturers();
            var cSharpLessons = this.InitCSharpLessons();

            // create english students, lecturers and lessons
            var englishStudents = this.InitEnglishStudents();
            var englishLecturers = this.InitEnglishLecturers();
            var englishLessons = this.InitEnglishLessons();

            // create C# discipline
            var cSharpDisciplin = new Discipline("C#");
            cSharpDisciplin.AddStudents(cSharpStudents);
            cSharpDisciplin.AddLecturers(cSharpLecturers);
            cSharpDisciplin.AddLessons(cSharpLessons);

            // create English discipline
            var englishDisciplin = new Discipline("English");
            englishDisciplin.AddStudents(englishStudents);
            englishDisciplin.AddLecturers(englishLecturers);
            englishDisciplin.AddLessons(englishLessons);

            return new List<Discipline> { cSharpDisciplin, englishDisciplin };
        }

        /// <summary>
        /// Create C# students
        /// </summary>
        /// <returns></returns>
        private List<Student> InitCSharpStudents()
        {
            return new List<Student>
            {
                new Student("John", "Smith", 18),
                new Student("Ann", "Jones", 33),
                new Student("Mary", "Wilson", 24),
                new Student("William", "Jackson", 29),

            };
        }

        /// <summary>
        /// Create C# lecturers
        /// </summary>
        /// <returns></returns>
        private List<Lecturer> InitCSharpLecturers()
        {
            return new List<Lecturer>
            {
                new Lecturer("Paul", "Flin",36),
                new Lecturer("Elise", "Black",23)
            };
        }

        /// <summary>
        /// Create C# Lessons
        /// </summary>
        /// <returns></returns>
        private List<Lesson> InitCSharpLessons()
        {
            return new List<Lesson>
            {
                new Lesson("C# lecture", new DateTime(2020, 5, 17), new DateTime(2020, 9, 29)),
                new Lesson("C# practice", new DateTime(2020, 7, 2), new DateTime(2020, 10, 3))
            };
        }

        /// <summary>
        /// Create English students
        /// </summary>
        /// <returns></returns>
        private List<Student> InitEnglishStudents()
        {
            return new List<Student>
            {
                new Student("John", "Smith",18),
                new Student("Ann", "Jones",33),
                new Student("Alice", "White",24),
                new Student("William", "Jackson",29),
                new Student("Robert", "Harris",32),
                new Student("Sophia", "Turner",25),
                new Student("Edward", "Wood",27),
                new Student("Martha", "Hall",35),
            };
        }

        /// <summary>
        /// Create English lecturers
        /// </summary>
        /// <returns></returns>
        private List<Lecturer> InitEnglishLecturers()
        {
            return new List<Lecturer>
            {
                new Lecturer("Dorothy", "Evans",29)
            };
        }

        /// <summary>
        /// Create English lessons
        /// </summary>
        /// <returns></returns>
        private List<Lesson> InitEnglishLessons()
        {
            return new List<Lesson>
            {
                new Lesson("English", new DateTime(2020, 6, 1), new DateTime(2020, 9, 29))
            };
        }
    }
}
