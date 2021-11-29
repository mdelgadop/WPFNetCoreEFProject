using Application.Dtos;
using Application.Factories.Mappers;
using Application.Mappers;
using Business.Entities;
using Business.Factories.Entities;
using Business.Factories.Repositories;
using Business.Repositories;
using Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CountryService : ICountryService
    {
        #region Properties

        #region Repositories
        private IRepository<Country> Repository { get; set; }
        private IRepository<Region> RegionRepository { get; set; }
        private IRepository<Contact> ContactRepository { get; set; }
        #endregion Repositories

        #region Mappers
        private IMapper<Country, CountryDto> CountryMapper { get; set; }
        private IMapper<Region, RegionDto> RegionMapper { get; set; }
        private IMapper<Contact, ContactDto> ContactMapper { get; set; }
        #endregion Mappers

        #endregion Properties

        internal CountryService(IRepository<Country> repository, IRepository<Region> regionRepository, IRepository<Contact> contactRepository)
        {
            Repository = repository;
            RegionRepository = regionRepository;
            ContactRepository = contactRepository;

            CountryMapper = CountryMapperFactory.Create();
            RegionMapper = RegionMapperFactory.Create();
            ContactMapper = ContactMapperFactory.Create();
        }

        public CountryDto Create(CountryDto element)
        {
            try
            {
                Repository.Add(CountryMapper.DtoToEntity(element));

                Country newEntity = Repository.LastElementAdded();

                if (newEntity == null)
                    throw new ElementCannotBeAddedException();
                
                CountryDto elementAdded = CountryMapper.EntityToDto(newEntity);
                return elementAdded;
            }
            catch(Exception ex)
            {
                //TODO Add Log
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Country country = CountryFactory.Create();
                country.Id = id;
                Repository.Remove(country);
                return true;
            }
            catch(Exception ex)
            {
                //TODO Add Log
                throw ex;
            }
        }

        public CountryDto Get(int id)
        {
            Country entity = Repository.GetById(id);
            if (entity == null)
                return null;

            CountryDto element = CountryMapper.EntityToDto(entity);

            return element;
        }

        public IEnumerable<CountryDto> GetAll()
        {
            IEnumerable<CountryDto> countries = CountryMapper.EntitiesToDto(Repository.GetAll());
            return countries;
        }

        public CountryDto Update(int id, CountryDto element)
        {
            CountryDto created = null;

            try
            {
                element.Id = id;
                Repository.Save(CountryMapper.DtoToEntity(element));
                return created;
            }
            catch(Exception ex)
            {
                //TODO Add Log
                throw ex;
            }
        }

        public IEnumerable<RegionDto> GetAllRegions()
        {
            IEnumerable<RegionDto> countries = RegionMapper.EntitiesToDto(RegionRepository.GetAll());
            return countries;
        }

        public IEnumerable<ContactDto> GetAllContacts()
        {
            IEnumerable<ContactDto> countries = ContactMapper.EntitiesToDto(ContactRepository.GetAll());
            return countries;
        }

        public void GenerateExampleData()
        {
            #region Examples

            #region Regions

            RegionRepository.Add(new Region() { Code = "01", Name = "Europe" });
            RegionRepository.Add(new Region() { Code = "02", Name = "Asia" });
            RegionRepository.Add(new Region() { Code = "03", Name = "America" });
            RegionRepository.Add(new Region() { Code = "04", Name = "Oceania" });
            RegionRepository.Add(new Region() { Code = "05", Name = "North Pole" });
            RegionRepository.Add(new Region() { Code = "06", Name = "South Pole" });

            #endregion Examples

            #region Contacts

            ContactRepository.Add(new Contact() { Code = "01", Name = "Contact 01" });
            ContactRepository.Add(new Contact() { Code = "02", Name = "Contact 02" });
            ContactRepository.Add(new Contact() { Code = "03", Name = "Contact 03" });

            #endregion Contacts

            #region Countries
            Repository.Add(
                new Country()
                {
                    Code = "ES",
                    Name = "Spain",
                    Region = RegionRepository.GetById(1),
                    Contact = ContactRepository.GetById(1),
                    BackupContact = ContactRepository.GetById(2)
                }
            );

            Repository.Add(
                new Country()
                {
                    Code = "UK",
                    Name = "United Kingdom",
                    Region = RegionRepository.GetById(1),
                    Contact = ContactRepository.GetById(2),
                    BackupContact = ContactRepository.GetById(3)
                }
            );

            Repository.Add(
                new Country()
                {
                    Code = "PE",
                    Name = "Peru",
                    Region = RegionRepository.GetById(3),
                    Contact = ContactRepository.GetById(1),
                    BackupContact = ContactRepository.GetById(3)
                }
            );
            #endregion Countries

            #endregion Examples

        }
    }
}
