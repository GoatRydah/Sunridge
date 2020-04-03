﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models.ViewModels
{
    public class KeyHistoryViewModel
    {
        public int KeyHistoryViewModelId { get; set; }
        public KeyHistory KeyHistory { get; set; }
        public IEnumerable<SelectListItem> Key { get; set; }
        public IEnumerable<SelectListItem> Lot { get; set; }
    }
}
