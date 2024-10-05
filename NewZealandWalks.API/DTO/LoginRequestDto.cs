﻿using System.ComponentModel.DataAnnotations;

namespace NewZealandWalks.API.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
