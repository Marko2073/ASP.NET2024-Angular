﻿using AspProjekat2024.Domain;

namespace AspProjekat2024.API.DTO
{
    public class AuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
    }
}
