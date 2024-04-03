using Microsoft.AspNetCore.Mvc;
using school_route.models;
using school_route.repository.interfaces;
using school_route.services.interfaces;

namespace school_route.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        public readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices) 
        {
            this._customerServices = customerServices;
        }

        [HttpGet(Name = "GetAll")]
        public Task<IReadOnlyList<Customer>> Get()
        {
            var customers = this._customerServices.GetAllAsync();
            return customers;
        }
    }
}
