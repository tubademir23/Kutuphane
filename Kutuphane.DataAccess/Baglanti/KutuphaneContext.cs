﻿using Kutuphane.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kutuphane.DataAccess.Haritalar;

namespace Kutuphane.DataAccess.Baglanti
{
    public class KutuphaneContext : DbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Barkod> Barkodlar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Telefon> Telefonlar { get; set; }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<KitapHareket> KitapHareketleri { get; set; }
        public DbSet<Tanim> Tanimlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Haritalama İşlemleri
            modelBuilder.Configurations.Add(new KitapMap());
            modelBuilder.Configurations.Add(new BarkodMap());
            modelBuilder.Configurations.Add(new YazarMap());
            modelBuilder.Configurations.Add(new UyeMap());
            modelBuilder.Configurations.Add(new SinifMap());
            modelBuilder.Configurations.Add(new TelefonMap());
            modelBuilder.Configurations.Add(new AdresMap());
            modelBuilder.Configurations.Add(new KitapHareketMap());
            modelBuilder.Configurations.Add(new TanimMap());
            //İlişkilerin Tanımlanması
            modelBuilder.Entity<Kitap>().HasRequired(c => c.Yazar).WithMany(c => c.Kitaplar)
                .HasForeignKey(c => c.YazarId);
            modelBuilder.Entity<Barkod>().HasRequired(c => c.Kitap).WithMany(c => c.Barkodlar)
                .HasForeignKey(c => c.KitapId).WillCascadeOnDelete();
            modelBuilder.Entity<KitapHareket>().HasRequired(c => c.Kitap).WithMany(c => c.KitapHareketleri)
                .HasForeignKey(c => c.KitapId);
            modelBuilder.Entity<Uye>().HasRequired(c => c.Sinif).WithMany(c => c.Uyeler)
                .HasForeignKey(c => c.SinifId);
            modelBuilder.Entity<Telefon>().HasRequired(c => c.Uye).WithMany(c => c.Telefonlar)
                .HasForeignKey(c => c.UyeId);
            modelBuilder.Entity<Adres>().HasRequired(c => c.Uye).WithMany(c => c.Adresler)
                .HasForeignKey(c => c.UyeId);
            modelBuilder.Entity<KitapHareket>().HasRequired(c => c.Uye).WithMany(c => c.KitapHareketleri)
                .HasForeignKey(c => c.UyeId);
            modelBuilder.Entity<KitapHareket>().HasRequired(c => c.Barkod).WithMany(c => c.KitapHareketleri)
                .HasForeignKey(c => c.BarkodId).WillCascadeOnDelete(false);

        }
    }
}
