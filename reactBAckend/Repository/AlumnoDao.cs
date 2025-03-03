using reactBAckend.Context;
using reactBAckend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace reactBAckend.Repository
{
    public class AlumnoDao
    {
        #region Contex

        public RegisterAlumnoContext contexto = new RegisterAlumnoContext();
        #endregion

        #region Select All
        public List<Alumno> SelectAll()
        {
            // -> creamos una variable  var que es generica 
            // -> el contexto tiene referecniada todos los modelos. 
            // -> dentro den EF tenemos  el metodo modelo.ToList<Modelo>
            var alumno = contexto.Alumnos.ToList<Alumno>();
            return alumno;
        }
        #endregion

        #region SelectByID
        public Alumno? GetById(int id)
        {
            var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }
        #endregion

        #region Insertar
        public bool InsertarAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno
                {
                    Nombre = alumno.Nombre,
                    Direccion = alumno.Direccion,
                    Edad = alumno.Edad,
                    Email = alumno.Email,
                    Dni = alumno.Dni
                };

                contexto.Alumnos.Add(alum);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region update Alumno
        public bool Update(int id, Alumno actualizar)
        {
            try
            {
                var alumnoUpdate = GetById(id);

                if (alumnoUpdate == null)
                {
                    Console.WriteLine("Alumno es Null");
                    return false;
                }


                alumnoUpdate.Direccion = actualizar.Direccion;
                alumnoUpdate.Dni = actualizar.Dni;
                alumnoUpdate.Nombre = actualizar.Nombre;
                alumnoUpdate.Email = actualizar.Email;

                contexto.Alumnos.Update(alumnoUpdate);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;

            }

        }
        #endregion

        #region Delete
        public bool DeleteAlumno(int id)
        {
            var borrar = GetById(id);
            try
            {
                if (borrar == null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(borrar);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }
        #endregion

        #region left join
        public List<AlumnoAsignatura> SelectAlumAsig()
        {
            var consulta = from a in contexto.Alumnos
                           join m in contexto.Matriculas on a.Id equals m.AlumnoId
                           join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                           select new AlumnoAsignatura
                           {
                               nombreAlumno = a.Nombre,
                               nombreAsignatura = asig.Nombre
                           };
            return consulta.ToList();
        }

        #endregion

        #region leftJoinAlumnoMatriculaMateria
        public List<AlumnoProfesor> alumnoProfesors(string nombreProfesor)
        {
            var listadoALumno = from a in contexto.Alumnos
                                join m in contexto.Matriculas on a.Id equals m.AlumnoId
                                join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                                where asig.Profesor == nombreProfesor
                                select new AlumnoProfesor
                                {
                                    id = a.Id,
                                    dni = a.Dni,
                                    Nombre = a.Nombre,
                                    Direccion = a.Direccion,
                                    edad = a.Edad,
                                    email = a.Email,
                                    asignatura = asig.Nombre
                                };

            return listadoALumno.ToList();
        }
        #endregion

        #region update alumno

        public bool update(int id, Alumno actualizar)
        {
            try
            {
                var alumnoUpdate = GetById(id);

                if (alumnoUpdate == null)
                {
                    Console.WriteLine("Alumno es null");
                    return false;
                }

                alumnoUpdate.Direccion = actualizar.Direccion;
                alumnoUpdate.Dni = actualizar.Dni;
                alumnoUpdate.Nombre = actualizar.Nombre;
                alumnoUpdate.Email = actualizar.Email;

                contexto.Alumnos.Update(alumnoUpdate);
                contexto.SaveChanges();
                return true;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }
        #endregion

        #region Seleccionar por Dni
        public Alumno DNIAlumno(Alumno alumno) { 
            var alumnos = contexto.Alumnos.Where(x => x.Dni == alumno.Dni).FirstOrDefault();
            return alumnos == null ? null : alumnos;

        
        }
        #endregion

        #region AlumnoMatricula
        public bool InsertarMatricula(Alumno alumno, int idAsing) {
            try
            {
                var alumnoDNI = DNIAlumno(alumno);
                if (alumnoDNI == null)
                {
                    InsertarAlumno(alumno);
                    var alumnoInsertado = DNIAlumno(alumno);
                    var unirAlumnoMatricula = matriculaAsignaturaAlumno(alumno, idAsing);
                    if (unirAlumnoMatricula == false) { 
                        return false;
                    
                    }
                    return true;
                }
                else
                {
                    matriculaAsignaturaAlumno(alumnoDNI, idAsing);
                    return true;
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion
        #region Matriculaasig
        public bool matriculaAsignaturaAlumno(Alumno alumno, int idAsignatura) {

            try
            {
                Matricula matricula = new Matricula();
                matricula.Alumno.Id = alumno.Id;
                matricula.AsignaturaId = idAsignatura;

                contexto.Matriculas.Add(matricula);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion
    }
}
