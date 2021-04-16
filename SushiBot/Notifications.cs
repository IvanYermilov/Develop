using System;
using System.Net;
using System.Net.Mail;

namespace SushiBot
{
    class Notifications
    {
        public static void OrderReady2Delivery(Client client, Order order)
        {
            MailAddress from = new MailAddress("sushibotitacademy@gmail.com", "SushiBotItAcademy");
            MailAddress to = new MailAddress(client.Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = $"Order №{order.ID}";
            m.Body = $"<p>Dear, {client.Name}, your <b>Order</b> №{order.ID} is ready<br>" +
                     $"<b>Order info:</b><br>" +
                     $"{UI.ConvertCart2String(order.Cart)}</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("sushibotitacademy@gmail.com", "123456789hj`");
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(m);
        }
    }
}
