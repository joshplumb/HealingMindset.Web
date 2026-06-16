using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealingMindset.DataAccess.Context;

public class UserDatabaseContext : IdentityDbContext<UserModel>
{
    public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options)
        : base(options)
    {
    }
}