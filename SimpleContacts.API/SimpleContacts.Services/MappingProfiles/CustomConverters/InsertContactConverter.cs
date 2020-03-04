using System;
using AutoMapper;
using SimpleContacts.Entities.Entities;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.MappingProfiles.CustomConverters
{
    public class InsertContactConverter : ITypeConverter<InsertContactViewModel, Contact>
    {
        public Contact Convert(InsertContactViewModel source, Contact destination, ResolutionContext context)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Email = source.Email,
                Skype = source.Skype,
                LinkedIn = source.LinkedIn,
                Telegram = source.Telegram,
                Facebook = source.Facebook,
                PreferableMethod = source.PreferableMethod
            };

            return contact;
        }
    }
}
