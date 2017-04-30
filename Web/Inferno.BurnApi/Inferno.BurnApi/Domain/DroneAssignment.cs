using System;
using System.Collections.Generic;
using Inferno.BurnApi.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inferno.BurnApi.Domain
{
    public class DroneAssignment
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DroneDispatchedAt { get; set; }
        public DateTime? FinishedAt { get; set; }

        public EUrgency Urgency { get; set; }

        public Drone Drone { get; set; }
        public FireReport FireReport { get; set; }
    }
}
