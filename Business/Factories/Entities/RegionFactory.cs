using System;
using Business.Entities;

namespace Business.Factories.Entities
{
    public class RegionFactory
    {
        public static Region Create()
        {
            Region element = new Region();
            return element;
        }

        public static Region Create(string code, string name)
        {
            return new Region()
            {
                Code = code,
                Name = name
            };
        }
    }
}