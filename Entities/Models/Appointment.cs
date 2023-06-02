using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public string? AppointmentTitle { get; set; }
        public string? AppointmentContent { get; set; }
        public DateTime AppointmentCreated { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }



}
