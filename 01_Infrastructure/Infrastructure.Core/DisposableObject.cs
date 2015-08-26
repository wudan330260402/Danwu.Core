using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public abstract class DisposableObject : IDisposable
    {

        #region Finalization Constructs

        ~DisposableObject() {
            this.Dispose(false);
        }

        #endregion

        #region Protected Methods

        protected abstract void Dispose(bool disposing);

        protected void ExplicitDispose() {
            this.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.ExplicitDispose();
        }

        #endregion

    }
}
