﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Banking : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvc { get; set; }
        public decimal Money { get; set; }
        public short CustomerFindex { get; set; }
    }
}
