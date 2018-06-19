using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemonWebProject.Models.ViewModel
{
    public class CreateByTrainerViewModel
    {
        [Required]
        public int ChallengeID { get; set; }

        [Required]
        public DateTime ChallengeDate { get; set; }

        public int LeaderID { get; set; }

    }
}