﻿using System;
using System.Collections.Generic;

namespace Travelers.entities
{
	public class Notification : Entity
    {
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public Guid PostId { get; set; }
        public Guid IdUser { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }


    }
}
