using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contrants
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IAppoinmentService AppoinmentService { get; }
    }


}
