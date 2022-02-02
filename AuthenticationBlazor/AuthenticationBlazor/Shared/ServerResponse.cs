using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBlazor.Shared
{
    public class ServerResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = false;
    }
}
