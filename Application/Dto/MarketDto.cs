using System;

namespace Application.Dtos
{
    public class MarketDto : GenericDto
    {
         public string Code { get; set; }

         public CountryDto Country { get; set; }
    }
}