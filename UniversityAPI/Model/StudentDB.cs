using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Authentication;
using UniversityAPI.Model;
using UniversityAPI.Model.ViewModel;

namespace UniversityAPI.Model
{
    public class StudentDB:IdentityDbContext<ApplicationUser>
    {
        public StudentDB(DbContextOptions<StudentDB>options):base(options)
        {
            
        }

        public DbSet<StudentTB> StudentTb { get; set; }
        public DbSet<DepartmentTB> DepartmentTb { get; set; }
        public DbSet<AllocateClass> AllocateClassTb{ get; set; }
        public DbSet<Course> CourseTb { get; set; }
        public DbSet<CourseAssignTeacher> CourseAssignTb { get; set; }
        public DbSet<Day> DayTb { get; set; }
        public DbSet<Designation> DesignationTb { get; set; }
        public DbSet<EnrollCourse> EnrollCourseTb { get; set; }
        public DbSet<GradeLetter> GradeLetterTb { get; set; }
        public DbSet<Room> RoomTb { get; set; }
        public DbSet<Semester> SemesterTb { get; set; }
        public DbSet<StudentResult> StudentResultTb { get; set; }
        public DbSet<Teacher> TeacherTb { get; set; }

        public DbSet<StudentResultViewModel> StudentResultViews { get; set; }
        public DbSet<ShowAssignView> StudentAssignView { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<StudentResultViewModel>().HasNoKey().ToView("StudentResultView");
            builder.Entity<ShowAssignView>().HasNoKey().ToView("ShowAssignView");
            builder.Entity<StudentTB>()
                .HasOne(_ => _.DepartmentTB)
                .WithMany(a => a.StudentTB)
                .HasForeignKey(p => p.DepartmentId);

            builder.Entity<Teacher>()
                .HasOne(_ => _.DepartmentTB)
                .WithMany(c => c.Teacher)
                .HasForeignKey(a => a.DepartmentId);
            builder.Entity<Teacher>()
                .HasOne(_ => _.Designation)
                .WithMany(c => c.Teacher)
                .HasForeignKey(a => a.DesignationId);
            builder.Entity<EnrollCourse>()
                .HasOne(_ => _.StudentTB)
                .WithMany(c => c.EnrollCourse)
                .HasForeignKey(a => a.StudentId);
            builder.Entity<EnrollCourse>()
                .HasOne(_ => _.Course)
                .WithMany(c => c.EnrollCourse)
                .HasForeignKey(a => a.CourseId);
            builder.Entity<StudentResult>()
                .HasOne(_ => _.StudentTB)
                .WithMany(c => c.StudentResult)
                .HasForeignKey(a => a.StudentId);
            builder.Entity<StudentResult>()
                .HasOne(_ => _.Course)
                .WithMany(c => c.StudentResult)
                .HasForeignKey(a => a.CourseId);
            builder.Entity<StudentResult>()
                .HasOne(_ => _.GradeLetter)
                .WithMany(c => c.StudentResult)
                .HasForeignKey(a => a.GradeLetterId);
            builder.Entity<CourseAssignTeacher>()
                .HasOne(_ => _.DepartmentTB)
                .WithMany(c => c.CourseAssignTeacher)
                .HasForeignKey(a => a.DepartmentId);

            builder.Entity<CourseAssignTeacher>()
                .HasOne(_ => _.Teacher)
                .WithMany(c => c.CourseAssignTeacher)
                .HasForeignKey(a => a.TeacherId);
            builder.Entity<CourseAssignTeacher>()
                .HasOne(_ => _.Course)
                .WithMany(c => c.CourseAssignTeacher)
                .HasForeignKey(a => a.CourseId);
            builder.Entity<CourseAssignTeacher>().Property(c => c.Action).HasDefaultValue(true);
                
            builder.Entity<Course>()
                .HasOne(_ => _.DepartmentTB)
                .WithMany(c => c.Course)
                .HasForeignKey(a => a.DepartmentId);
            builder.Entity<Course>()
                .HasOne(_ => _.Semester)
                .WithMany(c => c.Course)
                .HasForeignKey(a => a.SemesterId);
            builder.Entity<AllocateClass>()
                .HasOne(_ => _.DepartmentTB)
                .WithMany(c => c.AllocateClass)
                .HasForeignKey(a => a.DepartmentId);
            builder.Entity<AllocateClass>()
                .HasOne(_ => _.Room)
                .WithMany(c => c.AllocateClass)
                .HasForeignKey(a => a.RoomId);
            builder.Entity<AllocateClass>()
                .HasOne(_ => _.Course)
                .WithMany(c => c.AllocateClass)
                .HasForeignKey(a => a.CourseId);
            builder.Entity<AllocateClass>()
                .HasOne(_ => _.Day)
                .WithMany(c => c.AllocateClass)
                .HasForeignKey(a => a.DayId);
            base.OnModelCreating( builder);
        }
    } 
}
