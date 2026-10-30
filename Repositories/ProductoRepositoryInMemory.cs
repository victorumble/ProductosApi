using ProductosApi.Models;

namespace ProductosApi.Repositories
{
    public class ProductoRepositoryInMemory : IProductoRepository
    {
        private static readonly List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Rotor principal R22", Precio = 1500000m, Categoria = "Rotores", Activo = true },
            new Producto { Id = 2, Nombre = "Filtro de aceite Lycoming O-360", Precio = 85000m, Categoria = "Filtros", Activo = true },
            new Producto { Id = 3, Nombre = "Bujía aeronáutica", Precio = 45000m, Categoria = "Motor", Activo = true }
        };

        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {
            producto.Id = _productos.Count == 0 ? 1 : _productos.Max(p => p.Id) + 1;
            _productos.Add(producto);
        }

        public bool Actualizar(Producto producto)
        {
            int indice = _productos.FindIndex(p => p.Id == producto.Id);

            if (indice == -1)
                return false;

            _productos[indice] = producto;
            return true;
        }

        public bool Eliminar(int id)
        {
            var producto = ObtenerPorId(id);

            if (producto == null)
                return false;

            _productos.Remove(producto);
            return true;
        }
    }
}