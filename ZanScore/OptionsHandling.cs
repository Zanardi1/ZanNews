using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Clasa ce se ocpa de manipularea fisierului de optiuni si de punerea in aplicare a optiunilor citite.
 Proprietati:
 
     1. WindowsStartup. true daca aplicatia porneste odata cu Windows, false altfel
     2. MinimizeToTray. true daca aplicatia se minimizeaza in SysTray, false altfel
     3. StartupOptions. 1 daca aplicatia va porni cu fereastra minimizata, 2 daca va porni cu fereastra la dimensiunile implicite, 3 daca va porni cu fereastra maximizata
     4. DisableInvalidNewsFiles. true daca dezactiveaza sursele de stiri care au fisiere RSS invalide, false altfel
     5. WindowWidth. Retine latimea ferestrei atunci cand programul a fost inchis
     6. WindowHeight. Acelasi lucru, dar pentru inaltimea ferestrei
     7. WindowLeft. Acelasi lucru pentru distanta de la marginea din stanga a ecranului la partea din stanga a ferestrei
     8. WindowTop. Acelasi lucru pentru distanta de la marginea de sus a ecranului la partea de sus a ferestrei
     
Metode:
     
     1.Deschiderea fisierului de optiuni
     2.Verificarea existentei lui si, daca el nu exista, crearea unuia nou, cu optiuni implicite
     3.Salvarea optiunilor in fisier
     4.Citirea optiunilor din fisier (atribuirea valorilor citite din fisier catre proprietatile clasei 
     5.Afisarea acestora in ferastra de optiuni
     6.Verificarea integritatii continutului fisierului de optiuni*/

namespace ZanScore
{
    class OptionsHandling
    {
        bool WindowsStartup;
        bool MinimizeToTray;
        int StartupOptions;
        bool DisableInvalidNewsFiles;
        int WindowWidth;
        int WindowHeight;
        int WindowLeft;
        int WindowTop;

        public OptionsHandling()
        {

        }

        public void OpenOptionsFile()
        {

        }

        public bool CheckOptionsFileExistence()
        {
            return true;
        }

        public void SaveOptionsToFile()
        {

        }

        public void ReadOptionsFromFile()
        {

        }

        public void ShowOptionsInOptionsWindow()
        {

        }

        public bool CheckOptionsFileContent()
        {
            return true;
        }
    }
}
