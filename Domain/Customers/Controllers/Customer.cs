using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using programming_work_backend.Domain.Customers.Models;
using programming_work_backend.Domain.Users.Models;

namespace programming_work_backend.Domain.Jwt
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public dynamic ListCustomer()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Mail = "caro@gmail.com",
                    Age = 23,
                    Name = "Carolina Gonzalez"
                },
                new Customer
                {
                    Id = 2,
                    Mail = "juan@gmail.com",
                    Age = 25,
                    Name = "Juan Gonzalez"
                }
            };
            return customers;
        }

        [HttpGet]
        [Route("listxid")]
        public dynamic ListCustomerById(int code)
        {
            // Aquí deberías buscar en la base de datos por el Id de cliente.

            return new Customer
            {
                Id = code,
                Mail = "caro@gmail.com",
                Age = 23,
                Name = "Carolina Gonzalez"
            };
        }

        [HttpPost]
        [Route("save")]
        public dynamic SaveClient(Customer customer)
        {
            // Guarda en la base de datos y asigna un Id al cliente.
            customer.Id = 3;

            return new
            {
                success = true,
                message = "Registered customer",
                result = customer
            };
        }

        [HttpPost]
        [Route("delete")]
        public dynamic DeleteClient(Customer customer)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return rToken;

            User usuario = rToken.result as User;

            if (usuario.rol != "administrador")
            {
                return new
                {
                    success = false,
                    message = "No tienes permisos para eliminar clientes",
                    result = ""
                };
            }
            
            return new
            {
                success = true,
                message = "Cliente eliminado",
                result = customer
            };
        }
    }
}
