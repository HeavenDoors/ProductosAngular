import { SubCategoria } from './SubCategoria'

export interface Producto {
  IdProducto?:  number;
  Nombre?:      string;
  Descripcion?: string;
  Precio?: number;
  Imagen?: Uint16Array[];
  SubCategoria?: SubCategoria;
}
