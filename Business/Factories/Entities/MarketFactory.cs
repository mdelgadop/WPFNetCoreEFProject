using System;
using Business.Entities;

namespace Business.Factories.Entities
{
    public class MarketFactory
    {
        public static Market Create()
        {
            Market element = new Market();
            return element;
        }

        public static Market Create(string code)
        {
            return new Market()
            {
                Code = code
            };
        }
    }
}