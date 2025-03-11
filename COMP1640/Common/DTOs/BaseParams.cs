using Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class BaseParams
    {
        [JsonIgnore]
        public int CurrentUserId { get; set; }
        [JsonIgnore]
        public Role CurrentUserRole { get; set; }
    }
}
