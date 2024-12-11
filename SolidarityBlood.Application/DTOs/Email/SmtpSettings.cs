using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.DTOs.Email
{
    public class SmtpSettings
    {

        public string? Host{ get; set; }
        public int Porta { get; set; }
        public string? Name{ get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool UseSSL { get; set; }

    }
}
