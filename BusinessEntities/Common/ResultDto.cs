﻿using System.Collections.Generic;

namespace BusinessEntities.Common
{
    public class ResultDto<T>
    {
        public bool ISuccess { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
