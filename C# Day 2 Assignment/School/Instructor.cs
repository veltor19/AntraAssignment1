using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_2_Assignment.School {
    internal class Instructor : Person, IInstructorService {

        public Instructor(string name, DateTime dateOfBirth, decimal salary, DateTime joinDate, decimal bonusRate)
            : base(name, dateOfBirth, salary) {
            JoinDate = joinDate;
            BonusRate = bonusRate;
        }

        private Department department;

        public Department Department {
            get { return department; }
            set { department = value; }
        }
        public DateTime JoinDate { get; set; }
        public decimal BonusRate { get; set; }

        public int CalculateYearsOfExperience() {
            var today = DateTime.Today;
            var experience = today.Year - JoinDate.Year;
            return experience;
        }

        public decimal CalculateTotalSalary() {
            var baseSalary = Salary;
            var experience = CalculateYearsOfExperience();
            var bonus = baseSalary * BonusRate* experience;
            return baseSalary + BonusRate;
        }

    }
}
