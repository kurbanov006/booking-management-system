using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserMasterConfiguration : IEntityTypeConfiguration<UserMaster>
{
    public void Configure(EntityTypeBuilder<UserMaster> builder)
    {
        builder.HasAlternateKey(x => x.Email);
        throw new NotImplementedException();
    }
}