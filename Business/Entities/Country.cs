using System;

namespace Business.Entities
{
    public class Country : GenericEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Region Region { get; set; }

        public Contact Contact { get; set; }
		
		public Contact BackupContact { get; set; }
    }
}