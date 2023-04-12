using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Authentication;
using WebApplication2.Models;

namespace UniversityAPI.Model
{
    public class StudentDB:IdentityDbContext<ApplicationUser>
    {
        public StudentDB(DbContextOptions<StudentDB>options):base(options)
        {
            
        }
        public virtual DbSet<ClassAllocateTB> ClassAllocateTB { get; set; }
        public virtual DbSet<CourseAssignTB> CourseAssignTB { get; set; }
        public virtual DbSet<CourseTB> CourseTB { get; set; }
        public virtual DbSet<DayTB> DayTB { get; set; }
        public virtual DbSet<DepartmentTB> DepartmentTB { get; set; }
        public virtual DbSet<DesignationTB> DesignationTB { get; set; }
        public virtual DbSet<EnrollCourseTB> EnrollCourseTB { get; set; }
        public virtual DbSet<GradeLetterTB> GradeLetterTB { get; set; }
        public virtual DbSet<RoomNoTB> RoomNoTB { get; set; }
        public virtual DbSet<SemesterTB> SemesterTB { get; set; }
        public virtual DbSet<StudentResultTB> StudentResultTB { get; set; }
        public virtual DbSet<StudentTB> StudentTB { get; set; }
        public virtual DbSet<TeacherTB> TeacherTB { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTB>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<CourseTB>()
                .Property(e => e.CourseCode)
                .IsUnicode(false);

            modelBuilder.Entity<CourseTB>()
                .Property(e => e.Credit)
                .IsUnicode(false);

            modelBuilder.Entity<CourseTB>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CourseTB>()
                .HasMany(e => e.StudentResultTB)
                .WithOne(e => e.CourseTB)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<DayTB>()
                .Property(e => e.DayName)
                .IsUnicode(false);

            modelBuilder.Entity<DayTB>()
                .HasMany(e => e.ClassAllocateTB)
                .WithOne(e => e.DayTB)
                .HasForeignKey(e => e.DayId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepartmentTB>()
                .Property(e => e.DepartmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<DepartmentTB>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<DepartmentTB>()
                .HasMany(e => e.ClassAllocateTB)
                .WithOne(e => e.DepartmentTB)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<DepartmentTB>()
                .HasMany(e => e.CourseTB)
                .WithOne(e => e.DepartmentTB)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<DepartmentTB>()
                .HasMany(e => e.StudentTB)
                .WithOne(e => e.DepartmentTB)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<DepartmentTB>()
                .HasMany(e => e.TeacherTB)
                .WithOne(e => e.DepartmentTB)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<DesignationTB>()
                .Property(e => e.DesignationName)
                .IsUnicode(false);

            modelBuilder.Entity<DesignationTB>()
                .HasMany(e => e.TeacherTB)
                .WithOne(e => e.DesignationTB)
                .HasForeignKey(e => e.DesignationId);

            modelBuilder.Entity<GradeLetterTB>()
                .Property(e => e.GradeLetterMarkes)
                .IsUnicode(false);

            modelBuilder.Entity<GradeLetterTB>()
                .Property(e => e.GradePoint)
                .IsUnicode(false);

            modelBuilder.Entity<GradeLetterTB>()
                .HasMany(e => e.StudentResultTB)
                .WithOne(e => e.GradeLetterTB)
                .HasForeignKey(e => e.GradeLetterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomNoTB>()
                .Property(e => e.RoomNo)
                .IsUnicode(false);

            modelBuilder.Entity<RoomNoTB>()
                .HasMany(e => e.ClassAllocateTB)
                .WithOne(e => e.RoomNoTB)
                .HasForeignKey(e => e.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SemesterTB>()
                .Property(e => e.SemesterName)
                .IsUnicode(false);

            modelBuilder.Entity<SemesterTB>()
                .HasMany(e => e.CourseTB)
                .WithOne(e => e.SemesterTB)
                .HasForeignKey(e => e.SemesterId);

            modelBuilder.Entity<StudentTB>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTB>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTB>()
                .Property(e => e.ContactNo)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTB>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTB>()
                .Property(e => e.RegistrationNo)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTB>()
                .HasMany(e => e.EnrollCourseTB)
                .WithOne(e => e.StudentTB)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<TeacherTB>()
                .Property(e => e.TeacherName)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherTB>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherTB>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherTB>()
                .Property(e => e.ContactNo)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherTB>()
                .HasMany(e => e.CourseAssignTB)
                .WithOne(e => e.TeacherTB)
                .HasForeignKey(e => e.TeacherId);


            base.OnModelCreating(modelBuilder);
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating( builder);
        // }
    }
}
