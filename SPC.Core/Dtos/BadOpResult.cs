using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.Dtos
{
    public class BadOpResult:OpResult
    {
        public BadOpResult(string message) : base(OpResultStatus.Error, message) { }

        public BadOpResult(OpResultStatus status) : base(status) { }
    }
    public class BadOpResult<TData> : OpResult<TData>
    {
        public BadOpResult(string message) : base(OpResultStatus.Error, message) { }

        public BadOpResult(OpResultStatus status) : base(status) { }
    }
}
