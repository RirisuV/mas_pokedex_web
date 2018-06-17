using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.pokemonModels
{
    public class Challenge
    {

        [Key]
        public int ChallengeID { get; set; }

        public DateTime ChallengeDate { get; set; }

        public string Description { get; set; }

        public string Result { get; set; }

        public bool AsAccepted { get; set; }

        public string DeclineReasonTopic { get; set; }

        public string DeclineReasonDescription { get; set; }

        // many to one
        public Leader CurrentLeader { get; set; }
        public int CurrentLeaderID { get; set; }

        public Trainer CurrentTrainer { get; set; }
        public int CurrentTrainerID { get; set; }

    }
}