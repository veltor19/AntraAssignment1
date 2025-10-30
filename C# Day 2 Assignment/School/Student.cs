using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_2_Assignment.School {
    internal class Student: Person, IStudentService {
        private Dictionary<Course, Grade> courseGrades;

        public int Id { get; set; }

        public Student(int id, string name, DateTime dateOfBirth): base(name, dateOfBirth, 0) {
            Id = id;
            courseGrades = new Dictionary<Course, Grade>();
        }

        public void EnrollInCourse(Course course, Grade grade = Grade.F) {
            if (!courseGrades.ContainsKey(course)) {
                courseGrades[course] = grade;
            }
        }

        public void setGrade(Course course, Grade grade) {
            if (courseGrades.ContainsKey(course)) {
                courseGrades[course] = grade;
            } else {
                throw new ArgumentException("Student is not enrolled in the specified course.");
            }
        }

        public double CalculateGPA() {
            if (courseGrades.Count == 0) {
                return 0.0;
            }
            double totalPoints = 0.0;
            foreach (var grade in courseGrades.Values) {
                totalPoints += grade switch {
                    Grade.A => 4.0,
                    Grade.B => 3.0,
                    Grade.C => 2.0,
                    Grade.D => 1.0,
                    Grade.F => 0.0,
                    _ => 0.0
                };
            }
            return totalPoints / courseGrades.Count;
        }

        public override decimal CalculateSalary() {
            return 0;
        }
    }
}
