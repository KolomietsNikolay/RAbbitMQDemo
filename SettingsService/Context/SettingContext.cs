using SettingsService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SettingsService.Context
{
    public class SettingContext : DbContext
    {
        public DbSet<QueuesSettings> QueuesSettings { get; set; }

        public DbSet<SettingForOneQueue> SettingForOneQueues { get; set; }

        public SettingContext():base("DefaultConnection")
        { }
    }
}