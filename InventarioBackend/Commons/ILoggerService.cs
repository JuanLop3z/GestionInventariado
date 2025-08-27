using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface ILoggerService
    {
        public void RegistrarError<T>(T response) where T : class;
    }
}
