using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagement
{
    class Program
    {
        // Customer class
        public class Customer
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }

            public Customer(string name, DateTime dateOfBirth, string gender)
            {
                Id = Guid.NewGuid();
                Name = name;
                DateOfBirth = dateOfBirth;
                Gender = gender;
            }
        }

        // List to store customers
        static List<Customer> customers = new List<Customer>();

        // Method to add customer
        public static void AddCustomer(string name, DateTime dateOfBirth, string gender)
        {
            customers.Add(new Customer(name, dateOfBirth, gender));
            Console.WriteLine($"Customer {name} added successfully.");
        }

        // Method to calculate average age
        public static double CalculateAverageAge()
        {
            if (customers.Count == 0) return 0;
            return customers.Average(c => GetAge(c.DateOfBirth));
        }

        // Method to calculate average age by gender
        public static double CalculateAverageAgeByGender(string gender)
        {
            var filteredCustomers = customers.Where(c => c.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)).ToList();
            if (filteredCustomers.Count == 0) return 0;
            return filteredCustomers.Average(c => GetAge(c.DateOfBirth));
        }

        // Helper method to calculate age
        public static int GetAge(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;

            // If birth date has not yet occurred this year, subtract one year from age
            if (now < dateOfBirth.AddYears(age))
                age--;

            return age;
        }

        static void Main(string[] args)
        {
            // Adding sample customers
            AddCustomer("John Doe", new DateTime(1990, 1, 1), "Male");
            AddCustomer("Jane Smith", new DateTime(1985, 5, 15), "Female");
            AddCustomer("Alice Johnson", new DateTime(2000, 8, 21), "Female");
            AddCustomer("Bob Brown", new DateTime(1978, 12, 30), "Male");

            // Calculate average age
            Console.WriteLine($"Average age of all customers: {CalculateAverageAge():0.00} years");

            // Calculate average age by gender
            Console.WriteLine($"Average age of male customers: {CalculateAverageAgeByGender("Male"):0.00} years");
            Console.WriteLine($"Average age of female customers: {CalculateAverageAgeByGender("Female"):0.00} years");

            Console.WriteLine(GetAge(new DateTime(2022,8,6)));
            Console.ReadLine();
        }
    }
}
