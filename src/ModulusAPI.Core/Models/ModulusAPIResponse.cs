using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CluedIn.Crawling.ModulusAPI.Core.Models
{
    public class ModulusAPIResponse
    {
        public ModulusAPIResponse()
        {
        }
        public Data Data { get; set; }
        public CommonResponse CommonResponse { get; set; }
    }

    public class Data
    {
        public string Individ_id { get; set; }
        public string Cpr_no { get; set; }
        public string Surname { get; set; }
        public string First_name { get; set; }
        public string Username { get; set; }
        public string Membership_no { get; set; }
        public string Has_akasse_membership { get; set; }
        public string Has_forbund_memberhip { get; set; }
    }

    public class CommonResponse
    {
        public List<ResponseMessages> Messages { get; set; }
    }

    public class ResponseMessages
    {
        public string MessageType { get; set; }
        public string Message { get; set; }
    }
}
