document.getElementById('befizetesForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const nev = document.getElementById('nev').value;
    const osszegSzam = parseInt(document.getElementById('osszegSzam').value);
    const osszegSzoveg = document.getElementById('osszegSzoveg').value;
    const datum = document.getElementById('datum').value;

    // Összeg tartomány ellenőrzés
    if (osszegSzam < 1 || osszegSzam > 10000000) {
        alert("Az összegnek 1 és 10 000 000 közé kell esnie!");
        return;
    }
});