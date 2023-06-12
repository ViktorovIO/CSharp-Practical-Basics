using System;
using System.ComponentModel.DataAnnotations;
namespace LogisticManagerWorkspace.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Status()
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }
    }
}
