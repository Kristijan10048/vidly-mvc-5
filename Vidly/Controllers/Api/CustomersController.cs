using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        #region Private Members
        /// <summary>
        /// 
        /// </summary>
        private ApplicationDbContext m_context;
        #endregion

        #region Constructors
        /// <summary>
        /// Costructor
        /// </summary>
        public CustomersController()
        {
            m_context = new ApplicationDbContext();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = m_context.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = m_context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var tmpMap = Mapper.Map<Customer, CustomerDto>(customer);

            return Ok(tmpMap);
        }

        /// <summary>
        /// Creates a customer
        /// </summary>
        /// <param name="customerDto">Customer data</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            //TODO Check
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            m_context.Customers.Add(customer);
            m_context.SaveChanges();

            //TODO Check?
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        /// <summary>
        /// Updates a custumer basesd on id
        /// </summary>
        /// <param name="id">Customer's id</param>
        /// <param name="customerDto">Customer's data</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            //TODO What is model state?
            if (!ModelState.IsValid)
                return BadRequest();

            //get exsisting customer in db
            var customerInDb = m_context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            //update it
            Mapper.Map(customerDto, customerInDb);

            //update it in db
            m_context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Delletes a custumer
        /// </summary>
        /// <param name="id">Customer's id</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            // search for customer in db based on id
            var customerInDb = m_context.Customers.SingleOrDefault(c => c.Id == id);

            //check for null
            if (customerInDb == null)
                return NotFound();

            //delete customer
            m_context.Customers.Remove(customerInDb);

            //save it
            m_context.SaveChanges();

            return Ok();
        }
        #endregion
    }
}
