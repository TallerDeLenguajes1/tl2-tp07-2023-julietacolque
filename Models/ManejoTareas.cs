namespace WebApi
{
    public class ManejoTareas
    {

        public AccesoADatos ManejoT { get; set; }


        public ManejoTareas(AccesoADatos acceso)
        {

            ManejoT = acceso; //no poner en la clase Manejo tareas la responsabilidad de inicializar la clase accesoAdatos.
        }

        public ManejoTareas()
        {
        }

        public  Tarea AddTarea(Tarea tarea)
        {
            var lista = AccesoADatos.Obtener();
            tarea.Id = lista.Count() + 1;
            lista.Add(tarea);
            AccesoADatos.Guardar(lista);
            return tarea;
        }

    }
}