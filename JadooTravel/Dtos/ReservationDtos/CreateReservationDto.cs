﻿namespace JadooTravel.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
    }
}
