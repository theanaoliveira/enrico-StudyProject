using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyProject.Infrastructure.Entidades;

namespace StudyProject.Infrastructure.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "public");
            builder.HasKey(k => k.Id);
        }
    }
}
