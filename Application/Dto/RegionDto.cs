using System;

namespace Application.Dtos
{
    public class RegionDto : GenericDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Code, Name);
        }
    }
}