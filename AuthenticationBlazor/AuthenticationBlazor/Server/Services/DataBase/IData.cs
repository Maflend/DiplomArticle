using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBlazor.Server.Services.DataBase
{
    public interface IData
    {
        List<User> Users { get; set; }
        List<Product> Products { get; set; }
    }
}
