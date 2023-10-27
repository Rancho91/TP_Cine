﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Maestras
{
    public class Pelicula
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public Generos Genero { get; set; }
        public Clasificaciones Clasificacion { get; set; }
        public Paises Pais { get; set; }

        public TimeSpan Duracion { get; set; }
        public Pelicula()
        {
            Codigo = 0;
            Nombre=string.Empty;
            Genero = new Generos();
            Clasificacion = new Clasificaciones();
            Pais = new Paises();

            Duracion = TimeSpan.FromHours(2) + TimeSpan.FromMinutes(30);
        }

        public Pelicula(int codigo, string nombre, Generos genero, Clasificaciones clasificacion, Paises pais, TimeSpan duracion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Genero = genero;
            Clasificacion = clasificacion;
            Pais = pais;
            Duracion = duracion;

        }

    
    }
}