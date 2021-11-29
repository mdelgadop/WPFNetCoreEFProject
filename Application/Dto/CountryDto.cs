using System;

namespace Application.Dtos
{
    public class CountryDto : GenericDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public RegionDto Region { get; set; }

        public ContactDto Contact { get; set; }
		
		public ContactDto BackupContact { get; set; }
    }
}