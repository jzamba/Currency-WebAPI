// JavaScript file that implement logic for list-all-currencies.html

import { CurrencyAPI } from "/assets/js/currencyAPI.js"

window.onload = (e) => {
    document.getElementById('get-all-currencies-button')?.addEventListener('click', LoadTable);
    document.getElementById('clear-all-currencies-button')?.addEventListener('click', ClearTable);
    document.getElementById('home-button')?.addEventListener('click', () => { window.location.href = '/index.html' });
    ClearTable();
}

async function LoadTable() {
    const currencies = await CurrencyAPI.GetAllCurrencies();
    if(!currencies) {
        console.error('Could not load currencies.')
        return;
    }

    const table = document.getElementById('currency-table');
    if(!table) {
        console.error('Could not find currency table.')
        return;
    }

    // Construct table rows for currency data

    /*
        The idea is to get the currencies from the backend as JSON:
        [
            {
                "id": 1,
                "CurrencyName": "Currency 1",
                "CurrencySymbol": "This is the first symbol",
                "Country": "Country1",
                "Continent": "Continent1",
                "BiggestCoin": "Five"
            },
            {
                "id": 1,
                "CurrencyName": "Currency 1",
                "CurrencySymbol": "This is the first symbol",
                "Country": "Country1",
                "Continent": "Continent1",
                "BiggestCoin": "Five"
            }
        ]

        And manually create and insert HTML for that data into <table> tag:

        <thead>
            <tr>
                <th>CurrencyName</th>
                <th>CurrencySymbol</th>
                <th>Country</th>
                <th>Continent</th>
                <th>BiggestCoin</th>
                <th>Timestamp</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td>Currency 1</td>
                <td>This is a first currency</td>
                <td>Country1</td>
                <td>Continent1</td>
                <td>BiggestCoin1</td>
            </tr>
            <tr>
                <td>2</td>
                <td>Currency 2</td>
                <td>This is the second currency</td>
                <td>Country2</td>
                <td>Continent2</td>
                <td>BiggestCoin2</td>
            </tr>  
        </tbody>

    */

    ClearTable();

    let table_body = table.getElementsByTagName('tbody')?.[0];
    if(!table_body) {
        console.error('Could not find <tbody> in currency table!');
        return;
    }

    // Add each row manually
    currencies.forEach(e => {
        const row = document.createElement('tr');
        row.addEventListener('dblclick', () => { DeleteCurrency(e.id) });

        const lstContinents = e.Continent.join('<br>')

        row.innerHTML = `
                <td>${e.id}</td>
                <td>${e.CurrencyName}</td>
                <td>${e.CurrencySymbol}</td>
                <td>${e.Country}</td>
                <td>${1stContinents}</td>
                <td>${e.BiggestCoin}</td>
        `
        table_body.appendChild(row)
    });

}

function ClearTable() {
    const table = document.getElementById('currency-table');
    if(!table) {
        console.error('Could not find currency table.')
        return;
    }
    table.innerHTML = `
    <thead>
        <tr>
            <th>ID</th>
            <th>CurrencyName</th>
            <th>CurrencySymbol</th>
            <th>Country</th>
            <th>Continent</th>
            <th>BiggestCoin</th>
        </tr>
    </thead>
    <tbody>

    </tbody>
    `;
}

export function DeleteCurrency(currencyId) {
    alert(`Deleting currency with ID = ${currencyId}`);
    CurrencyAPI.DeleteCurrency(currencyId);
    ClearTable();
    LoadTable(); // Reload table
}