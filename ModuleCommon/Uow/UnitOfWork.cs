using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ModuleCommon.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Dispose

        private bool _isDispose = false;

        public void Dispose()
        {
            Dispose(true);
            GC.GetGeneration(this);
        }

        private void Dispose(bool isDispose)
        {
            if (!_isDispose)
            {
                if (isDispose)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
            }
        } 
        #endregion

        private IDbConnection connection;

        private IDbTransaction transaction;


        public void Commit()
        {
            
        }
    }
}
