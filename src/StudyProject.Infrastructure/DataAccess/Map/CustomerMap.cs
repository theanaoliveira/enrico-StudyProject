using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyProject.Infrastructure.DataAccess.Entidades;

namespace StudyProject.Infrastructure.DataAccess.Map
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
