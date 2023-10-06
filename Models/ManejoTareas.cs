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

        public Tarea AddTarea(Tarea tarea)
        {
            var lista = AccesoADatos.Obtener();
            tarea.Id = lista.Count() + 1;
            lista.Add(tarea);
            AccesoADatos.Guardar(lista);
            return tarea;
        }

        public Tarea BuscarTporId(int id){
            var lista = AccesoADatos.Obtener();
            var tarea = lista.FirstOrDefault(t=>t.Id == id);
            return tarea;
        }

        public void EliminarTarea(int id){
            var lista = AccesoADatos.Obtener();
            var tarea = BuscarTporId(int id);
            lista.Remove(tarea);
            AccesoADatos.Guardar(lista);

        }

        public List<Tarea> ListarTareas(){
            var lista = AccesoADatos.Obtener();
            return lista;
        }

        public List<Tarea> ListarTareasCompletadas(){
            var lista = AccesoADatos.Obtener();
            var completadas = lista.FindAll(t=> t.Estado == Estado.completadas);
            return completadas;
        }

    }
}