using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_2_Assignment.School {
    internal interface ICourseService {
        void EnrollStudent(Student student);

        List<Student> GetEnrolledStudents();
    }
}
