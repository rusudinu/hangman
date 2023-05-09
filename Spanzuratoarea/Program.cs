using System;
using System.Collections.Generic;
using System.IO;

namespace Spanzuratoarea
{

  

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static List<char> cuvantFinal = new List<char>();
        static List<string> load1 = new List<string>();//LISTA CU CUVINTELE DUPA 1 FILTRARE
        static List<string> load2 = new List<string>();//LISTA CU CUVINTELE CARE AU PRIMA SI ULTIMA LITERA CORESPUNZATOARE


        static void Main()
        {
           //  Application.EnableVisualStyles();
           //  Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form1());
            Console.WriteLine("Gandeste-te la un cuvant");
            Console.WriteLine("Cate litere are ?");

            int len = Convert.ToInt32(Console.ReadLine());  // numarul de litere ale cuvantului
            string pLitera = "";
            string uLitera = "";

            try   // citirea cuvintelor din lista care au {len} litere
            {
                StreamReader sr = new StreamReader("wordlist");
                while(true)
                {
                    string cuvant = sr.ReadLine();
                    if (cuvant == null)
                    {
                        break;
                    }
                    else if (cuvant.Length == len)
                    {
                        load1.Add(cuvant);
                    }
                }

                sr.Close();
            }
            catch(Exception)
            {
                StreamWriter sw = new StreamWriter("wordlist", true);
                sw.Close();
            }

            Console.WriteLine("Care este prima litera ? ");
            pLitera =  Console.ReadLine();
            Console.WriteLine("Care este ultima litera ? ");
            uLitera = Console.ReadLine();


            cuvantFinal.Add(Convert.ToChar(pLitera));


            foreach (string cuvant in load1) //Filters the words that start and end with the specified letters
            {
                if (cuvant[1] == Convert.ToChar(pLitera) && cuvant[cuvant.Length] == Convert.ToChar(uLitera)) load2.Add(cuvant);
            }


            List<char> vocale = new List<char>();
            vocale.Add('a');
            vocale.Add('e');
            vocale.Add('i');
            vocale.Add('o');
            vocale.Add('u');

            List<char> consoane = new List<char>();
            consoane.Add('b');
            consoane.Add('c');
            consoane.Add('d');
            consoane.Add('f');
            consoane.Add('g');
            consoane.Add('h');
            consoane.Add('k');
            consoane.Add('l');
            consoane.Add('m');
            consoane.Add('n');
            consoane.Add('p');
            consoane.Add('q');
            consoane.Add('r');
            consoane.Add('s');
            consoane.Add('t');
            consoane.Add('v');
            consoane.Add('w');
            consoane.Add('x');
            consoane.Add('y');
            consoane.Add('z');

            //TODO CHECK THE LIST OF THE WORDS FOR THAT LETTER

            while (len - 2 > 0)
            {
                Console.WriteLine($"Urmatoarea litera este o vocala sau o consoana ? v/c");
                string raspuns = Console.ReadLine();
                Console.WriteLine(raspuns);
                if (raspuns == "v")
                {
                    foreach (char vocala in vocale)
                    {
                        foreach (string cuvant in load2)
                        {
                            if (cuvant.Contains(Convert.ToString(vocala)))
                            {
                                Console.WriteLine($"Urmatoarea litera este {vocala} ? y/n");
                                if (Console.ReadLine() == "y")
                                {
                                    len--;
                                    cuvantFinal.Add(vocala);
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (char consoana in consoane)
                    {

                        foreach (string cuvant in load2)
                        {
                            if (cuvant.Contains(Convert.ToString(consoana)))
                            {
                                Console.WriteLine($"Urmatoarea litera este {consoana} ? y/n");
                                if (Console.ReadLine() == "y")
                                {
                                    len--;
                                    cuvantFinal.Add(consoana);
                                }
                                break;
                            }
                        }
                    }
                }
               
            }

            cuvantFinal.Add(Convert.ToChar(uLitera));
            Console.Write("Cuvantul este  :   ");
            foreach (char cuvant in cuvantFinal) Console.Write(cuvant);
            //TODO load resources -> words that fit the requirements
            //TODO sort the resources and unload the ones that are not good 
            //TODO add words at the end of the game if the computer looses
            Console.ReadKey();
        }
    }
}
