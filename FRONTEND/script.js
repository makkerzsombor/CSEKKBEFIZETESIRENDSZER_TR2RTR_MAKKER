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

    const response = await fetch('http://localhost:5193/api/payment', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ nev, osszegSzam, osszegSzoveg, datum })
    });

    const uzenetDiv = document.getElementById('uzenet');
    const tabla = document.getElementById('befizetesTabla');
    const tbody = tabla.querySelector('tbody');

    if (!response.ok) {
        const hiba = await response.text();
        uzenetDiv.innerHTML = `<div class="alert alert-danger">${hiba}</div>`;
        return;
    }
});