using System;
using System.Drawing;

namespace Ejercicios_Sem_10
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Arboles binarios");
            Nodo Arbol = null;
            int datox = 15;
            if (Arbol == null)
            {
                Nodo nuevo = new Nodo();
                nuevo.dato = datox;
                Arbol = nuevo;
            }

            Insertar(Arbol, 10);
            Insertar(Arbol, 20);
            Insertar(Arbol, 25);
            Insertar(Arbol, 5);
            //Console.WriteLine("Recorrido PreOrden: ");
            //PreOrden(Arbol);
            //Console.WriteLine("-----------------");
            //Console.WriteLine("Recorrido InOrden: ");
            //InOrden(Arbol);
            //Console.WriteLine("-----------------");
            //Console.WriteLine("Recorrido PostOrden: ");
            //PostOrden(Arbol);
            //Console.WriteLine("-----------------");
            Console.WriteLine("Recorrido InOrdenDescendentemente: ");
            InOrdenDesc(Arbol);
            //Console.WriteLine("Suma: ");
            //Console.WriteLine(SumaArbol(Arbol));

            //Console.WriteLine("Busqueda: ");
            //bool busq;
            //busq = Busqueda(Arbol, 25);
            //Console.WriteLine(busq);
            //busq = Busqueda(Arbol, -1);
            //Console.WriteLine(busq);
            //Console.WriteLine("------------------");
            //Console.WriteLine("Eliminacion:");
            //Arbol = Eliminacion(Arbol, 20);
            //PreOrden(Arbol);
            int mayor, menor, dif, longi;
            //mayor = MayorElemento(Arbol);
            //Console.WriteLine("Elemento mayor: " + mayor);
            //menor = MenorElemento(Arbol);
            //Console.WriteLine("Elemento menor: " + menor);
            //dif = Diferencia(Arbol);
            //Console.WriteLine("Diferencia de elementos mayor y menor: " + dif);
            //Console.WriteLine("Hojas del Arbol: ");
            //Hojas(Arbol);
            //longi = Longitud(Arbol, 5);
            //Console.WriteLine("La Longitud para llegar a " + 5 + " es " + longi);
            //Console.WriteLine("El recorrido para llegar a este dato es: ");
            //RecorridoLongitud(Arbol, 5);

        }

        static Nodo Eliminacion(Nodo arbol, int valor)
        {
            if (arbol == null)
            {
                return arbol;
            }
            else
            {
                if (valor == arbol.dato)
                {
                    if (arbol.izq != null && arbol.der != null)
                    {
                        arbol = EliminarDosHijos(arbol);
                    }
                    else
                    {
                        if (arbol.izq != null || arbol.der != null)
                        {
                            arbol = EliminarUnHijo(arbol);
                        }
                        else
                        {
                            arbol = EliminarHoja(arbol);
                        }
                    }
                }
                else
                {
                    if (valor < arbol.dato) { arbol.izq = Eliminacion(arbol.izq, valor); }
                    else { arbol.der = Eliminacion(arbol.der, valor); }
                }
                return arbol;
            }
        }

        static Nodo EliminarDosHijos(Nodo arbol)
        {
            int menor;
            Nodo nodoMenor = arbol.der;
            while (nodoMenor.izq != null)
            {
                nodoMenor = nodoMenor.izq;
            }
            menor = nodoMenor.dato;
            arbol = Eliminacion(arbol, nodoMenor.dato);
            arbol.dato = menor;
            return arbol;
        }

        static Nodo EliminarHoja(Nodo arbol)
        {
            arbol = null;
            return arbol;
        }

        static Nodo EliminarUnHijo(Nodo arbol)
        {
            Nodo aux = arbol;
            if (arbol.izq != null)
            {
                arbol = arbol.izq;
            }
            else
            {
                arbol = arbol.der;
            }
            aux = null;
            return arbol;
        }

        static bool Busqueda(Nodo arbol, int valor)
        {
            if (arbol == null)
            {
                return false;
            }
            else
            {
                if (valor < arbol.dato)
                {
                    return Busqueda(arbol.izq, valor);
                }
                else
                {
                    if (valor > arbol.dato)
                    {
                        return Busqueda(arbol.der, valor);
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }


        static void Insertar(Nodo Arbol, int Valor)
        {
            if (Valor < Arbol.dato)
            {
                if (Arbol.izq == null)
                {
                    Nodo nuevo = new Nodo();
                    nuevo.dato = Valor;
                    Arbol.izq = nuevo;
                }
                else
                {
                    Insertar(Arbol.izq, Valor);
                }
            }
            else
            {
                if (Valor > Arbol.dato)
                {
                    if (Arbol.der == null)
                    {
                        Nodo nuevo = new Nodo();
                        nuevo.dato = Valor;
                        Arbol.der = nuevo;
                    }
                    else
                    {
                        Insertar(Arbol.der, Valor);
                    }
                }
                else
                {
                    Console.WriteLine("Dato repetido");
                }
            }
        }

        static void PreOrden(Nodo Arbol)
        {
            if (Arbol != null)
            {
                Console.WriteLine(Arbol.dato);
                PreOrden(Arbol.izq);
                PreOrden(Arbol.der);
            }
        }
        static void InOrden(Nodo Arbol)
        {
            if (Arbol != null)
            {
                InOrden(Arbol.izq);
                Console.WriteLine(Arbol.dato);
                InOrden(Arbol.der);
            }
        }
        static void InOrdenDesc(Nodo Arbol)
        {
            if (Arbol != null)
            {
                InOrdenDesc(Arbol.der);
                Console.WriteLine(Arbol.dato);
                InOrdenDesc(Arbol.izq);
            }
        }
        static void PostOrden(Nodo Arbol)
        {
            if (Arbol != null)
            {
                PostOrden(Arbol.izq);
                PostOrden(Arbol.der);
                Console.WriteLine(Arbol.dato);
            }
        }
        static int SumaArbol(Nodo Arbol)
        {
            if (Arbol == null)
            {
                return 0;
            }
            return Arbol.dato + SumaArbol(Arbol.der) + SumaArbol(Arbol.izq);
        }
        static int MayorElemento(Nodo arbol)
        {
            if (arbol.der == null) return arbol.dato;
            return MayorElemento(arbol.der);
        }
        static int MenorElemento(Nodo arbol)
        {
            if (arbol.izq == null) return arbol.dato;
            return MenorElemento(arbol.izq);
        }
        static int Diferencia(Nodo arbol)
        {
            return MayorElemento(arbol) - MenorElemento(arbol);
        }
        static void Hojas(Nodo arbol)
        {
            if (arbol != null)
            {
                Hojas(arbol.izq);
                if (arbol.izq == null && arbol.der == null)
                {
                    Console.WriteLine(arbol.dato);
                }
                Hojas(arbol.der);
            }
        }
        static int Longitud(Nodo arbol, int elemento)
        {
            if (arbol.dato == elemento) return 0;
            if (elemento > arbol.dato) return 1 + Longitud(arbol.der, elemento);
            return 1 + Longitud(arbol.izq, elemento);
        }
        static void RecorridoLongitud(Nodo arbol, int elemento)
        {
            Console.WriteLine(arbol.dato);
            if (arbol.dato != elemento)
            {
                if (elemento > arbol.dato) RecorridoLongitud(arbol.der, elemento);
                else RecorridoLongitud(arbol.izq, elemento);
            }
        }
    }
}