﻿using System.ComponentModel.DataAnnotations;

namespace Victuz.Models
{
    public class Proposition
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public string MemberName { get; set; }
        public string Status { get; set; }

        public void ChangeStatus()
        {

        }
    }
}
