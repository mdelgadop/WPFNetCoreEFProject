using System;

namespace Business.Entities
{
    public class Market : GenericEntity
    {
         public string Code { get; set; }

         public Country Country { get; set; }
    }
}