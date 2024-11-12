using System;
using System.Collections.Generic;
using AOA.Connection.Entities;
using Microsoft.EntityFrameworkCore;

namespace AOA.Connection;

public partial class EfModel : DbContext
{
    private static EfModel Instance { get; set; }
    public static EfModel Init()
    {
       
            if (Instance == null)
                Instance = new EfModel();
            return Instance;
       
       
    }
    public EfModel()
    {
    }

    public EfModel(DbContextOptions<EfModel> options)
        : base(options)
    {
    }
    public virtual DbSet<OfferType> OfferTypes { get; set; }
    public virtual DbSet<News> News { get; set; }
    public virtual DbSet<User> Users { get; set; }    
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Offer> Offers { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=agafonov;password=G3ua3u;database=agafonov_LeaHolding;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<User>(entity =>
        entity.HasIndex(e => e.Login).IsUnique(true));
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
