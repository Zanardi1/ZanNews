using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;

namespace ZanScore
/*
O biblioteca ce contine toate functiile necesare prelucrarii unui fisier RSS:
1. Deschiderea unui fisier RSS;
2. Validarea acestuia;
3. Citirea si interpretarea lui;
4. Extragerea informatiilor din el si punerea lor in program;
5. 

 */

{
    internal class RSSTools
    {
        readonly string FileToProcess;

        public RSSTools(string File)
        //Constructor. Parametrul reprezinta fisierul care va fi citit
        {
            FileToProcess = File;
        }

        public bool CheckRSSFile()
        //Metoda verifica daca fisierul RSS exista sau nu
        {
            if (File.Exists(FileToProcess))
                return true;
            else
            {
                MessageBox.Show("Fisierul " + FileToProcess + " nu exista");
                return false;
            }
        }

        public string[] ReadRSSContent()
        //Citeste continutul fisierului RSS
        {
            string[] text = File.ReadAllLines(FileToProcess);
            return text;
        }


    }
}