﻿// See https://aka.ms/new-console-template for more information
using System;
namespace CustomerInfo

{
    class Customer
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add new customer");
                Console.WriteLine("2. View all customers");
                Console.WriteLine("3. Update customer");
                Console.WriteLine("4. Delete customer");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        ViewCustomers();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        DeleteCustomer();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void AddCustomer()
        {
            Customer customer = new Customer();

            customer.ID = GeneratecustomerId();
            Console.WriteLine($"Customer ID: {customer.ID}");

            Console.Write("Enter first name: ");
            customer.FirstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            customer.LastName = Console.ReadLine();

            Console.Write("Enter email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Enter age: ");
            customer.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter phonenumber: ");
            customer.PhoneNumber = Console.ReadLine();

            Console.Write("Enter city: ");
            customer.City = Console.ReadLine();

            customers.Add(customer);
        }

        static void ViewCustomers()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found");
            }
            else
            {
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"ID: {customer.ID}, Name: {customer.FirstName} {customer.LastName}, E-mail: {customer.Email}, Age: {customer.Age}, Phone Number: {customer.PhoneNumber}, City: {customer.City}");
                }
            }
        }

        static void UpdateCustomer()
        {
            Console.Write("Enter customer ID to update: ");
            string id = Console.ReadLine();

            Customer customer = FindCustomerById(id);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
            }
            else
            {
                Console.Write("Enter first name: ");
                customer.FirstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                customer.LastName = Console.ReadLine();

                Console.Write("Enter email: ");
                customer.Email = Console.ReadLine();

                Console.Write("Enter age: ");
                customer.Age = int.Parse(Console.ReadLine());

                Console.Write("Enter phonenumber: ");
                customer.PhoneNumber = Console.ReadLine();

                Console.Write("Enter city: ");
                customer.City = Console.ReadLine();
            }
        }

        static void DeleteCustomer()
        {
            Console.Write("Enter customer ID to delete: ");
            string id = Console.ReadLine();

            Customer customer = FindCustomerById(id);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
            }
            else
            {
                customers.Remove(customer);
                Console.WriteLine("Customer deleted successfully.");
            }
        }

        static Customer FindCustomerById(string id)
        {
            foreach (Customer customer in customers)
            {
                if (customer.ID == id)
                {
                    return customer;
                }
            }

            return null;
        }

        static string GeneratecustomerId()
        {
            string id = Guid.NewGuid().ToString();
            return id.Substring(0,6);
        }
    }
}