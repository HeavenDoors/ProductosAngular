using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProductoAngularContext context = new DL.ProductoAngularContext())
                {
                    var query = context.Categoria.FromSqlRaw("GetAllCategoria");

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Categoria categoria = new ML.Categoria();

                            categoria.IdCategoria = item.IdCategoria;
                            categoria.Nombre = item.Nombre;

                            result.Objects.Add(categoria);
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
                result.Success = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
