using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Persistance.Configurations
{
    public class StateNumberConfigurations : IEntityTypeConfiguration<StateNumber>
    {
        public void Configure(EntityTypeBuilder<StateNumber> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x  => x.Number).IsRequired();
        }
    }
}
