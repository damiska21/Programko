using System;

namespace eventbb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trezor trezor = new Trezor(); //tvorba objektu
            trezor.Utok += Trezor_Utok;//přiřadí funkci Trezor_Utok na otevírání
            trezor.otevirani();//spouští se funkce
            Console.WriteLine(trezor.Otevreni); //zkontroluje jestli se to spustilo
            Console.ReadKey();
        }

        private static void Trezor_Utok()
        {
            Console.WriteLine("zaútočení kekw");
        }
    }
}