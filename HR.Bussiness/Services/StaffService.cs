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
    public class StaffService : IManager<Staff>
    {
        private readonly StaffRepostory _sRepostory;
        public StaffService(StaffRepostory staffRepostory)
        {
            _sRepostory = staffRepostory;
        }
        public void Add(Staff entity)
        {
            StaffValidator sVal= new StaffValidator();
            ValidationResult result= sVal.Validate(entity);
            if (!result.IsValid) 
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            
            _sRepostory.Add(entity);
        }

        public void Delete(Staff entity)
        {
            _sRepostory.Delete(entity);
        }

        public List<Staff> GetAll()
        {
            return _sRepostory.GetAll();
        }

        public Staff GetByID(Guid id)
        {
            return _sRepostory.GetByID(s=>s.Id == id);
        }

        public void Update(Staff entity)
        {
            _sRepostory.Update(entity);
        }
    }
}
