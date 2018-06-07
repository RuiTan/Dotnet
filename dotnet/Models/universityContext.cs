using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet
{
    public partial class universityContext : DbContext
    {
        public universityContext(DbContextOptions<universityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advisor> Advisor { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Prereq> Prereq { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Takes> Takes { get; set; }
        public virtual DbSet<Teaches> Teaches { get; set; }
        public virtual DbSet<TimeSlot> TimeSlot { get; set; }
        public virtual DbSet<TTestMain> TTestMain { get; set; }
        public virtual DbSet<TTestSub> TTestSub { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 注释掉了if判断句，是因为在Startup中显式指定了context
            // if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;userid=root;pwd=tanrui;port=3306;database=university;sslmode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advisor>(entity =>
            {
                entity.HasKey(e => e.SId);

                entity.ToTable("advisor");

                entity.HasIndex(e => e.IId)
                    .HasName("i_ID");

                entity.Property(e => e.SId)
                    .HasColumnName("s_ID")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.IId)
                    .HasColumnName("i_ID")
                    .HasColumnType("varchar(5)");

                entity.HasOne(d => d.I)
                    .WithMany(p => p.Advisor)
                    .HasForeignKey(d => d.IId)
                    .HasConstraintName("advisor_ibfk_1");

                entity.HasOne(d => d.S)
                    .WithOne(p => p.Advisor)
                    .HasForeignKey<Advisor>(d => d.SId)
                    .HasConstraintName("advisor_ibfk_2");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(e => new { e.Building, e.RoomNumber });

                entity.ToTable("classroom");

                entity.Property(e => e.Building)
                    .HasColumnName("building")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.RoomNumber)
                    .HasColumnName("room_number")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasColumnType("decimal(4,0)");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.HasIndex(e => e.DeptName)
                    .HasName("dept_name");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Credits)
                    .HasColumnName("credits")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.DeptName)
                    .HasColumnName("dept_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.DeptNameNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.DeptName)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("dept_name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptName);

                entity.ToTable("department");

                entity.Property(e => e.DeptName)
                    .HasColumnName("dept_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Budget)
                    .HasColumnName("budget")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.Building)
                    .HasColumnName("building")
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("instructor");

                entity.HasIndex(e => e.DeptName)
                    .HasName("dept_name");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.DeptName)
                    .HasColumnName("dept_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("decimal(8,2)");

                entity.HasOne(d => d.DeptNameNavigation)
                    .WithMany(p => p.Instructor)
                    .HasForeignKey(d => d.DeptName)
                    .HasConstraintName("instructor_ibfk_1");
            });

            modelBuilder.Entity<Prereq>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.PrereqId });

                entity.ToTable("prereq");

                entity.HasIndex(e => e.PrereqId)
                    .HasName("prereq_id");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.PrereqId)
                    .HasColumnName("prereq_id")
                    .HasColumnType("varchar(8)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PrereqCourse)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("prereq_ibfk_1");

                entity.HasOne(d => d.PrereqNavigation)
                    .WithMany(p => p.PrereqPrereqNavigation)
                    .HasForeignKey(d => d.PrereqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prereq_ibfk_2");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.SecId, e.Semester, e.Year });

                entity.ToTable("section");

                entity.HasIndex(e => new { e.Building, e.RoomNumber })
                    .HasName("building");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.SecId)
                    .HasColumnName("sec_id")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Semester)
                    .HasColumnName("semester")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("decimal(4,0)");

                entity.Property(e => e.Building)
                    .HasColumnName("building")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.RoomNumber)
                    .HasColumnName("room_number")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e.TimeSlotId)
                    .HasColumnName("time_slot_id")
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("section_ibfk_1");

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => new { d.Building, d.RoomNumber })
                    .HasConstraintName("section_ibfk_2");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.HasIndex(e => e.DeptName)
                    .HasName("dept_name");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.DeptName)
                    .HasColumnName("dept_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.TotCred)
                    .HasColumnName("tot_cred")
                    .HasColumnType("decimal(3,0)");

                entity.HasOne(d => d.DeptNameNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.DeptName)
                    .HasConstraintName("student_ibfk_1");
            });

            modelBuilder.Entity<Takes>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CourseId, e.SecId, e.Semester, e.Year });

                entity.ToTable("takes");

                entity.HasIndex(e => new { e.CourseId, e.SecId, e.Semester, e.Year })
                    .HasName("course_id");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.SecId)
                    .HasColumnName("sec_id")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Semester)
                    .HasColumnName("semester")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("decimal(4,0)");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasColumnType("varchar(2)");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("takes_ibfk_2");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => new { d.CourseId, d.SecId, d.Semester, d.Year })
                    .HasConstraintName("takes_ibfk_1");
            });

            modelBuilder.Entity<Teaches>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CourseId, e.SecId, e.Semester, e.Year });

                entity.ToTable("teaches");

                entity.HasIndex(e => new { e.CourseId, e.SecId, e.Semester, e.Year })
                    .HasName("course_id");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.SecId)
                    .HasColumnName("sec_id")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Semester)
                    .HasColumnName("semester")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("decimal(4,0)");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Teaches)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("teaches_ibfk_2");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Teaches)
                    .HasForeignKey(d => new { d.CourseId, d.SecId, d.Semester, d.Year })
                    .HasConstraintName("teaches_ibfk_1");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.HasKey(e => new { e.TimeSlotId, e.Day, e.StartHr, e.StartMin });

                entity.ToTable("time_slot");

                entity.Property(e => e.TimeSlotId)
                    .HasColumnName("time_slot_id")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.StartHr)
                    .HasColumnName("start_hr")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.StartMin)
                    .HasColumnName("start_min")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.EndHr)
                    .HasColumnName("end_hr")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.EndMin)
                    .HasColumnName("end_min")
                    .HasColumnType("decimal(2,0)");
            });

            modelBuilder.Entity<TTestMain>(entity =>
            {
                entity.ToTable("t_test_main");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<TTestSub>(entity =>
            {
                entity.ToTable("t_test_sub");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MainId)
                    .HasColumnName("main_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(10)");
            });
        }
    }
}
