using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MSALDaemon
{
    [Route("[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        AppConfig config { get; set; }
        public MailController(IOptions<AppConfig> cfg)
        {
            config = (AppConfig)cfg.Value;
        }

        // https://localhost:5001/mail
        // test with send-mail.http
        [HttpPost]
        public ActionResult SendMail([FromBody]MailModel mail)
        {
            GraphHelper.SendMail(mail.subject, mail.text, new[] { mail.recipient }, config.GraphCfg);
            return Ok();
        }
    }
}