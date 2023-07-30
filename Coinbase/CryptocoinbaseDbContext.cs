using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Coinbase;

public partial class CryptocoinbaseDbContext : DbContext
{
    public CryptocoinbaseDbContext()
    {
    }

    public CryptocoinbaseDbContext(DbContextOptions<CryptocoinbaseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ccprofiletable> Ccprofiletables { get; set; }

    public virtual DbSet<Cryptoloantable> Cryptoloantables { get; set; }

    public virtual DbSet<Cryptolocktable> Cryptolocktables { get; set; }

    public virtual DbSet<Cryptorecurringpurchasetable> Cryptorecurringpurchasetables { get; set; }

    public virtual DbSet<Cryptowalletdetailtable> Cryptowalletdetailtables { get; set; }

    public virtual DbSet<Cryptowallettable> Cryptowallettables { get; set; }

    public virtual DbSet<Logstable> Logstables { get; set; }

    public virtual DbSet<Settingtable> Settingtables { get; set; }

    public virtual DbSet<Transactiontable> Transactiontables { get; set; }

    public virtual DbSet<Useractivitytable> Useractivitytables { get; set; }

    public virtual DbSet<Usertable> Usertables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5110.site4now.net;Initial Catalog=db_a904c1_cryptolive;User Id=db_a904c1_cryptolive_admin;Password=F@nkar!1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ccprofiletable>(entity =>
        {
            entity.ToTable("CCProfiletable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ccnumber).HasColumnName("ccnumber");
            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Cvv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CVV");
            entity.Property(e => e.Expirydate)
                .HasColumnType("date")
                .HasColumnName("expirydate");
            entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Profiletoken).HasColumnName("profiletoken");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Cryptoloantable>(entity =>
        {
            entity.ToTable("Cryptoloantable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ccprofileid).HasColumnName("ccprofileid");
            entity.Property(e => e.Coinamount).HasColumnName("coinamount");
            entity.Property(e => e.Coinname).HasColumnName("coinname");
            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Cryptowalletid).HasColumnName("cryptowalletid");
            entity.Property(e => e.Loadfrequency).HasColumnName("loadfrequency");
            entity.Property(e => e.Loanenddate)
                .HasColumnType("date")
                .HasColumnName("loanenddate");
            entity.Property(e => e.Loanstartdate)
                .HasColumnType("date")
                .HasColumnName("loanstartdate");
            entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Cryptolocktable>(entity =>
        {
            entity.ToTable("Cryptolocktable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coinlockamount).HasColumnName("coinlockamount");
            entity.Property(e => e.Coinname).HasColumnName("coinname");
            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Cryptowalletid).HasColumnName("cryptowalletid");
            entity.Property(e => e.Lockenddate)
                .HasColumnType("date")
                .HasColumnName("lockenddate");
            entity.Property(e => e.Lockstartdate)
                .HasColumnType("date")
                .HasColumnName("lockstartdate");
            entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Cryptorecurringpurchasetable>(entity =>
        {
            entity.ToTable("Cryptorecurringpurchasetable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ccprofileid).HasColumnName("ccprofileid");
            entity.Property(e => e.Coinamount).HasColumnName("coinamount");
            entity.Property(e => e.Coinname).HasColumnName("coinname");
            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Cryptowalletid).HasColumnName("cryptowalletid");
            entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Recurringpurchaseenddate)
                .HasColumnType("date")
                .HasColumnName("recurringpurchaseenddate");
            entity.Property(e => e.Recurringpurchasefrequency).HasColumnName("recurringpurchasefrequency");
            entity.Property(e => e.Recurringpurchasestartdate)
                .HasColumnType("date")
                .HasColumnName("recurringpurchasestartdate");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Cryptowalletdetailtable>(entity =>
        {
            entity.ToTable("Cryptowalletdetailtable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coinamount).HasColumnName("coinamount");
            entity.Property(e => e.Coinname).HasColumnName("coinname");
            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Cryptowalletid).HasColumnName("cryptowalletid");
            entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
        });

        modelBuilder.Entity<Cryptowallettable>(entity =>
        {
            entity.ToTable("Cryptowallettable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Privatekey).HasColumnName("privatekey");
            entity.Property(e => e.Publickey).HasColumnName("publickey");
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Walletaddress).HasColumnName("walletaddress");
        });

        modelBuilder.Entity<Logstable>(entity =>
        {
            entity.ToTable("Logstable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apiname).HasColumnName("apiname");
            entity.Property(e => e.Createddate)
                .HasColumnType("date")
                .HasColumnName("createddate");
            entity.Property(e => e.Logdate)
                .HasColumnType("date")
                .HasColumnName("logdate");
            entity.Property(e => e.Logtype).HasColumnName("logtype");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Methodname).HasColumnName("methodname");
        });

        modelBuilder.Entity<Settingtable>(entity =>
        {
            entity.ToTable("Settingtable");

            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Settingkey).HasColumnName("settingkey");
            entity.Property(e => e.Settingvalue).HasColumnName("settingvalue");
        });

        modelBuilder.Entity<Transactiontable>(entity =>
        {
            entity.ToTable("Transactiontable");

            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Paymentsource)
                .HasMaxLength(50)
                .HasColumnName("paymentsource");
            entity.Property(e => e.Paymentsourcecurrency).HasColumnName("paymentsourcecurrency");
            entity.Property(e => e.Paymentsourceid).HasColumnName("paymentsourceid");
            entity.Property(e => e.Transactionamount).HasColumnName("transactionamount");
            entity.Property(e => e.Transactiondate)
                .HasColumnType("datetime")
                .HasColumnName("transactiondate");
            entity.Property(e => e.Transactiontype).HasColumnName("transactiontype");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Useractivitytable>(entity =>
        {
            entity.ToTable("Useractivitytable");

            entity.Property(e => e.Autologout)
                .HasMaxLength(50)
                .HasColumnName("autologout");
            entity.Property(e => e.Autologoutdate)
                .HasColumnType("datetime")
                .HasColumnName("autologoutdate");
            entity.Property(e => e.Createdbyid).HasColumnName("createdbyid");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.Endtime)
                .HasColumnType("datetime")
                .HasColumnName("endtime");
            entity.Property(e => e.Ip).HasColumnName("ip");
            entity.Property(e => e.Modifiedbyid).HasColumnName("modifiedbyid");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("datetime")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Os).HasColumnName("os");
            entity.Property(e => e.Source).HasColumnName("source");
            entity.Property(e => e.Startime)
                .HasColumnType("datetime")
                .HasColumnName("startime");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Usertable>(entity =>
        {
            entity.ToTable("Usertable");

            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Age)
                .HasMaxLength(50)
                .HasColumnName("age");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Emailaddress).HasColumnName("emailaddress");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
