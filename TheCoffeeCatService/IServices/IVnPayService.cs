using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatDAO.DAOs;
using Microsoft.AspNetCore.Http;
namespace TheCoffeeCatService.IServices
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
        PaymentInformationModel GetPaymentModelFromCache(Guid userId);
    }
}
