using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;


namespace CloudResumeChallengeBackend.Models
{
    public class Visitor
    {
        [BindNever]
        public int Id { get; set; } = 0;

        public System.DateTime DateTime { get; set; }
        
        [BindNever]
        public IPAddress IPAddress { get; set; }

        public string UserAgent { get; set; }

        public short Width { get; set; }

        public short Height { get; set; }

    }
}
