using reactBAckend.Models;
using reactBAckend.Repository;




AlumnoDao alumnoDao = new AlumnoDao();
#region
var alumno = alumnoDao.SelectAll();
foreach (var item in alumno) 
{
    Console.WriteLine(item.Nombre);
}
#endregion
Console.WriteLine("");

#region SelectByID
var selectByID = alumnoDao.GetById(1000);
Console.WriteLine(selectByID?.Nombre);
#endregion
Console.WriteLine(" ");

#region addAlumno
var nuevoAlumno = new Alumno
{
    Direccion = "Chalatenango , Barrio el Centro ",
    Dni = "1345",
    Edad = 30,
    Email = "12344321@email",
    Nombre = "Ricardo JR Milos "
};

var resultado = alumnoDao.InsertarAlumno(nuevoAlumno);
Console.WriteLine(resultado);
#endregion

#region alumnoUpdate
var nuevoAlumno2 = new Alumno
{
    Direccion = "Chalatenango, Barrio el Centro",
    Dni = "1345",
    Edad = 30,
    Email = "5@email",
    Nombre = "Williams"
};
var resultado2 = alumnoDao.Update(2, nuevoAlumno2);
Console.WriteLine(resultado2);
#endregion


#region Borrar
var result =  alumnoDao.DeleteAlumno(1007);
Console.WriteLine("Se elimnina " + result);
#endregion


#region alumnoAsignatura desde un JOIN

var alumAsig = alumnoDao.SelectAlumAsig();

foreach (AlumnoAsignatura alumAsig2 in alumAsig)
{
    Console.WriteLine(alumAsig2.nombreAlumno + " Asignatura que cursa " + alumAsig2.nombreAsignatura);

}
#endregion