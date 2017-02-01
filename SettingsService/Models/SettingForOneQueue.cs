using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SettingsService.Models
{
    public class SettingForOneQueue
    {
        public int ID { get; set; }

        public string Queue { get; set; }

        public virtual ICollection<QueuesSettings> QueusSettings { get; set; }
    }
}