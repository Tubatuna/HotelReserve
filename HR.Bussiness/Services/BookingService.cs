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
    public class BookingService : IManager<Booking>
    {
        private readonly BookingRepostory _bRepostory;
        public BookingService(BookingRepostory bookingRepostory)
        {
            _bRepostory = bookingRepostory;
        }
        public void Add(Booking entity)
        {
            BookingValidator bVal = new BookingValidator();
            ValidationResult result = bVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            _bRepostory.Add(entity);
        }

        public void Delete(Booking entity)
        {
            _bRepostory.Delete(entity.Id);
        }

        public List<Booking> GetAll()
        {
           return _bRepostory.GetAll();
        }

        public Booking GetByID(Guid id)
        {
            return _bRepostory.GetByID(b=>b.Id == id);
        }

        public void Update(Booking entity)
        {
            _bRepostory.Update(entity);
        }
    }
}
