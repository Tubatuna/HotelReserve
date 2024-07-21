using FluentValidation.Results;
using HR.Bussiness.Abstract;
using HR.Bussiness.Validations;
using HR.DataAccess.Repostories;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Services
{
    public class HotelService : IManager<Hotel>
    {
        private readonly HotelRepostory _hRepostory;
        public HotelService(HotelRepostory hotelRepostory)
        {
            _hRepostory = hotelRepostory;
        }
        public void Add(Hotel entity)
        {
            HotelValidator hVal = new HotelValidator();
            ValidationResult result = hVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            _hRepostory.Add(entity);
        }

        public void Delete(Hotel entity)
        {
            _hRepostory.Delete(entity);
        }

        public List<Hotel> GetAll()
        {
            return _hRepostory.GetAll();
        }

        public Hotel GetByID(Guid id)
        {
            return _hRepostory.GetByID(h => h.Id == id);
        }

        public void Update(Hotel entity)
        {
            _hRepostory.Update(entity);
        }
    }
}
