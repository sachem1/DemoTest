using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleCommon.Uow
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}
