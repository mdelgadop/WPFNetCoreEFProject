using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface ICountryService : IDataService<CountryDto>
    {
        IEnumerable<RegionDto> GetAllRegions();

        IEnumerable<ContactDto> GetAllContacts();

        void GenerateExampleData();
    }
}
