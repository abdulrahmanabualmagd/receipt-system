/*
 * - A feature in C# that allows you to add new methods to existing types without modifying them
 * - Are defined in static classes and are marked with 'this' keyword before the first parameter, 
 *   indicating the type that the method extends
 */

using Constructor;

namespace Extension_Methods
{
    class Protram
    {
        static void Main()
        {
            // Create Instance from Person
            Person person = new Person(0, "Abdulrahman");

            // Use Extension Method
            person.Show();
        }
    }
}