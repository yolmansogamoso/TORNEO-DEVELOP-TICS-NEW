using System;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT repoDT = new RepositorioDT();
        private static IRepositorioEquipo repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion repoPosicion = new RepositorioPosicion();
        private static IRepositorioJugador repoJugador = new RepositorioJugador();
        private static IRepositorioPartido repoPartido = new RepositorioPartido();

        static void Main(string[] args)
        {
            /* Inteface por consola */
            int opcion = 0;
            do
            {
                Console.WriteLine("___________BIENVENIDO______________");
                Console.WriteLine("|/|/|/|/|/|/|/|/|/|/|/|/|/|/|/|/|/|");
                Console.WriteLine("___________INSERTAR________________");
                Console.WriteLine("(1) Insertar Muinicipio");
                Console.WriteLine("(2) Insertar Director Tecnico");
                Console.WriteLine("(3) Insertar Equipo");
                Console.WriteLine("(4) Insertar Posicion");
                Console.WriteLine("(5) Insertar Jugador");
                Console.WriteLine("(6) Insertar Partido");
                Console.WriteLine("");
                Console.WriteLine("___________MOSTRAR___________________");
                Console.WriteLine("(7) Mostrar Municipios");
                Console.WriteLine("(8) Mostrar Directores Tecnicos");
                Console.WriteLine("(9) Mostrar Equipos");
                Console.WriteLine("(10) Mostrar Posiciones");
                Console.WriteLine("(11) Mostrar Jugadores");
                Console.WriteLine("(12) Mostrar Partidos");
                Console.WriteLine("(0) Salir");
                Console.WriteLine("");
                Console.WriteLine("Ingrese Opcion---------------------");
                opcion = Int32.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch(opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;
                    case 2: 
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break;
                    case 4:
                        AddPosicion();
                        break;
                    case 5:
                        AddJugador();
                        break;
                    case 6:
                        AddPartido();
                        break;
                    case 7:
                        GetAllMunicipios();
                        break;
                    case 8:
                        GetAllDT();
                        break;
                    case 9:
                        GetAllEquipos();
                        break;
                    case 10:
                        GetAllPosiciones();
                        break;
                    case 11:      
                        GetAllJudores();              
                        break;
                    case 12:
                        GetAllPartidos();
                        break;
                }
            } while (opcion != 0);

        }

        /*________Funciones para ingresar los datos por consola________*/
        private static void AddMunicipio()
        {
            Console.WriteLine("Ingrese nombre del municipio");
            String nombre = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = nombre
            };

            repoMunicipio.AgregarMunicipio(municipio);

        }   

        private static void AddDT()
        {
            Console.WriteLine("Ingrese nombre DT");
            String nombre =  Console.ReadLine();
            Console.WriteLine("Ingrese documento");
            String documento = Console.ReadLine();
            Console.WriteLine("Ingrese numero de telefono");
            String numeroTlf = Console.ReadLine();
            var DT = new DirectorTecnico
            {
                Nombre = nombre,
                Documento = documento,
                Telefono = numeroTlf
            };

            repoDT.AgregarDT(DT);
        }

        private static void AddEquipo()
        {
            Console.WriteLine("Ingrese nombre del equipo");
            String nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el id del Municipio");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese id del Director Tecnico");
            int idDT = Int32.Parse(Console.ReadLine());

            var equipo = new Equipo
            {
                Nombre = nombre,
            };

            repoEquipo.AgregarEquipo(equipo, idMunicipio, idDT);
        
            
        }

        private static void AddPosicion()
        {
            Console.WriteLine("Ingrese la posicion");
            String nombre = Console.ReadLine();
            var posicion = new Posicion
            {
                Nombre = nombre,
            };
            repoPosicion.AgregarPosicion(posicion);
        }

        private static void AddJugador()
        {
            Console.WriteLine("Ingresar nombre del jugador");
            String nombre = Console.ReadLine();
            Console.WriteLine("Ingresar numero del jugador");
            int numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar id equipo");
            int idEquipo = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar id posicion");
            int idPosicion = Int32.Parse(Console.ReadLine());

            var jugador = new Jugador
            {
                Nombre = nombre,
                Numero = numero
            };
            
            repoJugador.AgregarJugador(jugador, idEquipo, idPosicion);
        }

        private static void AddPartido()
        {
            Console.WriteLine("Ingresar fecha hora con formato yy/dd/mm/ hh:mm");
            DateTime fechaHora = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese equipo local");
            int local = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese marcador local");
            int marcadorLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese equipo visitante");
            int visitante = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese marcador visitante");
            int marcadorVisitante = Int32.Parse(Console.ReadLine());
            var partido = new Partido
            {
                FechaHora = fechaHora,
                MarcadorLocal = marcadorLocal,
                MarcadorVisitante = marcadorVisitante,
            };

            repoPartido.AgregarPartido(partido, marcadorLocal, marcadorVisitante);
        }

        /*________Funciones que muestran lod datos por consola________*/
        private static void GetAllMunicipios()
        {
            foreach(var municipio in repoMunicipio.GetAllMunicipios()) 
            {
                Console.WriteLine("Id: " + municipio.id + ") " + municipio.Nombre);
            }
        }

        private static void GetAllDT()
        {
            foreach(var dt in repoDT.GetAllDTs())
            {
                Console.WriteLine("Id: " + dt.Id + ") " + dt.Nombre + " Doc: " + dt.Documento + " Tlf: " + dt.Telefono );
            }
        }

        private static void GetAllEquipos()
        {
            foreach(var equipo in repoEquipo.GetAllEquipos())
            {
                Console.WriteLine("Id: " + equipo.Id + ") " + equipo.Nombre + ". Municipio: " + equipo.Municipio.Nombre + ". DT: " + equipo.DirectorTecnico.Nombre );
            }
        }

        private static void GetAllPosiciones()
        {
            foreach( var posicion in repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine("Id: " + posicion.Id + " " + posicion.Nombre);
            }
        }

        private static void GetAllJudores()
        {
            foreach(var jugador in repoJugador.GetAllJugadores())
            {
                Console.WriteLine("id: " + jugador.Id + " " + jugador.Nombre + " Numero: " + jugador.Numero + " Equipo: " + jugador.Equipo.Nombre + " Posicion: " + jugador.Posicion.Nombre );
            };
        }

        private static void GetAllPartidos()
        {
            foreach(var partido in repoPartido.GetAllPartidos())
            {
                Console.WriteLine("Id: " + partido.Id + " Fecha hora: " + partido.FechaHora + " Local: " + partido.Local.Nombre + ". Marcador local: " + partido.MarcadorLocal + ". Visitante: " + partido.Visitante.Nombre + ". Marcador vistante: " + partido.MarcadorVisitante);
            }
        }

       
    }
}