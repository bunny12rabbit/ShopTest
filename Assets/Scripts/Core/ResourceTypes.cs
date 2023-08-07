using System;

namespace Core
{
    [Flags]
    public enum ResourceTypes
    {
        Gold = 1 << 1,
        Health = 1 << 2,
        Rating = 1 <<3
    }
}