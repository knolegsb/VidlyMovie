﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyMovie.Dtos;
using VidlyMovie.Models;
using System.Data.Entity;

namespace VidlyMovie.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        //public IEnumerable<CustomerDto> GetCustomers()
        public IHttpActionResult GetCustomers()
        {
            //return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            var customerDtos = _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        // GET /api/customers/1
        //public CustomerDto GetCustomer(int id)
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        //public void UpdateCustomer(int id, CustomerDto customerDto)
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            Mapper.Map(customerDto, customerInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        //public void DeleteCustomer(int id)
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
