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
    public class GuestService : IManager<Guest>
    {
        private readonly GuestRepostory gRepostory;
        public GuestService(GuestRepostory guestRepostory)
        {
            gRepostory= guestRepostory;
        }
        public void Add(Guest entity)
        {
            GuestValidator gVal = new GuestValidator();
            ValidationResult result = gVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            gRepostory.Add(entity);
        }

        public void Delete(Guest entity)
        {
            gRepostory.Delete(entity);
        }

        public List<Guest> GetAll()
        {
            return gRepostory.GetAll();
        }

        public Guest GetByID(Guid id)
        {
            return gRepostory.GetByID(g=>g.Id == id);   
        }

        public void Update(Guest entity)
        {
            gRepostory.Update(entity);
        }
    }
}
