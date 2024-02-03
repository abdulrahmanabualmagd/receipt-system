using Core.Entities;
using Infrastructure.Data.Contexts.Application;
using Newtonsoft.Json;

namespace Infrastructure.Data.Seeds.Application
{
    public static class ApplicationSeed
    {
        public static async Task SeedApplicationAsync(ApplicationDbContext context)
        {
            await SeedCoursesDataAsync(context);
            await SeedStudentsDataAsync(context);
            await SeedDepartmentsDataAsync(context);
            await SeedTeachersDataAsync(context);
            await SeedSchoolsDataAsync(context);
            await SeedClassroomDataAsync(context);
        }

        #region SeedCoursesDataAsync
        public static async Task SeedCoursesDataAsync(ApplicationDbContext context)
        {
            if (context.Courses.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Application/StaticFiles/Courses.json");
            var data = JsonConvert.DeserializeObject<List<Course>>(jsonData);

            context.Courses.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion

        #region SeedTeachersDataAsync
        public static async Task SeedTeachersDataAsync(ApplicationDbContext context)
        {
            if (context.Teachers.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Application/StaticFiles/Teachers.json");
            var data = JsonConvert.DeserializeObject<List<Teacher>>(jsonData);

            context.Teachers.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion

        #region SeedSchoolsDataAsync
        public static async Task SeedSchoolsDataAsync(ApplicationDbContext context)
        {
            if (context.Schools.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Application/StaticFiles/Schools.json");
            var data = JsonConvert.DeserializeObject<List<School>>(jsonData);

            context.Schools.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion

        #region SeedDepartmentsDataAsync
        public static async Task SeedDepartmentsDataAsync(ApplicationDbContext context)
        {
            if (context.Departments.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Application/StaticFiles/Departments.json");
            var data = JsonConvert.DeserializeObject<List<Department>>(jsonData);

            context.Departments.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion

        #region SeedStudentsDataAsync
        public static async Task SeedStudentsDataAsync(ApplicationDbContext context)
        {
            if (context.Students.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Application/StaticFiles/Students.json");
            var data = JsonConvert.DeserializeObject<List<Student>>(jsonData);

            context.Students.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion

        #region SeedStudentsDataAsync
        public static async Task SeedClassroomDataAsync(ApplicationDbContext context)
        {
            if (context.Classrooms.Any())
                return;

            var jsonData = await File.ReadAllTextAsync("../Infrastructure/Data/Seeds/Application/StaticFiles/Classrooms.json");
            var data = JsonConvert.DeserializeObject<List<Classroom>>(jsonData);

            context.Classrooms.AddRange(data);
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
