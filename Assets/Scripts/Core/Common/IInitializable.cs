using System;

namespace Core.Common
{
    public interface IInitializable<in TInputParams> : ICustomDisposable
    {
        IDisposable Init(TInputParams inputParams);
    }
}