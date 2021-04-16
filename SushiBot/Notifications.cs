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
            // кому отправляем
            MailAddress to = new MailAddress(client.Email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = $"Order №{order.ID}";
            // текст письма
            m.Body = $"<p>Dear, {client.Name}, your <b>Order</b> №{order.ID} is ready<br>" +
                     $"<b>Order info:</b><br>" +
                     $"{UI.ConvertCart2String(order.Cart)}</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("sushibotitacademy@gmail.com", "123456789hj`");
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(m);
        }
    }
}
