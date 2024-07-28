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
    public class RoomService : IManager<Room>
    {
        private readonly RoomRepostory _rRepostory;
        public RoomService(RoomRepostory roomRepostory)
        {
            _rRepostory = roomRepostory;
            
        }
        public void Add(Room entity)
        {
            RoomValidator rVal = new RoomValidator();
            ValidationResult result = rVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            _rRepostory.Add(entity);

        }

        public void Delete(Room entity)
        {
            _rRepostory.Delete(entity.Id);
        }

        public List<Room> GetAll()
        {
            return _rRepostory.GetAll();
        }

        public Room GetByID(Guid id)
        {
            return _rRepostory.GetByID(r=>r.Id==id);
        }

        public void Update(Room entity)
        {
           _rRepostory.Update(entity);
        }
    }
}
