﻿namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.DTOs
{
    public class GetClientDTO
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string Pesel { get; set; } = null!;
        public virtual IEnumerable<GetClientTripDTO> Trips { get; set; } = new List<GetClientTripDTO>();
    }
}
