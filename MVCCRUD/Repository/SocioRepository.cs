using MVCCRUD.Models;

namespace MVCCRUD.Repository
{
    public class SocioRepository
    {
        private readonly MVCCRUDContext _contexto;

        public SocioRepository(MVCCRUDContext contexto)
        {
           _contexto = contexto;
        }

        public IEnumerable<Socio> ObtenerSocios()
        {
            return _contexto.Socios.ToList();
        }

        public void AgregarSocio(Socio socio) 
        {
            _contexto.Socios.Add(socio);
            _contexto.SaveChanges();

        }

        public void ActualizarSocio(Socio socio)
        {
            _contexto.Socios.Update(socio);
            _contexto.SaveChanges();

        }

        public void EliminarSocio(int id)
        {
            var socio = _contexto.Socios.Find(id);

            if(socio != null)
            {
                _contexto.Socios.Remove(socio);
                _contexto.SaveChanges();
            }
        }
    }
}
