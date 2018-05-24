using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace QuanLyHocSinh.DAL.Model
{
    public partial class QuanLyHocSinhSqlContext : DbContext
    {
        private IConfiguration _configuration;
        private readonly string connectionString = "Server=.;Database=QuanLyHocSinh;Trusted_Connection=True;";
        public QuanLyHocSinhSqlContext(DbContextOptions<QuanLyHocSinhSqlContext> options) : base(options)
        {
        }
        public QuanLyHocSinhSqlContext()
        {
        }

        #region Set DBSet model
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Gradelevel> Gradelevel { get; set; }
        public virtual DbSet<Learningoutcomes> Learningoutcomes { get; set; }
        public virtual DbSet<Schoolyear> Schoolyear { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studentinclass> Studentinclass { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Testscores> Testscores { get; set; }
        public virtual DbSet<Typeaccount> Typeaccount { get; set; }
        public virtual DbSet<Typeresult> Typeresult { get; set; }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);
               
                entity.ToTable("ACCOUNT");
               
                entity.HasIndex(e => e.Idtype)
                    .HasName("FK_TYPEACCOUNT_IN_ACCOUNT_FK");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Idtype).HasColumnName("IDTYPE");

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdtypeNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.Idtype)
                    .HasConstraintName("FK_ACCOUNT_TYPEACCOUNT");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Idclass);

                entity.ToTable("CLASS");

                entity.HasIndex(e => e.Gradelevelid)
                    .HasName("FK_CLASS_IN_GRADELEVEL_FK");

                entity.Property(e => e.Idclass)
                    .HasColumnName("IDCLASS")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Gradelevelid).HasColumnName("GRADELEVELID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gradelevel)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.Gradelevelid)
                    .HasConstraintName("FK_CLASS_GRADELEVEL");
            });

            modelBuilder.Entity<Gradelevel>(entity =>
            {
                entity.ToTable("GRADELEVEL");

                entity.Property(e => e.Gradelevelid).HasColumnName("GRADELEVELID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Learningoutcomes>(entity =>
            {
                entity.ToTable("LEARNINGOUTCOMES");

                entity.HasIndex(e => e.Mshocsinh)
                    .HasName("RELATIONSHIP_6_FK");

                entity.HasIndex(e => e.Schoolyearid)
                    .HasName("FK_FK");

                entity.HasIndex(e => e.Typeresultid)
                    .HasName("FK_TR_IN_LO");

                entity.Property(e => e.Learningoutcomesid)
                    .HasColumnName("LEARNINGOUTCOMESID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Conduct)
                    .HasColumnName("CONDUCT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .HasColumnName("GRADE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mediumscore).HasColumnName("MEDIUMSCORE");

                entity.Property(e => e.Mshocsinh)
                    .HasColumnName("MSHOCSINH")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Schoolyearid)
                    .HasColumnName("SCHOOLYEARID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Typeresultid)
                    .HasColumnName("TYPERESULTID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MshocsinhNavigation)
                    .WithMany(p => p.Learningoutcomes)
                    .HasForeignKey(d => d.Mshocsinh)
                    .HasConstraintName("FK_LEARNINGOUTCOMES_STUDENT");

                entity.HasOne(d => d.Schoolyear)
                    .WithMany(p => p.Learningoutcomes)
                    .HasForeignKey(d => d.Schoolyearid)
                    .HasConstraintName("FK_LEARNINGOUTCOMES_SCHOOLYEAR");

                entity.HasOne(d => d.Typeresult)
                    .WithMany(p => p.Learningoutcomes)
                    .HasForeignKey(d => d.Typeresultid)
                    .HasConstraintName("FK_LEARNINGOUTCOMES_TYPERESULT");
            });

            modelBuilder.Entity<Schoolyear>(entity =>
            {
                entity.ToTable("SCHOOLYEAR");

                entity.Property(e => e.Schoolyearid)
                    .HasColumnName("SCHOOLYEARID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("SEMESTER");

                entity.Property(e => e.Semesterid).HasColumnName("SEMESTERID");

                entity.Property(e => e.Coefficient).HasColumnName("COEFFICIENT");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Mshocsinh);

                entity.ToTable("STUDENT");

                entity.Property(e => e.Mshocsinh)
                    .HasColumnName("MSHOCSINH")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday)
                    .HasColumnName("BIRTHDAY")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Sex).HasColumnName("SEX");
            });

            modelBuilder.Entity<Studentinclass>(entity =>
            {
                entity.HasKey(e => new { e.Schoolyearid, e.Idclass, e.Mshocsinh });

                entity.ToTable("STUDENTINCLASS");

                entity.HasIndex(e => e.Idclass)
                    .HasName("STUDENTINCLASS2_FK");

                entity.HasIndex(e => e.Mshocsinh)
                    .HasName("STUDENTINCLASS3_FK");

                entity.HasIndex(e => e.Schoolyearid)
                    .HasName("STUDENTINCLASS_FK");

                entity.Property(e => e.Schoolyearid)
                    .HasColumnName("SCHOOLYEARID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idclass)
                    .HasColumnName("IDCLASS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mshocsinh)
                    .HasColumnName("MSHOCSINH")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdclassNavigation)
                    .WithMany(p => p.Studentinclass)
                    .HasForeignKey(d => d.Idclass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTINCLASS_CLASS");

                entity.HasOne(d => d.MshocsinhNavigation)
                    .WithMany(p => p.Studentinclass)
                    .HasForeignKey(d => d.Mshocsinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STUDENTIN__MSHOC__5AEE82B9");

                entity.HasOne(d => d.Schoolyear)
                    .WithMany(p => p.Studentinclass)
                    .HasForeignKey(d => d.Schoolyearid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENTINCLASS_SCHOOLYEAR");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("SUBJECT");

                entity.Property(e => e.Subjectid)
                    .HasColumnName("SUBJECTID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Testscores>(entity =>
            {
                entity.HasKey(e => new { e.Subjectid, e.Semesterid, e.Schoolyearid, e.Mshocsinh });

                entity.ToTable("TESTSCORES");

                entity.HasIndex(e => e.Mshocsinh)
                    .HasName("TESTSCORES4_FK");

                entity.HasIndex(e => e.Schoolyearid)
                    .HasName("TESTSCORES3_FK");

                entity.HasIndex(e => e.Semesterid)
                    .HasName("TESTSCORES2_FK");

                entity.HasIndex(e => e.Subjectid)
                    .HasName("TESTSCORES_FK");

                entity.Property(e => e.Subjectid)
                    .HasColumnName("SUBJECTID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Semesterid).HasColumnName("SEMESTERID");

                entity.Property(e => e.Schoolyearid)
                    .HasColumnName("SCHOOLYEARID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Mshocsinh)
                    .HasColumnName("MSHOCSINH")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Score15m).HasColumnName("SCORE_15M");

                entity.Property(e => e.Score45m).HasColumnName("SCORE_45M");

                entity.Property(e => e.Score5m).HasColumnName("SCORE_5M");

                entity.Property(e => e.ScoreEndyear).HasColumnName("SCORE_ENDYEAR");

                entity.Property(e => e.ScoreMidyear).HasColumnName("SCORE_MIDYEAR");

                entity.HasOne(d => d.MshocsinhNavigation)
                    .WithMany(p => p.Testscores)
                    .HasForeignKey(d => d.Mshocsinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTSCORES_STUDENT");

                entity.HasOne(d => d.Schoolyear)
                    .WithMany(p => p.Testscores)
                    .HasForeignKey(d => d.Schoolyearid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTSCORES_SCHOOLYEAR");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Testscores)
                    .HasForeignKey(d => d.Semesterid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTSCORES_SEMESTER");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Testscores)
                    .HasForeignKey(d => d.Subjectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TESTSCORES_SUBJECT");
            });

            modelBuilder.Entity<Typeaccount>(entity =>
            {
                entity.HasKey(e => e.Idtype);

                entity.ToTable("TYPEACCOUNT");

                entity.Property(e => e.Idtype).HasColumnName("IDTYPE");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Typeresult>(entity =>
            {
                entity.ToTable("TYPERESULT");

                entity.Property(e => e.Typeresultid)
                    .HasColumnName("TYPERESULTID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
