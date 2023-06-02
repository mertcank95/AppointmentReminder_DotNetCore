using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contrants;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authencationService;
        private readonly IAppoinmentService _appoinmentService;
        public ServiceManager(IAuthenticationService authencationService,
            IAppoinmentService appoinmentService)
        {
            _authencationService = authencationService;
            _appoinmentService = appoinmentService;
        }
        public IAuthenticationService AuthenticationService => _authencationService;
        public IAppoinmentService AppoinmentService => _appoinmentService;
    }
}
