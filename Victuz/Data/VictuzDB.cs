﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using Victuz.Models;
using Microsoft.EntityFrameworkCore;

namespace Victuz.Data
{
    public class VictuzDB : DbContext
    {
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Proposition> Proposition { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=asusdrg4n\sqldrg4n;Initial Catalog=VictuzDB;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //specify Activity
            modelBuilder.Entity<Activity>()
                .Property(v => v.Name)
                .HasMaxLength(30);

            //specify Agenda
            modelBuilder.Entity<Agenda>()
                .Property(v => v.Name)
                .HasMaxLength(30);

            //specify Member
            modelBuilder.Entity<Member>()
                .Property(v => v.Name)
                .HasMaxLength(30);

            //specify Proposition
            modelBuilder.Entity<Proposition>()
                .Property(v => v.Name)
                .HasMaxLength(30);

            //specify Status
            modelBuilder.Entity<Status>()
                .Property(v => v.Name)
                .HasMaxLength(30);

            //data seed Activity
            Activity activityEntity = new Activity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                Date = DateTime.Now,
                Location = "Test room",
                Category = "Workshop"
            };
            modelBuilder.Entity<Activity>()
                .HasData(activityEntity);

            //data seed Agenda
            Agenda agendaEntity = new Agenda()
            {
                Id = 1,
                Name = "Test",
                Date = DateTime.Now
            };
            modelBuilder.Entity<Agenda>()
                .HasData(agendaEntity);

            //data seed Member
            Member memberEntity = new Member()
            {
                Id = 1,
                Name = "Test",
                LastName = "Dummy",
                Email = "Test@Gmail.com",
                ScreenName = "Tester",
                Board = true
            };
            modelBuilder.Entity<Member>()
                .HasData(memberEntity);

            //data seed Proposition
            Proposition propositionEntity = new Proposition()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Date = DateTime.Now,
                MemberName = "Test",
                Status = "In Progress"
            };
            modelBuilder.Entity<Proposition>()
                .HasData(propositionEntity);

            //data seed Status
            Status statusEntity = new Status()
            {
                Id = 1,
                Name = "In Progress",
                Description = "Test"
            };
            modelBuilder.Entity<Status>()
                .HasData(statusEntity);
        }
    }
}