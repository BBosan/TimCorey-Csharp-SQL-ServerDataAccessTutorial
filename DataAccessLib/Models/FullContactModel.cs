﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.Models
{
    public class FullContactModel
    {
        public BasicContactModel BasicInfo { get; set; }
        public List<EmailAddressModel> EmailAddresses { get; set; }
        public List<PhoneNumberModel> PhoneNumbers { get; set; }
    }
}