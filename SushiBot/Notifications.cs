using System;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace SushiBot
{
    class Notifications : IDisposable 
    {
        MailAddress from = new MailAddress("sushibotitacademy@gmail.com", "SushiBotItAcademy");
        MailAddress to;
        MailMessage message;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        Client client;
        Order order;
        private bool disposed;

        public Notifications(Client client, Order order)
        {
            this.client = client;
            this.order = order;
            to = new MailAddress(client.Email);
            message = new MailMessage(from, to);
        }

        public void OrderReady2Delivery()
        {
            UI.Wait();
            Console.WriteLine($"Order №{order.ID} is ready.");
            message.Subject = $"Order №{order.ID}";
            message.Body = $"<p>Dear, {client.Name} {client.Surname}, your <b>Order</b> №{order.ID} is ready<br>" +
                     $"<b>Order info:</b><br>" +
                     $"{UI.ConvertCart2String(order.Cart)}<br><br>" +
                     $"<b>Delivery address: </b>{client.Address}</p>";
            message.IsBodyHtml = true;
            smtp.Credentials = new NetworkCredential(Constants.EmailLogin, Constants.EmailPassword);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

        public void OrderDelivered()
        {
            UI.Wait();
            Console.WriteLine($"Order №{order.ID} has been delivered.");
            message.Subject = $"Order №{order.ID}";
            message.Body = $"<p>Dear, {client.Name} {client.Surname}, your <b>Order</b> №{order.ID} has been delivered " +
                           $"to the address: {client.Address}.</p>";
            message.IsBodyHtml = true;
            smtp.Credentials = new NetworkCredential(Constants.EmailLogin, Constants.EmailPassword);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
        
        public void OrderPaid()
        {
            UI.Wait();
            Console.WriteLine($"Order №{order.ID} has been paid.");
            message.Subject = $"Order №{order.ID}";
            message.Body = $"<p>Dear, {client.Name} {client.Surname}, your <b>Order</b> №{order.ID} has been paid.<br><br>" +
                           $"Thank you!</p>";
            message.IsBodyHtml = true;
            smtp.Credentials = new NetworkCredential(Constants.EmailLogin, Constants.EmailPassword);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    from = null;
                    to = null;
                    message = null;
                    smtp = null;
                    client = null;
                    order = null;
                }
                disposed = true;
            }
        }

        ~Notifications()
        {
            Dispose(false);
        }
    }
}
