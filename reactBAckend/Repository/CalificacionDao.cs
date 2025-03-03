using reactBAckend.Context;
using reactBAckend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBAckend.Repository
{
    public class CalificacionDao
    {
        private RegisterAlumnoContext _contexto = new RegisterAlumnoContext();

        #region Seleccionar_lista_calificaciones
        public List<Calificacion> seleccion(int matriculaid)
        {

            var matricula = _contexto.Matriculas.Where(x => x.Id == matriculaid);
            Console.WriteLine("matricula encontrada");
            try
            {
                if (matricula != null)
                {

                    var calificacion = _contexto.Calificacions.Where(x => x.Id == matriculaid).ToList();
                    return calificacion;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }


        }
        #endregion

        #region insertarDatos
        public bool Insertar(Calificacion calificacion) {
            try
            {
                if (calificacion == null)
                {
                    return false;
                }
                var addCalificacion = _contexto.Calificacions.Add(calificacion);
                _contexto.SaveChanges();
                return true;

            }
            catch (Exception ex) {
                return false;

            }

        }
        #endregion

        #region borrar
        public bool eliminarCalificacion(int id)
        {
            var calificacion = _contexto.Calificacions.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                if (calificacion != null)
                {

                    _contexto.Calificacions.Remove(calificacion);
                    _contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        #endregion
    }
}
