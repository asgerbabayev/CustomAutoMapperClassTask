using ConsoleApp1.Profile;

namespace ConsoleApp1
{
    internal static class Program
    {
        // Mapper classiniz olur. Map metodu olur. Parametr olaraq cevireceyiniz tip gelir. 
        static void map<T, E>(E e) { }
        public static Dictionary<string, string> ToDictionary<T>(this T type)
            where T : class, new()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            foreach (var property in type.GetType().GetProperties())
            {
                keyValuePairs.Add(property.Name, property.GetValue(type).ToString());
            }
            return keyValuePairs;
        }
        static void Main(string[] args)
        {
            //Dictionary<string, string> employees = new Dictionary<string, string>()
            //{
            //    {"Name","John"},
            //    {"Surname","Whick"}
            //};

            //Employee employee = new()
            //{
            //    Name = "dsadasdas",
            //    Surname = "sdadadasdas"
            //};
            //var dict = employee.ToDictionary();
            //foreach (var item in dict)
            //{
            //    Console.WriteLine(item.Key + " - " + item.Value);
            //}

            AutoMapper mapper = new();

            EmployeeDto employeeDto = new()
            {
                Name = "Huseyn",
                Surname = "Aliyev"
            };

            Employee employee = mapper.Map<EmployeeDto, Employee>(employeeDto);

            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name} , Surname: {employee.Surname} ");
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}