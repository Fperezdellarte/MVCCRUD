using MVCCRUD.Models;

namespace MVCCRUD.Repository
{
    public class ClaseRepository
    {
        private readonly MVCCRUDContext _contexto;

        public ClaseRepository(MVCCRUDContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Clase> ObtenerClases()
        {
            return _contexto.Clases.ToList();
        }

        public void AgregarClase(Clase clase)
        {
            _contexto.Clases.Add(clase);
            _contexto.SaveChanges();

        }

        public void ActualizarClase(Clase clase)
        {
            _contexto.Clases.Update(clase);
            _contexto.SaveChanges();

        }

        public void EliminarClase(int id)
        {
            var clase = _contexto.Clases.Find(id);

            if (clase != null)
            {
                _contexto.Clases.Remove(clase);
                _contexto.SaveChanges();
            }
        }
    }
}
