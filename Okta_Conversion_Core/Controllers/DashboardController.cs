using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using MailKit.Net.Smtp;
using MimeKit;

using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Okta_Conversion_Core.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        //send email
        [HttpPost]
        public ActionResult SendEmail()
        {
            SmtpClient smtpClient = new SmtpClient();

            MimeMessage message = new MimeMessage();

            MailboxAddress to = new MailboxAddress("Nik Fisher", "nik@fishbowlllc.com");
            MailboxAddress from = new MailboxAddress("Nik Fisher", "nik@fishbowlllc.com");

            message.To.Add(to);
            message.From.Add(from);

            message.Subject = "Hello From the Conversion App";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<p>this is my test email</p>";
            bodyBuilder.TextBody = "this is my test email";

            smtpClient.Connect("address", 123, true);
            smtpClient.Authenticate("username", "password");

            smtpClient.Send(message);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();

            return new JsonResult(true);
        }

        public ActionResult GetUsers()
        {
            WebRequest request = WebRequest.Create("https://jsonplaceholder.typicode.com/users");
            request.Method = "GET";

            WebResponse response = request.GetResponse();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var text = reader.ReadToEnd();
                var userList = JsonConvert.DeserializeObject<List<Models.UserModel>>(text);
                return new JsonResult(userList);
            }

            throw new Exception("There was a problem fetching the users");
        }
    }
}
