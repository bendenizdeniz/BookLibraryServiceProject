﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Modals.APIRequestModals
{
    public class InsertOwnerToBookRequestModal
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
    }
}
