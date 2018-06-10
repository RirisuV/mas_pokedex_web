using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Badge
    {

        public Badge()
        {
            this.Trainers = new HashSet<Trainer>();
        }

        public int badgeID { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        // many to many
        public virtual ICollection<Trainer> Trainers { get; set; }

    }
}