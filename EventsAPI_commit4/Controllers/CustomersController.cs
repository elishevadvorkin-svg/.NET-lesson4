using EventsAPI.Models;
using EventsAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll(bool? isActive = null)
        {
            var customers = DataStore.Customers.AsEnumerable();
            
            if (isActive.HasValue)
            {
                customers = customers.Where(c => c.IsActive == isActive.Value);
            }
            
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = DataStore.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Create([FromBody] Customer customer)
        {
            customer.Id = DataStore.Customers.Max(c => c.Id) + 1;
            DataStore.Customers.Add(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public ActionResult<Customer> Update(int id, [FromBody] Customer customer)
        {
            var existing = DataStore.Customers.FirstOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();

            existing.Name = customer.Name;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;
            existing.IsActive = customer.IsActive;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customer = DataStore.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return NotFound();

            DataStore.Customers.Remove(customer);
            return NoContent();
        }
    }
}
