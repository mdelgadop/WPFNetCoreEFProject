using System;
using Business.Entities;

namespace Business.Factories.Entities
{
    public class ContactFactory
    {
        public static Contact Create()
        {
            Contact element = new Contact();
            return element;
        }

        public static Contact Create(string code, string name)
        {
            return new Contact()
            {
                Code = code,
                Name = name
            };
        }
    }
}