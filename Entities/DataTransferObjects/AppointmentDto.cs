using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AppointmentDto
    {
        public string? AppointmentTitle { get; set; }
        public string? AppointmentContent { get; set; }
        public DateTime AppointmentDate { get; set; }

    }

}
