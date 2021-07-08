using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.Dtos
{
    public class BadOpPageResult:OpPageResult
    {
        public BadOpPageResult(string message) : base(OpResultStatus.Error, message) { }

        public BadOpPageResult(OpResultStatus status) : base(status) { }
    }
    public class BadOpPageResult<TData> : OpPageResult<TData>
    {
        public BadOpPageResult(string message) : base(OpResultStatus.Error, message) { }

        public BadOpPageResult(OpResultStatus status) : base(status) { }
    }
}
