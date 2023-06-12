using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticManagerWorkspace.Models
{
    public class ClientServiceViewModel
    {
        public SelectList Categories { get; set; }

        public SelectList Clients { get; set; }

        public SelectList Statuses { get; set; }

        public Service Service { get; set; }
    }
}