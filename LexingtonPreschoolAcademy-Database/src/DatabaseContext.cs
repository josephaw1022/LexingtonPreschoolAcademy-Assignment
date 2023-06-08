using Microsoft.EntityFrameworkCore;

namespace LexingtonPreschoolAcademy_Database;

//* Database context
public class LexingtonPreschoolAcademyDatabaseContext : DbContext
{
    //* Boilerplate constructor
    public LexingtonPreschoolAcademyDatabaseContext(DbContextOptions<LexingtonPreschoolAcademyDatabaseContext> options) : base(options)
    {
    }
    //* Tables
    public DbSet<StudentTable> Students { get; set; } = null!;
    public DbSet<ClassTable> Classes { get; set; } = null!;

    //* Set up the many to many relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<StudentTable>()
        .HasMany(s => s.Classes)
        .WithOne(c => c.Student)
        .HasForeignKey(c => c.StudentId)
        .IsRequired();
    }



}
