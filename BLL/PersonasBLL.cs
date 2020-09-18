using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class PersonasBLL 
{
    public static bool Guardar(Personas Persona)
    {
        if (!Existe(Persona.PersonaId))
        {
            return Insertar(Persona);
        }
        else 
        {
            return Modificar(Persona);
        }
    
    }

    public static bool Existe(int Id)
    {
        bool paso = false;
        Contexto contexto = new Contexto();
        try 
        {
            paso = contexto.Personas.Any(e => e.PersonaId ==  Id);
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            contexto.Dispose();
        }
        return paso;
    }

    private static bool Modificar(Personas Persona)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;
            
            try
            {
                contexto.Entry(Persona).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var Persona = contexto.Personas.Find(id);

                if (Persona != null)
                {
                    contexto.Personas.Remove(Persona);
                    eliminado = (contexto.SaveChanges() > 0);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas Persona = new Personas();

            try
            {
                Persona = contexto.Personas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Persona;
        }

        private static bool Insertar(Personas Persona)
        {
            Contexto contexto = new Contexto();
            bool guardado = false;

            try
            {
                
                if (contexto.Personas.Add(Persona) != null)
                    guardado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }
}