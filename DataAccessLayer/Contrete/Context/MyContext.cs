using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer.Concrete;

namespace DataAccessLayer.Contrete.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=ILQAR\SQLEXPRESS01; Database=KhanResume; Integrated Security = true; MultipleActiveResultSets = True");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-TROAMS4; Database=Khan; Integrated Security = true; MultipleActiveResultSets = True");
            optionsBuilder.UseSqlServer(@"workstation id=KhanResume.mssql.somee.com;packet size=4096;user id=Orkhan3_SQLLogin_1;pwd=pfmnwhhqdd;data source=KhanResume.mssql.somee.com;persist security info=False;initial catalog=KhanResume; MultipleActiveResultSets = True");

        }

        public DbSet<Profil> Profils { get; set; }
        public DbSet<CVDocument> CVDocuments { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<OtherKnowledge> OtherKnowledges { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Sosial> Sosials { get; set; }
        public DbSet<Adress> Adresses { get; set; }

    }
}
