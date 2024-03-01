using Microsoft.EntityFrameworkCore;
using api.entities;
using Microsoft.Extensions.Configuration;


namespace api.context;

public class DatabaseContext: DbContext
{
	public DbSet<PostEntity> Posts { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder builder)
	{
		builder.UseMySQL("Server=localhost;Port=3306;Database=postsdb;User=arthur;Password=123;");
	}
}