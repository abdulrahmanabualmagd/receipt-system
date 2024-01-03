/*
 * - Using Entity Framework Core in Console Application to Access Database (Code Frist Approach)
 * - Install these packages to use Ef Core
 *      - Microsoft.EntityFrameworkCore
 *      - Microsoft.EntityFrameworkCore.SqlServer
 *      - Microsoft.EntityFrameworkCore.Tools
 *      - Microsoft.EntityFrameworkCore.Design
 *      
 * - Create Your Entities in the Model Directory
 * - Create a Class and Inherit from DbContext which include 
 *      - DbSet Properties for all Entities
 *      - Configure Database provider and Connection string Using OnConfiguring Method
 *      
 *  - Add Migration     // EF analyze the differences between the current and previous stat, then generate the migration files include all the updates
 *  - Update Database   // Detect Pending Migration > Generage Sql Scripts > Execute Sql Scripts > Update Migration History Table > Database Updated
 */
using Azure.Identity;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main()
        {
            Context context = new Context();

            #region In case using 'virtual' keyword
            // The related enetity will lazy load becasue we're using virtual which creates a proxy class that enables this feature
            var q = context.Students;

            foreach (var item in q)
            {
                /*
                 * '?' checks if the item.school is null, It will short the circuits 
                 * and item.school?.Name evaluates to null without attempting to 
                 * access the name property
                 */
                Console.WriteLine(item.School?.Name);
            }
            #endregion

            #region In Case not using 'virtual' keyword
            // the related entity is loaded eagerly because of using .Include() and not using virtual
            // if we didn't use Include and virtual, the related entity won't be able to load it in the same query
            var q2 = context.Students.Include(s => s.School);

            foreach(var item in q2)
            {
                // '?' checks if the item.school is null it will short circuit the item.school.Name and 
                // evaluate it to null without attempting to access the name of the school that related to the student
                Console.WriteLine(item.School?.Name);
            }
            #endregion
        }
    }
}