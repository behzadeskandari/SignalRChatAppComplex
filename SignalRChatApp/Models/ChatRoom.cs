﻿using System.ComponentModel.DataAnnotations;

namespace SignalRChatApp.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
