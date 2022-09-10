﻿using EmployeeAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Employee> Employees  { get; set; }
        public DbSet<Dept> Depts { get; set; }
        public DbSet<User>Users { get; set; }
    }
}
