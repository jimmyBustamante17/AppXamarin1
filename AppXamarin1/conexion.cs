using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Path = System.IO.Path;

namespace AppXamarin1 { 

    public class Login {
    }

    public class Ticket { 
    }

    internal class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection conexion;

        public Auxiliar (){

            conexion = Conectar();
            conexion.CreateTable<Login>();
        }

        //Metodo para realizar la conexión a la base de datos
        public SQLite.SQLiteConnection Conectar()
        {
            SQLiteConnection conexionAuxiliar;
            String nombreArchivo = "tdea.db3";
            String ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta,nombreArchivo);
            conexionAuxiliar = new SQLiteConnection(rutaCompleta);
            return conexionAuxiliar;
        }

        //MANEJO DE LOS DATOS

        //Seleccionar todo
        public IEnumerable<Login> SeleccionarTodo() { 
        
            lock (locker)
            {
                return (from i in conexion.Table<Login>() select i).ToList();
            }
        }

        //Selecciona run registro
        public Login Seleccionar(String userName, String password)
        {
            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.UserName == userName && x.Password == password);
            }
        }
         
        public int Guardar(Login registro)
        {
            lock (locker)
            {
                if(registro.id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }


        //Eliminar unr registro
        public int eliminar(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<Login>(ID);
            }
        }


            

    }
}