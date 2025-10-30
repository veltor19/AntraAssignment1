using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_2_Assignment.School {
    internal class Department: IDepartmentService {
        private List<Course> offeredCoursee;
        private Instructor departmentHead;
        public decimal Budget { get; set; }
        public string DepartmentName { get; set; }

        public Instructor DepartmentHead {
            get { return departmentHead; }
            set { departmentHead = value; }
        }

        public Department(string departmentName, decimal budget) {
            DepartmentName = departmentName;
            Budget = budget;
            offeredCoursee = new List<Course>();
        }

        public void AddCourse(Course course) {
            if (!offeredCoursee.Contains(course)) {
                offeredCoursee.Add(course);
            }
        }

        public void SetDepartmentHead(Instructor instructor) {
            DepartmentHead = instructor;
        }

        public List<Course> GetOfferedCourses() {
            return offeredCoursee;
        }
    }
}
