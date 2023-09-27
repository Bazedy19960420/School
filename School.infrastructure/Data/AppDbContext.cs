using Microsoft.EntityFrameworkCore;
using School.data.Entities;

namespace School.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<InsSubject> InsSubjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentSubject>().HasKey(ss => new { ss.StudID, ss.SubID });
            modelBuilder.Entity<DepartmentSubject>().HasKey(ds => new { ds.DID, ds.SubID });
            modelBuilder.Entity<InsSubject>().HasKey(ins => new { ins.InsId, ins.SubId });
            modelBuilder.Entity<Instructor>().HasOne(ins => ins.SuperVisor).WithMany(d => d.Instructors).HasForeignKey(ins => ins.SuperVisorId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Department>().HasOne(d => d.InsManager).WithOne(ins => ins.DepartmentManager).HasForeignKey<Department>(d => d.InsManagerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DepartmentSubject>().HasOne(ds => ds.Department).WithMany(d => d.DepartmentSubjects).HasForeignKey(ds => ds.DID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DepartmentSubject>().HasOne(ds => ds.Subjects).WithMany(s => s.DepartmetsSubjects).HasForeignKey(ds => ds.SubID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentSubject>().HasOne(ss => ss.Student).WithMany(s => s.StudentsSubjects).HasForeignKey(ss => ss.StudID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentSubject>().HasOne(ss => ss.Subject).WithMany(s => s.StudentsSubjects).HasForeignKey(ss => ss.SubID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InsSubject>().HasOne(ins => ins.Instructor).WithMany(i => i.InsSubjects).HasForeignKey(ins => ins.InsId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InsSubject>().HasOne(ins => ins.Subject).WithMany(s => s.InsSubjects).HasForeignKey(ins => ins.SubId).OnDelete(DeleteBehavior.Restrict);
        }
    }

}
