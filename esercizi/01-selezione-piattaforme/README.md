# Esercizio: seleziona le piattaforme di destinazione del progetto
Di default, un progetto MAUI viene creato per le piattaforme Windows, Android, iOS e Windows.

- Da Visual Studio, fai tasto destro sul progetto e clicca "Proprietà" per vedere quali piattaforme sono referenziate dal progetto;
- Prendi confidenza con il file `.csrpoj` per capire agire direttamente sul suo contenuto per rimuoverne alcune (ad esempio, lascia referenziata solo la piattaforma Windows);
- Elimina le sottodirectory di `/Platforms` se non usi determinate piattaforme;
- Compila e avvia il progetto per verificare che l'applicazione parta sulla piattaforma desiderata.