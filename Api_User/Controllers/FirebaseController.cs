﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirebaseController : ControllerBase
    {
        [HttpPost("/api/Firebase", Name = "Firebase")]
        public void Firebase()
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAE3Ut1pc:APA91bH8cPa0kCh8HF5fjHj8ufMefhQCkXzoF5VYPwPMsbIhXEOAcp17FMczEt5kQY3fARkT8buaKW3bVqnl4frGsrIYLK_RGWTqU8zB4HsySYv8n_SivJ7KEpaZ-keDP0XNPNGKg9JV"));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", "83570316951"));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = "f76rEtTa_vk:APA91bGd3xRqWcZP5PhhKimxO2odR2J--vBJuiAlx2b7sMvu3t65brLzhSJt6_QP6uVSJfAlp_OAPMOPv2lVop1klQWsBNZxlkWW93wbzbfVzAhz2Mw87EPSZ6Vhp55alVr_F3i6iwzy",
                priority = "high",
                content_available = true,
                notification = new
                {
                    body = "Test",
                    title = "Test",
                    badge = 1
                },
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }
        }
    }
}