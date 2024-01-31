using Application;
using Core.Security.Entities;
using Core.Security.Hassing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(b => b.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.FirstName).HasColumnName("Id").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Id").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Status).HasColumnName("Id").HasDefaultValue(true);
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.EmailAuthenticator);
        builder.HasMany(u => u.OtpAuthenticator);

        builder.HasData(GetSeeds());

    }

    private IEnumerable<User> GetSeeds()
    {
        List<User> users = new();

        HashingHelper.CreatePasswordHash(
            password: "Password",
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );

        User adminUser = 
            new()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Berkay",
                Email = "bbbb@gmail.com",
                Status = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

        users.Add(adminUser);

        return users.ToArray();
    }
}
