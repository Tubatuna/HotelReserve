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
    public class PaymentService : IManager<Payment>
    {
        private readonly PaymentRepostory _pRepostory;
        public PaymentService(PaymentRepostory paymentRepostory)
        {
            _pRepostory = paymentRepostory;
        }
        public void Add(Payment entity)
        {
            PaymentValidator pVal = new PaymentValidator();
            ValidationResult result = pVal.Validate(entity);
            if (!result.IsValid)
            {
                throw new Exception(string.Join(",", result.Errors));
            }
            _pRepostory.Add(entity);
        }

        public void Delete(Payment entity)
        {
           _pRepostory.Delete(entity);
        }

        public List<Payment> GetAll()
        {
            return _pRepostory.GetAll();
        }

        public Payment GetByID(Guid id)
        {
           return _pRepostory.GetByID(p=>p.Id == id);
        }

        public void Update(Payment entity)
        {
            _pRepostory.Update(entity);
        }
    }
}
