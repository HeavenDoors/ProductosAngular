using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubCategoria
    {
        public static ML.Result GetAll(int IdCategoria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProductoAngularContext context = new DL.ProductoAngularContext())
                {
                    var query = context.SubCategoria.FromSqlRaw("GetAllSubCategoria @IdCategoria",
                                                                  new SqlParameter("@IdCategoria", IdCategoria));

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.SubCategoria subCategoria = new ML.SubCategoria();

                            subCategoria.IdSubCategoria = item.IdSubCategoria;
                            subCategoria.Nombre = item.Nombre;

                            result.Objects.Add(subCategoria);
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
