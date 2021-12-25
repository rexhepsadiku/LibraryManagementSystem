using AutoMapper;
using LibraryManagementSystem.Application.Dtos.Customers;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(CreateCustomerDto customer)
        {
            var customerCreate = _mapper.Map<Customer>(customer);
            _repository.Create(customerCreate);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<IEnumerable<GetCustomerDto>> GetAll(string search)
        {
            var customers = await _repository.GetAll(search);
            return _mapper.Map<IEnumerable<GetCustomerDto>>(customers);
        }

        public async Task<GetCustomerDto> GetById(int id)
        {
            var customer = await _repository.GetById(id);
            return _mapper.Map<GetCustomerDto>(customer);
        }

        public void Update(UpdateCustomerDto customer)
        {
            var updatedCustomer = _mapper.Map<Customer>(customer);
            _repository.Update(updatedCustomer);
        }

        public int RandomLibraryId()
        {
            Random rnd = new Random();
            return rnd.Next(10000000, 99999999);
        }

        public void SendEmail(string emailTo, string sms)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("e.libraryms4@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = "Library";
            email.Body = new TextPart(TextFormat.Plain) { Text = sms };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("e.libraryms4@gmail.com", "library12345");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public async Task<IEnumerable<GetCustomerDto>> GetCustomersByUser(string userId, string search)
        {
            var customers = await _repository.GetAll(search);
            var customersByUser = customers.Where(x => x.UserId == userId);
            return _mapper.Map<IEnumerable<GetCustomerDto>>(customersByUser);
        }
    }
}
