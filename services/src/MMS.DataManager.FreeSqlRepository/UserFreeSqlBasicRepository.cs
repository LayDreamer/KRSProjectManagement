using MMS.DataManager.Users;
using MMS.DataManager.Users.Dto;

namespace MMS.DataManager.FreeSqlRepository
{
    public class UserFreeSqlBasicRepository : FreeSqlBasicRepository, IUserFreeSqlBasicRepository
    {
        public async Task<List<UserOutput>> GetListAsync()
        {
            var sql = "select id from AbpUsers";
            var result = await FreeSql.Select<UserOutput>()
            .WithSql(sql)
            .ToListAsync();
            return result;
        }
    }
}
