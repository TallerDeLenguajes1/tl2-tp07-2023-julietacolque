using System.Text.Json;


namespace  WebApi
{
    public class AccesoADatos
    {
        public static  List<Tarea> Obtener()
        {
            string texto;
            var listaTareas = new List<Tarea>();
            string path = "Tareas.json";
            if (File.Exists(path))
            {
                using (var archivo = new FileStream(path, FileMode.Open))
                {
                    using (var sr = new StreamReader(archivo))
                    {
                        texto = sr.ReadToEnd();
                        listaTareas = JsonSerializer.Deserialize<List<Tarea>>(texto);

                    }
                }
            }
            return listaTareas;

        }

        public static void Guardar(List<Tarea>lista){

            var path = "Tareas.json";
            string texto = JsonSerializer.Serialize(lista);
            File.WriteAllText(path,texto);
        }
    }
}