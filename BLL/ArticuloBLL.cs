using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroVentas.DAL;
using RegistroVentas.Entidades;

namespace RegistroVentas.BLL
{
    public class ArticuloBLL
    {
        public static bool Guardar(Articulos articulo){
            if(!Existe(articulo.ArticuloId))
                return Insertar(articulo); 
            else    
                return Modificar(articulo);
        }
        private static bool Insertar(Articulos articulo){
            Contexto contexto = new Contexto();
            bool found = false;

            try{
                contexto.Articulos.Add(articulo);
                found = contexto.SaveChanges() > 0;
            
            } catch{
                throw;
            
            } finally{
                contexto.Dispose();
            }

            return found;
        }
        public static bool Modificar(Articulos articulo){
            Contexto contexto = new Contexto();
            bool found = false;

            try{
                contexto.Entry(articulo).State = EntityState.Modified;
                found = contexto.SaveChanges() > 0;
            
            } catch{
                throw;
            
            } finally{
                contexto.Dispose();
            }

            return found;
        }
        public static bool Eliminar(int id){
            Contexto contexto = new Contexto();
            bool found = false;

            try{
                var articulo = contexto.Articulos.Find(id);

                if(articulo != null){
                    contexto.Articulos.Remove(articulo);
                    found = contexto.SaveChanges() > 0;
                }
            
            } catch{
                throw;
            
            } finally{
                contexto.Dispose();
            }

            return found;
        }
        public static Articulos Buscar(int id){
            Contexto contexto = new Contexto();
            Articulos articulo;

            try{
                articulo = contexto.Articulos.Find(id);
            
            } catch{
                throw;
            
            } finally{
                contexto.Dispose();
            }

            return articulo;
        }
        public static bool Existe(int id){
            Contexto contexto = new Contexto();
            bool found = false;

            try{
                found = contexto.Articulos.Any(p => p.ArticuloId == id);
            
            } catch{
                throw;
            
            } finally{
                contexto.Dispose();
            }

            return found;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> criterio)
        {
            List<Articulos> list = new List<Articulos>();
            Contexto contexto = new Contexto();

            try {
                list = contexto.Articulos.Where(criterio).AsNoTracking().ToList<Articulos>();

            } catch  {
                throw;

            } finally {
                contexto.Dispose();
            }

            return list;
        }
    }
}