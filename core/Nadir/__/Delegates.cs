using Nadir.Core;
using System;

namespace Nadir
{
    public delegate void Create<T, U>(Action<T> aggregate)
        where T : Aggregate
        where U : Affair;



    public delegate void Apply<T>(T affair)
        where T : Affair;
}
