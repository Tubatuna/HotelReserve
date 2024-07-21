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
    public class RoomTypeService : IManager<RoomType>
    {
        private readonly RoomTypeRepostory _rTypeRepo;
        public RoomTypeService(RoomTypeRepostory roomTypeRepostory)
        {
            _rTypeRepo = roomTypeRepostory; 
        }
        public void Add(RoomType entity)
        {
            RoomTypeValidator rtVal = new RoomTypeValidator();
            ValidationResult result = rtVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            _rTypeRepo.Add(entity);
        }

        public void Delete(RoomType entity)
        {
            _rTypeRepo.Delete(entity);
        }

        public List<RoomType> GetAll()
        {
            return _rTypeRepo.GetAll();
        }

        public RoomType GetByID(Guid id)
        {
           return _rTypeRepo.GetByID(r=>r.Id == id);    
        }

        public void Update(RoomType entity)
        {
            _rTypeRepo.Update(entity);
        }
    }
}
