using Templet.Data.Entities.Identity;
using Templet.Infrastructure.DbContext;
using Templet.Infrastructure.InfrustructureBase;
using Templet.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Templet.Infrastructure.Repositories;

public class UserRefreshTokenRepository:GenericRepository<UserRefreshToken>,IUserRefreshTokenRepository
{
    #region Fields
    private DbSet<UserRefreshToken> userRefreshToken;
    #endregion
    public UserRefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        userRefreshToken=dbContext.Set<UserRefreshToken>();
    }
}