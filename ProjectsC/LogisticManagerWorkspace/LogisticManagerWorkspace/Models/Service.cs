using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LogisticManagerWorkspace.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }

        public string ClientName { get; set; }

        public string Cost { get; set; }

        public string Status { get; set; }

        public Service()
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Date = Date;
            this.ClientName = ClientName;
            this.Cost = Cost;
            this.Status = Status;
        }
    }
}
