using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TaskOne.Models.Seeder
{
    public class DepartmentSeeding : IEntityTypeConfiguration<Department>
    {


        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = 1,
                    Name = "AI Department",
                    Description = "this is a Description for AI"
                },
                new Department
                {
                    Id = 2,
                    Name = "CS",
                    Description = "this is a Description for AI"
                }
            );
        }
    }
}
