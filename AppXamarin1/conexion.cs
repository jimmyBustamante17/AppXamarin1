using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public SQLite.SQLiteConnection Conectar()
            
            

    }
}