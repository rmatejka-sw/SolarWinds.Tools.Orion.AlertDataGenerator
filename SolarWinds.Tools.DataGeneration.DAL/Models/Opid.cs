using System;

namespace SolarWinds.Tools.DataGeneration.DAL.Models
{
    public class Opid
    {
        private char opidSeparator = '_';

        public Opid(string opid)
        {
            var parts = opid.Split(opidSeparator, StringSplitOptions.TrimEntries);
            this.SiteId = Int32.Parse(parts[0]);
            this.EntityType = parts[1];
            this.EntityId= Int32.Parse(parts[2]);
        }

        public int SiteId { get; set; }
        public string EntityType { get; set; }
        public int EntityId { get; set; }
    }
}
