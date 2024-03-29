﻿using Microsoft.AspNetCore.Identity;

namespace Homework4.Models
{
    public class Friendship
    {
        public int FriendShipId { get; set; }
        public IdentityUser FromUserId { get; set; }
        public IdentityUser ToUserId { get; set; }
        public DateTime OfferTime { get; set; }
    }
}
