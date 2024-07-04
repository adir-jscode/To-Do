using MidLabExam.DTOs;
using MidLabExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidLabExam.Mapper
{
    public class UserMapper : IMapper<User, RegistrationDTO>
    {
        public User Map(RegistrationDTO entity)
        {
            var name = entity.FirstName.Trim() + " " + entity.LastName.Trim();
            var address = entity.HouseNo.Trim() + ", " + entity.Street.Trim() + ", " + entity.City.Trim() + ", " + entity.PostalCode.Trim();
            return new User
            {
                Name = name,
                Email = entity.Email,
                Password = entity.Password,
                Address = address,
                Phone = entity.Phone
            };
        }

        public RegistrationDTO Map(User entity)
        {
            return new RegistrationDTO()
            {
                FirstName = entity.Name.Split(' ')[0],
                LastName = entity.Name.Split(' ')[1],
                Email = entity.Email,
                Password = entity.Password,
                HouseNo = entity.Address.Split(',')[0],
                Street = entity.Address.Split(',')[1],
                City = entity.Address.Split(',')[2],
                PostalCode = entity.Address.Split(',')[3],
                Phone = entity.Phone
            };
        }

        public List<RegistrationDTO> Map(List<User> entities)
        {
            throw new NotImplementedException();
        }
    }
}