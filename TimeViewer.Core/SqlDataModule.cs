using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
// MEF References
using System.ComponentModel.Composition;
//Core Reference
using TimeViewer.Core.Interfaces;

namespace TimeViewer.Core
{
    public class SqlDataModule: IDataModule, IDisposable
    {
        //Singleton Connection. Must be only one
        private static IDbConnection _sharedConnection;
        //Singleton Transaction. Must be only one
        private static IDbTransaction _sharedTransaction;

        //Create the connection that will be shared across the modules
        public void CreateSharedConnection(string connectionString_)
        {
            //If the connection instance is not created, create the instance
            if (_sharedConnection == null)
            {
                _sharedConnection = new System.Data.SqlClient.SqlConnection(connectionString_);
            }
            else
            {
                throw new Exception("The connection is already created!");
            }
        }

        //Open the shared connection
        public void OpenSharedConnection()
        {
            if (_sharedConnection.State == ConnectionState.Closed)
                _sharedConnection.Open();
        }

        //Close the shared connection
        public void CloseSharedConnection()
        {
            if (_sharedConnection.State == ConnectionState.Open)
                _sharedConnection.Close();
        }

        //Begin a transaction on shared connection
        public void BeginTransaction()
        {
            if (_sharedTransaction == null)
                _sharedTransaction = _sharedConnection.BeginTransaction();
        }

        //Commit a transaction on shared connection
        public void CommitTransaction()
        {
            if (_sharedTransaction != null)
                _sharedTransaction.Commit();

            _sharedTransaction = null;
        }

        //Rollback a transaction on shared connection
        public void RollbackTransaction()
        {
            if (_sharedTransaction != null)
                _sharedTransaction.Rollback();

            _sharedTransaction = null;
        }

        //Retun the shared connection
        public IDbConnection GetSharedConnection()
        {
            if (_sharedConnection != null)
                return _sharedConnection;
            else
                throw new Exception("The connection is not created!");
        }

        //Retun the shared transaction
        public IDbTransaction GetSharedTransaction()
        {
            if (_sharedTransaction != null)
                return _sharedTransaction;
            else
                throw new Exception("The transaction is not created!");
        }

        public void Dispose()
        {
            if (_sharedTransaction != null)
            {
                _sharedTransaction.Dispose();
                _sharedTransaction = null;
            }
            if (_sharedConnection != null)
            {
                _sharedConnection.Dispose();
                _sharedConnection = null;
            }

        }
    }
}
