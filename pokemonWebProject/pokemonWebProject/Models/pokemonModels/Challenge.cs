using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Challenge
    {

        public int challengeID { get; set; }

        public DateTime challengeDate { get; set; }

        public string description { get; set; }

        public string result { get; set; }

        public bool isAccepted { get; set; }

        public string declineReasonTopic { get; set; }

        public string declineReasonDescription { get; set; }

        // many to one
        public Leader CurrentLeader { get; set; }
        public int CurrentLeaderID { get; set; }

        public Trainer CurrentTrainer { get; set; }
        public int CurrentTrainerID { get; set; }

    }
}