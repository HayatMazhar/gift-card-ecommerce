
namespace Bamboo.DataAccess.Repositories.Product
{
    public static class OrderQuery
    {
        public const string GET_ALL = @"";


        public const string GET_BY_ID = @"";


        public const string INSERT = @"INSERT INTO [dbo].[Orders] ( [RequestId], [AccountId], [ProductId], [Quantity],[Value])
                                        VALUES ( @RequestId, @AccountId, @ProductId, @Quantity, @Value)";

   
    }
}
