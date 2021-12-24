using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing_System.Models;

namespace Ticketing_System.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext>options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Accounts_Has_Role> Accounts_Has_Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HistoryChat> HistoryChats { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Reply> Replies{ get; set; }
        public DbSet<Report> Reports{ get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<TechnicalSupport> TechnicalSupports{ get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tracking> Trackings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to one relation employee to account
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Account)
                .WithOne(e => e.Employee)
                .HasForeignKey<Account>(e => e.IdEmployee);

            modelBuilder.Entity<Employee>()
               .HasOne(tc => tc.TechnicalSupport)
               .WithOne(e => e.Employee)
               .HasForeignKey<TechnicalSupport>(e => e.IdEmployee);

            //one to one relation Ticket to Tracking
            modelBuilder.Entity<Ticket>()
                .HasOne(tr => tr.Tracking)
                .WithOne(t => t.Ticket)
                .HasForeignKey<Tracking>(t => t.IdTicket);


            //one to one relation Technical to Kategori
            modelBuilder.Entity<TechnicalSupport>()
                .HasOne(k => k.Kategori)
                .WithOne(ts => ts.TechnicalSupport)
                .HasForeignKey<Kategori>(k => k.IdEmployee);

            //one to one relation Technical to Tracking
            modelBuilder.Entity<TechnicalSupport>()
                .HasOne(tr => tr.Tracking)
                .WithOne(ts => ts.TechnicalSupport)
                .HasForeignKey<Tracking>(k => k.IdEmployee);



            //one to one relation Ticket to Tracking
            modelBuilder.Entity<Ticket>()
                .HasOne(r => r.Report)
                .WithOne(t => t.Ticket)
                .HasForeignKey<Report>(t => t.IdTicket);

            //onr to Many relation Employee to Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(e => e.Employee)
                .WithMany(t => t.Tickets);

            //one to Many relation Kategori to Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(k => k.Kategori)
                .WithMany(t => t.Tickets);

            //one to Many relation Technical to Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(tc=>tc.TechnicalSupport)
                .WithMany(t=>t.Tickets);

            //one to Many relation ticket to History chat
            modelBuilder.Entity<HistoryChat>()
                .HasOne(t => t.Ticket)
                .WithMany(hc => hc.HistoryChats);

            //one to Many relation ticket to History chat
            modelBuilder.Entity<Message>()
                .HasOne(hc => hc.HistoryChat)
                .WithMany(m => m.Messages);

            //one to Many relation ticket to History chat
            modelBuilder.Entity<Reply>()
                .HasOne(hc => hc.HistoryChat)
                .WithMany(rp => rp.Replys);

            modelBuilder.Entity<Accounts_Has_Role>()
              .HasKey(bc => new { bc.IdEmployee, bc.IdRole });
            modelBuilder.Entity<Accounts_Has_Role>()
                .HasOne(bc => bc.Account)
                .WithMany(b => b.Accounts_Has_Roles)
                .HasForeignKey(bc => bc.IdEmployee);
            modelBuilder.Entity<Accounts_Has_Role>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.Account_Has_Roles)
                .HasForeignKey(bc => bc.IdRole);

            /*
                        //one to Many relation Role to AccountHasRole
                        modelBuilder.Entity<Accounts_Has_Role>()
                            .HasOne(ro => ro.Role)
                            .WithMany(ar => ar.Account_Has_Roles);

                        //one to Many relation Account to Role
                        modelBuilder.Entity<Accounts_Has_Role>()
                            .HasOne(a => a.Account)
                            .WithMany(ar => ar.Accounts_Has_Roles);*/


        }



    }
}
