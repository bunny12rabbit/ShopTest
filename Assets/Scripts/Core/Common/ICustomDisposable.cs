using System;

namespace Core.Common
{
    public interface ICustomDisposable : IDisposable
    {
        Action OnDispose { get; set; }
    }
}