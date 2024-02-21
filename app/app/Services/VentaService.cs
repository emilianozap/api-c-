using app.database;
using app.models;

namespace app.Services
{
    public class VentaService
    {
        private CoderContext context;
        public VentaService(CoderContext coderContext)
        {
            this.context = coderContext;

        }


        public List<Ventum> ObtenerTodosLasVentas()
        {
            return this.context.Venta.ToList();

        }
    }
}
