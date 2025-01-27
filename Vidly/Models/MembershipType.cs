﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public byte SignupFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte  DiscountRate { get; set; }

        public string Name { get; set; }

        public static readonly byte Unknown = 0;

        public static readonly byte Monthly = 1;
    }
}