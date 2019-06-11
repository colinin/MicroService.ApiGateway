using System;
using System.Collections.Generic;

namespace MicroService.ApiGateway.Ocelot.Dto
{
    [Serializable]
    public class SecurityOptionsDto
    {
        public List<string> IPAllowedList { get; set; }

        public List<string> IPBlockedList { get; set; }
        public SecurityOptionsDto()
        {
            IPAllowedList = new List<string>();
            IPBlockedList = new List<string>();
        }
    }
}