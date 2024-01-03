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

            // Use Different Operations Like Filtering, Searching, Modifying, and so on...
            var q = context.Students.ToList();
        }
    }
}