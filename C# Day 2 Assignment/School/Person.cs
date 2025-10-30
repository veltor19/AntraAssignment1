using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_2_Assignment.School {
    internal abstract class Person: IPersonService {
        private decimal salary;
        private List<string> addresses;

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public decimal Salary {
            get {
                return salary;
            }
            set {
                if (value < 0) {
                    throw new ArgumentException("Salary cannot be negative.");
                }
                salary = value;
            }
        }

        public Person(string name, DateTime dateOfBirth, decimal salary) {
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
            addresses = new List<string>();
        }

        public int CalculateAge() {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            return age;
        }

        public virtual decimal CalculateSalary() {
            return Salary;
        }

        public void AddAddress(string address) {
            addresses.Add(address);
        }


        public List<string> getAddresses() {
            return addresses;
        }

    }
}
