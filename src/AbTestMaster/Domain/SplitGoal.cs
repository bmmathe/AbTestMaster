﻿using System;

namespace AbTestMaster.Domain
{
    [Serializable]
    internal class SplitGoal
    {
        public string Goal { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
    }
}
