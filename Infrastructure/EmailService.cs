using Domain.Dtos;
using Infrastructure.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Persistence.SqlDataBase;

namespace Infrastructure
{
    public class EmailService : IEmailService
    {
        private readonly CoffeeBackEndDbContext _dbContext;
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config, CoffeeBackEndDbContext dbContext)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public async Task SendEmail(OrderDto order)
        {
            var email = new MimeMessage();

            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c=>c.Id.Equals(order.CustomerId));

            var credentials = MakeEmailBasedOnProvider(customer.Email);

            email.From.Add(MailboxAddress.Parse(credentials[1]));
            email.To.Add(MailboxAddress.Parse(customer.Email));
            email.Subject = "Progress so far!";

            email.Body = await RecentTrainingDescriptor(order);

            using var smtp = new SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await smtp.ConnectAsync(credentials[0], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(credentials[1], credentials[2]);
            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }

        private List<string> MakeEmailBasedOnProvider(string emailBody)
        {
            var credentials = new List<string>();
            var emailIdentifier = string.Empty;

            if (emailBody.Contains("outlook"))
                emailIdentifier += "outlook";

            if (emailBody.Contains("gmail"))
                emailIdentifier += "gmail";
            switch (emailIdentifier)
            {
                case "gmail":
                    credentials.Add(_config.GetSection("EmailHostGmail").Value);
                    credentials.Add(_config.GetSection("EmailUserNameGmail").Value);
                    credentials.Add(_config.GetSection("EmailPasswordGmail").Value);
                    break;
                case "outlook":
                    credentials.Add(_config.GetSection("EmailHostOutlook").Value);
                    credentials.Add(_config.GetSection("EmailUserNameOutlook").Value);
                    credentials.Add(_config.GetSection("EmailPasswordOutlook").Value);
                    break;
            }

            return credentials;
        }

        private async Task<MimeEntity> RecentTrainingDescriptor(OrderDto order)
        {
            var finalMessage = new BodyBuilder();
            var orderItems = order.OrderItems;
            var menuItems =  await _dbContext.MenuItems.Include(m=>m.CoffeeShop).ToListAsync();
            if (orderItems.Any())
            {
                finalMessage.HtmlBody += $"<h1>Thanks for ordering your coffee.</h1>";
                finalMessage.HtmlBody += $"<h2>Submitted on: {order.OrderDate}</h2>";
                finalMessage.HtmlBody += $"<h2>Order price: {order.TotalPrice}$</h2>";
                finalMessage.HtmlBody += $"<h3>Will be shipped to: {order.ShipCountry}, {order.ShipCounty}, {order.ShipCity},{order.ShipAddress}</h3>";
                foreach (var orderItem in orderItems)
                {
                    var menuItem = menuItems.FirstOrDefault(m => m.Id.Equals(orderItem.MenuItemId));
                    finalMessage.HtmlBody += $"<p><strong>{menuItem.Name} made by: {menuItem.CoffeeShop.Name}</strong></p>" +
                                             "<ul>" +
                                             $"<li>Quantity: {orderItem.Quantity} </li>" +
                                             $"<li>Size: {orderItem.Size} </li>" +
                                             $"<li>Price: {orderItem.Price}$ </li>" +
                                             $"</ul>";
                }
            }

            return finalMessage.ToMessageBody();
        }
    }
}
