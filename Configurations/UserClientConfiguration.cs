using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserClientConfiguration : IEntityTypeConfiguration<UserClient>
{
    public void Configure(EntityTypeBuilder<UserClient> builder)
    {
        builder.HasAlternateKey(x => x.Email);
        throw new NotImplementedException();
    }
}