using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Schools
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Schools] ON");
            migrationBuilder.Sql("INSERT INTO [dbo].[Schools] ([Id], [Name]) VALUES (1, N'Elminya School')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Schools] ([Id], [Name]) VALUES (2, N'Cairo School')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Schools] ([Id], [Name]) VALUES (3, N'New Minya School')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Schools] ([Id], [Name]) VALUES (4, N'Alex School')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Schools] ([Id], [Name]) VALUES (5, N'Aswaan School')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Schools] ([Id], [Name]) VALUES (6, N'Giza School')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Schools] ([Id], [Name]) VALUES (7, N'Assiut School')");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Schools] OFF");
            #endregion

            #region Students
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Students] ON");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (1, N'Liam', 1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (2, N'Noah', 3)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (3, N'Oliver', 4)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (4, N'Elijah', 2)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (5, N'William', 5)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (6, N'James', 7)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (7, N'Benjamin', 6)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (8, N'Lucas', 1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (9, N'Henry', 3)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (10, N'Alexander', 4)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (11, N'Mason', 2)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (12, N'Michael', 5)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (13, N'Ethan', 7)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (14, N'Daniel', 6)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (15, N'Jacob', 1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (16, N'Logan', 3)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (17, N'Jackson', 4)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (18, N'Levi', 2)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (19, N'Sebastian', 5)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (20, N'Mateo', 7)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (21, N'Jack', 6)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (22, N'Owen', 1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (23, N'Theodore', 3)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (24, N'Aiden', 4)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (25, N'Samuel', 2)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (26, N'Joseph', 5)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (27, N'John', 7)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (28, N'David', 6)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (29, N'Wyatt', 1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (30, N'Matthew', 3)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (31, N'Luke', 4)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (32, N'Asher', 2)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (33, N'Carter', 5)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (34, N'Julian', 7)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (35, N'Grayson', 6)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES(36, N'Leo', 1)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (37, N'Jayden', 3)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (38, N'Gabriel', 4)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (39, N'Isaac', 2)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Students] ([Id], [Name], [SchoolId]) VALUES (40, N'Lincoln', 5)");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Students] OFF");
            #endregion
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            #region Schools
            migrationBuilder.Sql("DELETE FROM [dbo].[Schools] WHERE [Id] BETWEEN 1 AND 7");
            #endregion

            #region Students
            migrationBuilder.Sql("DELETE FROM [dbo].[Students] WHERE [Id] BETWEEN 1 AND 40");
            #endregion
        }
    }
}
