FotkaChoiceNet
==============

Aplikacja .NET w formie porównywarki zdjęć ze strony http://fotka.pl. Udostępnia również Api do strony http://fotka.pl

Aplikacja służy do porównania dwóch zdjęć. Wybierając to zdjęcie, które bardziej się podoba następuje przeładowanie zdjęcia obok aby było mozna skonfrontować je z następnym profilem.

Projekt składa się z 3 części:

* <b>fotka.pl</b> jest to projekt w technoloig WinForms, który jest odpowiedzialny za wyświetlanie i porównywanie zdjęć. 
* <b>FotkaNetApi</b> jest to biblioteka w C# odpowiedzialna za udostępnienie Api do strony http://fotka.pl
* <b>FotkaNetApiTest</b> jest to zbiór testów do aplikacji.


###Szybki start:

* Aplikacja fotka.pl jest to aplikacja napisana w .NET 4.5, wymaga połączenia z internetem. Nie trzeba być mieć konta na http://fotka.pl. Aplikaca ładuje zestaw profili ze strony http://www.fotka.pl/online/kobiety,1-30 a następnie pobiera zdjecia z tych profili. Pobiera pierwsze zdjęcie z galerii użytkownika. 

Aplikacja pobiera dwa zdjęcia (jedno dla każdego profilu) a następnie wyświetla je użytkownikowi aby wybrał (czyli kliknął) to które mu się podoba.

* FotkaNetApi to biblioteka w C#, która udostępnia 2 metody.
 1. GetOnLineProfiles - pobiera ze strony http://www.fotka.pl/online/kobiety,1-30 wszystkie nazwy użytkowników i zwraca listę obiektów Profile z wypełnionym atrybutem Name.
 2. GetProfile - pobiera adres Url zdjęcia użytkownika. Jest to pierwsze zdjęcie z jego galeri. 
 
Projekt jest sukcesywanie rozwijany. W planach jest rozwój API i rozwój aplikacji.



