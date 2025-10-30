using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_2_Assignment.School {
    internal class Course: ICourseService {
        private List<Student> enrolledStudents;

        public string CourseName { get; set; }

        public Course(string courseName) {
            CourseName = courseName;
            enrolledStudents = new List<Student>();
        }

        public void EnrollStudent(Student student) {
            if (!enrolledStudents.Contains(student)) {
                enrolledStudents.Add(student);
            }
        }
        public List<Student> GetEnrolledStudents() {
            return enrolledStudents;
        }
    }
}
