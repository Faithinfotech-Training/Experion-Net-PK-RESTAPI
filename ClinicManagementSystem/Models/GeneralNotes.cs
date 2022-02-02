using System;
using System.Collections.Generic;

namespace ClinicManagementSystem.Models
{
    public partial class GeneralNotes
    {
        public int GeneralNoteId { get; set; }
        public int? AppointmentId { get; set; }
        public string Notes { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
