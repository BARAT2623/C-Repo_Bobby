using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CollegeApp.Data.Config
{
	public class StudentConfig : IEntityTypeConfiguration<student>
	{
		public void Configure(EntityTypeBuilder<student> builder)
		{
			builder.ToTable("Students");
			builder.HasKey(s => s.Id);

			builder.Property(s => s.Id).UseIdentityColumn();

			builder.Property(n => n.Name).IsRequired().HasMaxLength(250);
			builder.Property(n => n.Email).IsRequired();
			builder.Property(n => n.Phone).IsRequired().HasMaxLength(12);

			builder.HasData(new List<student>()
			{ 
                new student { Id = 1, Name = "John Doe", Email = "john@gmail.com", Phone = "1234567890" },
				new student { Id = 2, Name = "Jane Smith", Email = "jane@gmail.com", Phone = "0987654321" },
				new student { Id = 3, Name = "Bobby", Email = "bobby@gmail.com", Phone = "1122334455" }
			);
		}
	}
}