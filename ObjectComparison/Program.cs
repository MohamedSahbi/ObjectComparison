using System;


namespace ObjectComparison
{
    class Program
    {

        static void Main(string[] args)
        {


            Person person = new Person
            {
                Name = "Mohamed",
                FirstName = "Sahib",
                Age = 30,
                Id = 1
            };
            Person newPerson = new Person
            {
                Name = "Mohamed",
                FirstName = "Sahbi",
                Age = 25,
                Id =12
            };
            var x = Comparer<Person>.GenerateAuditLogMessages(person, newPerson);
            Console.WriteLine("*******************  ");
            Console.WriteLine("*******  ");
            Console.WriteLine("*  ");
            Console.WriteLine("  ");
            Console.WriteLine("Object Comparison with IList as type");
            Console.WriteLine("  ");
            foreach (var item in x)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("  ");
            Console.WriteLine("*******************  ");
            Console.WriteLine("*******  ");
            Console.WriteLine("*  ");
            Console.WriteLine("  ");
            Console.WriteLine("Object Comparison with ComparisonResult as type");
            Console.WriteLine("  ");
            var y = Comparer<Person>.GenerateAuditLogComaprisonObject(person, newPerson);
            Console.WriteLine("Class name : " +y.ClassName );
            Console.WriteLine( "Changed Properties :" +y.ChangedProperties);
            Console.WriteLine( "Old Value: " + y.OldValue);
            Console.WriteLine( "New Value: " + y.NewValue);



            var collection = new string[]{ "Id"};
            var z = Comparer<Person>.GenerateAuditLogComaprisonObject(person, newPerson, collection);
            Console.WriteLine("*******************  ");
            Console.WriteLine("*******  ");
            Console.WriteLine("*  ");
            Console.WriteLine("  ");
            Console.WriteLine("Object Comparison ComparisonResult as type, including exceptions");
            Console.WriteLine("Class name : " + z.ClassName);
            Console.WriteLine("Changed Properties :" + z.ChangedProperties);
            Console.WriteLine("Old Value: " + z.OldValue);
            Console.WriteLine("New Value: " + z.NewValue);

            Console.ReadKey();
        }
    }
}
