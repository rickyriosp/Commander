﻿using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs
{
    public class CommandUpsertDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Line { get; set; }

        [Required]
        [MaxLength(50)]
        public string Platform { get; set; }
    }
}
