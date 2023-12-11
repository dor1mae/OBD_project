using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OBD;

public partial class OdbContext : DbContext
{
    public OdbContext()
    {
    }

    public OdbContext(DbContextOptions<OdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Directory> Directories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeToHall> EmployeeToHalls { get; set; }

    public virtual DbSet<Exhibit> Exhibits { get; set; }

    public virtual DbSet<Exhibition> Exhibitions { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<HallToExhibition> HallToExhibitions { get; set; }

    public virtual DbSet<Organizator> Organizators { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Settler> Settlers { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ODB;Username=dorimae;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Directory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directories_pkey");

            entity.ToTable("directories");

            entity.HasIndex(e => e.IdHall, "directories_id_hall_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descrip)
                .HasColumnType("character varying")
                .HasColumnName("descrip");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.IdHall).HasColumnName("id_hall");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.Weigth).HasColumnName("weigth");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.IdHallNavigation).WithOne(p => p.Directory)
                .HasForeignKey<Directory>(d => d.IdHall)
                .HasConstraintName("directories_id_hall_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.HasIndex(e => e.IdProf, "employees_id_prof_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FatherName)
                .HasColumnType("character varying")
                .HasColumnName("father_name");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.IdProf).HasColumnName("id_prof");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.SecondName)
                .HasColumnType("character varying")
                .HasColumnName("second_name");

            entity.HasOne(d => d.IdProfNavigation).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.IdProf)
                .HasConstraintName("employees_id_prof_fkey");
        });

        modelBuilder.Entity<EmployeeToHall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_to_hall_pkey");

            entity.ToTable("employee_to_hall");

            entity.HasIndex(e => new { e.IdEmp, e.IdHall }, "employee_to_hall_id_emp_id_hall_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEmp).HasColumnName("id_emp");
            entity.Property(e => e.IdHall).HasColumnName("id_hall");

            entity.HasOne(d => d.IdEmpNavigation).WithMany(p => p.EmployeeToHalls)
                .HasForeignKey(d => d.IdEmp)
                .HasConstraintName("employee_to_hall_id_emp_fkey");

            entity.HasOne(d => d.IdHallNavigation).WithMany(p => p.EmployeeToHalls)
                .HasForeignKey(d => d.IdHall)
                .HasConstraintName("employee_to_hall_id_hall_fkey");
        });

        modelBuilder.Entity<Exhibit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exhibits_pkey");

            entity.ToTable("exhibits");

            entity.HasIndex(e => e.IdOrg, "exhibits_id_org_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdOrg).HasColumnName("id_org");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.IdOrgNavigation).WithOne(p => p.Exhibit)
                .HasForeignKey<Exhibit>(d => d.IdOrg)
                .HasConstraintName("exhibits_id_org_fkey");
        });

        modelBuilder.Entity<Exhibition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exhibitions_pkey");

            entity.ToTable("exhibitions");

            entity.HasIndex(e => e.IdOrg, "exhibitions_id_org_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdOrg).HasColumnName("id_org");
            entity.Property(e => e.NumberTickets).HasColumnName("number_tickets");
            entity.Property(e => e.TimeOfEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_of_end");
            entity.Property(e => e.TimeOfStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_of_start");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.IdOrgNavigation).WithOne(p => p.Exhibition)
                .HasForeignKey<Exhibition>(d => d.IdOrg)
                .HasConstraintName("exhibitions_id_org_fkey");
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("halls_pkey");

            entity.ToTable("halls");

            entity.HasIndex(e => e.IdExhibit, "halls_id_exhibit_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdExhibit).HasColumnName("id_exhibit");
            entity.Property(e => e.NumberExhibits).HasColumnName("number_exhibits");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.IdExhibitNavigation).WithOne(p => p.Hall)
                .HasForeignKey<Hall>(d => d.IdExhibit)
                .HasConstraintName("halls_id_exhibit_fkey");
        });

        modelBuilder.Entity<HallToExhibition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hall_to_exhibitions_pkey");

            entity.ToTable("hall_to_exhibitions");

            entity.HasIndex(e => new { e.IdExh, e.IdHall }, "hall_to_exhibitions_id_exh_id_hall_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdExh).HasColumnName("id_exh");
            entity.Property(e => e.IdHall).HasColumnName("id_hall");

            entity.HasOne(d => d.IdExhNavigation).WithMany(p => p.HallToExhibitions)
                .HasForeignKey(d => d.IdExh)
                .HasConstraintName("hall_to_exhibitions_id_exh_fkey");

            entity.HasOne(d => d.IdHallNavigation).WithMany(p => p.HallToExhibitions)
                .HasForeignKey(d => d.IdHall)
                .HasConstraintName("hall_to_exhibitions_id_hall_fkey");
        });

        modelBuilder.Entity<Organizator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organizators_pkey");

            entity.ToTable("organizators");

            entity.HasIndex(e => e.IdDirectory, "organizators_id_directory_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasColumnType("character varying")
                .HasColumnName("adress");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.IdDirectory).HasColumnName("id_directory");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .HasColumnName("phone");

            entity.HasOne(d => d.IdDirectoryNavigation).WithOne(p => p.Organizator)
                .HasForeignKey<Organizator>(d => d.IdDirectory)
                .HasConstraintName("organizators_id_directory_fkey");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("professions_pkey");

            entity.ToTable("professions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.Worktime)
                .HasColumnType("character varying")
                .HasColumnName("worktime");
        });

        modelBuilder.Entity<Settler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("settlers_pkey");

            entity.ToTable("settlers");

            entity.HasIndex(e => e.IdTicket, "settlers_id_ticket_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birth)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birth");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FatherName)
                .HasColumnType("character varying")
                .HasColumnName("father_name");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.IdTicket).HasColumnName("id_ticket");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .HasColumnName("phone");
            entity.Property(e => e.SecondName)
                .HasColumnType("character varying")
                .HasColumnName("second_name");

            entity.HasOne(d => d.IdTicketNavigation).WithOne(p => p.Settler)
                .HasForeignKey<Settler>(d => d.IdTicket)
                .HasConstraintName("settlers_id_ticket_fkey");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.HasIndex(e => e.IdExhibition, "tickets_id_exhibition_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Day)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("day");
            entity.Property(e => e.IdExhibition).HasColumnName("id_exhibition");

            entity.HasOne(d => d.IdExhibitionNavigation).WithOne(p => p.Ticket)
                .HasForeignKey<Ticket>(d => d.IdExhibition)
                .HasConstraintName("tickets_id_exhibition_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
