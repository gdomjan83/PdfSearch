using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSearcher {
    internal class TextUsed {
        public const string VERSION = "1.1";
        public const string START_SEARCH = "Keresés indítása";
        public const string MONTH_INPUT = "Hónap (formátum: 2025.09):";
        public const string PATH_LABEL = "Elérési útvonal (csak akkor módosítandó, ha más mappába kerülnek a bérkarton fájlok):";
        public const string NAMES_LABEL = "Keresni kívánt nevek:";
        public const string RESULTS_LABEL = "Eredmény:";
        public const string DEFAULT_LABEL = "Visszaállítás";
        public const string VERSION_LABEL = "Verzió: ";
        public const string HELP_LABEL = "Súgó";
        public const string WINDOWS_TITLE = "PDF kereső";
        public const string SEARCH_IN_PROGRESS = "Oldalak keresése...";
        public const string EXPORT_IN_PROGRESS = "Exportálás...";
        public const string OPEN_FOLDER_TEXT = "Mentés mappa megnyitása";


        public const string WRONG_MONTH_EXCEPTION_TEXT = "Nem megfelelő formátumú hónap. (Helyesen például: 2025.09)";
        public const string FILE_NOT_FOUND_TEXT_1 = "Nem megfelelő formátumú hónap. (Helyesen például: 2025.09)";
        public const string FILE_NOT_FOUND_TEXT_2 = "Ellenőrizze az eléséri útvonalat, illetve győzödjön meg, " +
            "hogy az adott hónap bérkarton fájlja megtalálható az adott mappában. A fájlnév formátuma például: 2025.09.pdf";
        public const string NAMES_NOT_FOUND_TEXT = "Kérem adja meg a keresni kívánt neveket.";
        public const string FINISHED_TEXT = "Művelet befejezve. Az elkészült PDF fájlt megtalálja a DOKUMENTUMOK/LAPOLVASÁS mappában.";
        public const string RESULTS_TEXT = "Találati oldalak:";
        public const string NAME_FOUND_TEXT = " - OK";
        public const string NAME_NOT_FOUND_TEXT = " nem található a dokumentumban.";
        public const string FILE_EXTENSION = ".pdf";
        public const string NAME_NOT_FOUND_END_TEXT = "FIGYELEM! Volt olyan név a keresettek között, amely nem volt megtalálható " +
            "a bérkarton fájlban!";
        public const string DIRECTORY_NOT_FOUND_TEXT = "Nem létezik a Dokumentumok/lapolvasás elérési útvonal. A pdf fájl nem került elmentésre.";
        public const string DIRECTORY_NOT_OPENED_TEXT = "Nem sikerült megnyitni a Dokumentumok/lapolvasás mappát.";
        public const string CRITICAL_EXCEPTION_TEXT = "Ismeretlen hiba lépett fel a program futtatása során.\n\n";


        public const string FOLDER_PATH = "\\\\GMFTS.uni-pannon.hu\\munkahely\\Közös Dokumentumok\\!Szervezetek\\Pénzügyi Főosztály\\Projekt és keretgazdálkodási Csoport\\bérkarton\\Digitális projekt bérkartonok";
        public const string EXPORT_PATH = "C:\\Users\\felhasználó\\Documents\\lapolvasás\\";

        public const string HELP_TEXT = $"A {WINDOWS_TITLE} alkalmazás segítségével a bérkarton pdf fájlokban lehetőség van neveket keresni," +
            $"és azokat az oldalszámokat megkapni, amelyeken az adott dolgozó bérkartonja található.\n\nAz így kapott oldalszámokhoz tartozó " +
            $"oldalakat az alkalmazás a Dokumentumok/lapolvasás mappába egy külön PDF fájlba elmenti.\n\nAz alkalmazás használata:\n\n" +
            $"1. A hónap mezőbe be kell írni, hogy melyik hónap bérkartonjait keressük, a következő formátumban: 2025.09\n\n" +
            $"2. A keresett nevek ablakba beírni, vagy bemásolni azokat a neveket, amelyekhez az oldalszámokat meg kívánjuk kapni. Az alkalmazás " +
            $"képes több név keresésére.Minden névnek külön sorban kell szerepelnie.\n\n" +
            $"3. Az alkalmazás ablakának alján látható az az elérési útvonal, ahol a bérkarton fájloknak lennie kell. Ha ez megváltozik, akkor " +
            $"át kell írni az elérési útvonalat is. A fájlok neveinek a következő formátumban kell lennie: 2025.09\n\n" +
            $"4. A keresés indítása gommbal indítható a keresés.\n\n" +
            $"5. A visszaállítás gombbal kitörölhetjük a megadott adatokat.\n\n" +
            $"6. Az eredmény ablakban tájékozatást kap a felhasználó arról, hogy a megadott név megtalálható volt-e a bérkarton " +
            $"fájlban, illetve megjelennek azok az oldalszámok, amelyeken a dolgozók szerepelnek a bérkarton fájlban.\n\n" +
            $"7. A művelet végén a megkapott oldalszámokhoz tartozó oldalak egy külön PDF fájlban elmentésre kerülnek a " +
            $"Dokumentumok/lapolvasás mappában.\n\n" +
            $"8. A Lapolvasás mappa megnyitható a Mentés mappa megnyitása gomb használatával.";




    }
}
