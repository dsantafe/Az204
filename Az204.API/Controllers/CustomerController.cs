using AutoMapper;
using Az204.DAL.Models;
using Az204.Domain.DTOs;
using Az204.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Az204.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerRepository customerRepository;
        readonly IMapper mapper;
        public CustomerController(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Metodo para obtener todos los clientes
        /// </summary>
        /// <remarks>
        /// Detalle del metodo para obtener todos los clientes
        /// </remarks>
        /// <returns>Resultado de la operacion</returns>
        [HttpGet("GetAllAsync")]
        public IActionResult GetAllAsync()
        {
            var customers = customerRepository.GetAllAsync().Result;
            var customersDTO = customers.Select(x => mapper.Map<CustomerDTO>(x));
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = customersDTO });
        }

        [HttpGet("GetByIdAsync/{id}")]
        public IActionResult GetByIdAsync(int id)
        {
            var customer = customerRepository.GetByIdAsync(id).Result;
            var customerDTO = mapper.Map<CustomerDTO>(customer);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = customerDTO });
        }

        /// <summary>
        /// Metodo para crear un cliente
        /// </summary>
        /// <param name="customerDTO">Objeto del cliente</param>
        /// <returns>Resultado de la operacion</returns>
        [HttpPost("InsertAsync")]
        public IActionResult InsertAsync(CustomerDTO customerDTO)
        {
            try
            {
                var customer = mapper.Map<Customer>(customerDTO);
                customer = customerRepository.InsertAsync(customer).Result;
                customerDTO.Id = customer.Id;

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = customerDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        [HttpPut("UpdateAsync/{id}")]
        public IActionResult UpdateAsync(CustomerDTO customerDTO, int id)
        {
            try
            {
                var customer = customerRepository.GetByIdAsync(id).Result;
                if(customer == null)
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

                customer = mapper.Map<Customer>(customerDTO);//objeto
                //customer.FirstMidName = customerDTO.FirstMidName;//propiedad

                customer = customerRepository.UpdateAsync(customer).Result;

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = customerDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var customer = customerRepository.GetByIdAsync(id).Result;
                if (customer == null)
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

                await customerRepository.DeleteAsync(id);

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NoContent });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }
}
