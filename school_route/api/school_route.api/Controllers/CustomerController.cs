using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using school_route.api.Dto;
using school_route.infrastructure.Log;
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
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CustomerController(ICustomerServices customerServices, IMapper mapper, ILoggerManager loggerManager) 
        {
            this._customerServices = customerServices;
            this._mapper = mapper;
            this._logger = loggerManager;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customersModel = await this._customerServices.GetAllAsync();
                var customerDto = this._mapper.Map<IEnumerable<CustomerDto>>(customersModel);
                return Ok(customerDto);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customersModel = await this._customerServices.GetByIdAsync(id);
                var customerDto = this._mapper.Map<CustomerDto>(customersModel);
                return customerDto != null ? Ok(customerDto) : Problem("Failed to locate customer");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(CustomerDto createDto)
        {
            try
            {
                var customersModel = this._mapper.Map<CustomerModel>(createDto);
                var count = await this._customerServices.AddAsync(customersModel);
                return count > 0 ? Ok("Customer created successfully") : Problem("Unable to create customer");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(CustomerDto createDto)
        {
            try
            {
                var customersModel = this._mapper.Map<CustomerModel>(createDto);
                var count = await this._customerServices.UpdateAsync(customersModel);
                return count > 0 ? Ok("Customer updated successfully") : Problem("Customer failed to update");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var count = await this._customerServices.DeleteAsync(id);
                return count > 0 ? Ok("Customer deleted successfully") : Problem("Customer failed to deletee");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
    }
}
