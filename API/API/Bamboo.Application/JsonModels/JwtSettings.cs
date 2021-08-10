using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Application.JsonModels
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string DurationType { get; set; }
        public double DurationInMinutes { get; set; }
        public double DurationInDays { get; set; }
    }
}
