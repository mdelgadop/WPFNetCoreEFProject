using System;
using Business.Entities;

namespace Business.Factories.Entities
{
    public class CountryFactory
    {
        public static Country Create()
        {
            Country element = new Country();
            return element;
        }

        public static Country Create(string code, string name)
        {
            return new Country()
            {
                Code = code,
                Name = name
            };
        }
    }
}