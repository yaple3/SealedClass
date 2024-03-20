namespace SealedClass
{
    internal interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }

    internal class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }

    }

    internal sealed class Executive : Employee
    {
        public string Title { get; set; }
        public double Salary { get; set; }
        public double Bonus { get; set; }

        public Executive()
        {
            Title = string.Empty;
            Salary = 0;
        }
        public Executive(int id, string firstName, string lastName, string title, double salary, double bonus)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            Salary = salary;
            Bonus = bonus;
        }
        public override double Pay()
        {
            double totalCompensation = Salary + Bonus;
            return totalCompensation;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Employee employee = new(1, "John", "Doe");
            Console.WriteLine($"Employee: {employee.Fullname()}");
            Console.WriteLine($"Weekly Salary: {employee.Pay()}");

            Executive executive = new(2, "Jane", "Doe", "CEO", 100000, 15000);
            Console.WriteLine($"Executive: {executive.Fullname()}");
            Console.WriteLine($"Title: {executive.Title}");
            Console.WriteLine($"Annual Salary: {executive.Pay()}");
        }
    }
}
