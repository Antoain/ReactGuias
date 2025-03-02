using reactBAckend.Context;
using reactBAckend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBAckend.Repository
{
    public class ProfesorDao
    {
        #region context
        public RegisterAlumnoContext context = new RegisterAlumnoContext();
        #endregion
        #region GetByID
        public Profesor login(string usuario, string pass) 
        {
            var prof = context.Profesors.Where(
                p => p.Usuario == usuario  && p.Pass==pass).FirstOrDefault();

            return prof;
        
        }
        #endregion
    }
}
