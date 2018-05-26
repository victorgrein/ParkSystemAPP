using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class BaseValidator<T>
    {
        private StringBuilder erros =
            new StringBuilder();

        public void AddError(string error)
        {
            this.erros.AppendLine(error);
        }

        private void CheckErrors()
        {
            if(this.erros.Length != 0)
            {
                throw new Exception(erros.ToString());
            }
        }

        public virtual void Validate(T entity)
        {
            CheckErrors();
        }


    }
}
