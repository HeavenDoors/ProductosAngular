using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    //trterte
    public class Producto
    {
        public static ML.Result GetAll(int IdSubCategoria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProductoAngularContext context = new DL.ProductoAngularContext())
                {
                    var query = context.Productos.FromSqlRaw("GetAllProductos @IdSubCategoria",
                                                              new SqlParameter("@IdSubCategoria", IdSubCategoria));

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.Nombre;
                            producto.Descripcion = item.Descripcion;
                            producto.Precio = item.Precio;
                            producto.Imagen = item.Imagen;
                            producto.SubCategoria = new ML.SubCategoria();
                            producto.SubCategoria.IdSubCategoria = item.IdSubCategoria.Value;

                            result.Objects.Add(producto);
                        }

                        result.Success = true;
                    }
                    else
                    {
                        result.Success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
