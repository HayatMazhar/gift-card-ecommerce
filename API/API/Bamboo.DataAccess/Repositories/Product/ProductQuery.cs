
namespace Bamboo.DataAccess.Repositories.Product
{
    public static class ProductQuery
    {
        public const string GET_ALL = @"SELECT [Id],[Name],[Description],[IsActive],[CreatedDate],[UpdatedDate] 
                                            FROM [Product] WHERE IsActive = 1";


        public const string GET_BY_ID = @"SELECT [Id],[Name],[Description],[IsActive],[CreatedDate],[UpdatedDate] 
                                            FROM [Departments]
                                            WHERE [Id]=@Id";


        public const string INSERT = @"INSERT INTO [dbo].[Product] ( [Name], [Description], [IsActive], [CreatedDate])
                                        VALUES ( @Name, @Description, @IsActive, @CreatedDate)";


        public const string UPDATE = @"UPDATE [dbo].[Product]
                                        SET [Name] = @Name, [Description] = @Description, [IsActive] = @IsActive, [UpdatedDate] = @UpdatedDate WHERE [Id] = @Id";

        public const string DELETE = @"UPDATE [dbo].[Product] SET [IsActive] = 0 WHERE [Id] = @Id";
    }
}
