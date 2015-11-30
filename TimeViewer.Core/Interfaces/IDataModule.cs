using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TimeViewer.Core.Interfaces
{
    public interface IDataModule
    {
        void CreateSharedConnection(string connectionString_);
        IDbConnection GetSharedConnection();
        void OpenSharedConnection();
        void CloseSharedConnection();

        IDbTransaction GetSharedTransaction();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

    }
}
