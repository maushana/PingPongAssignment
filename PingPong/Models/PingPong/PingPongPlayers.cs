﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PingPong.Models.PingPong
{
    public class PingPongPlayers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "DateCreated")]
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Dt { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public int SkillLevelId { get; set; }
        public PingPongSkillLevel SkillLevel { get; set; }

    }
}