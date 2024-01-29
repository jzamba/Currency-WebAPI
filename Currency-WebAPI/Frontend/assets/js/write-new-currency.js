// JavaScript file that implement logic for write-new-currency.html

import { CurrencyAPI } from "/assets/js/currencyAPI.js"

window.onload = (e) => {
    document.getElementById('home-button')?.addEventListener('click', () => { window.location.href = '/index.html' });
    document.getElementById('clear-all-fields-button')?.addEventListener('click', OnClearButtonClick);
    document.getElementById('send-currency-button')?.addEventListener('click', OnSendCurrencyButonClick);
}

function OnClearButtonClick() {
    document.getElementById('currencyname').value = '';
    document.getElementById('currencysymbol').value = '';
    document.getElementById('country').value = '';
    document.getElementById('continent').value = '';
}

async function OnSendCurrencyButonClick() {
    let currency = {};

    const currencyname = document.getElementById('currencyname');
    if(!currencyname) {
        alert('currencyname field is empty!')
        return;
    }
    currency.currencyname = currencyname.value;

    const currencysymbol = document.getElementById('currencysymbol');
    if(!currencysymbol) {
        alert('Receiver field is empty!')
        return;
    }

    currency.currencysymbol = currencysymbol.value.split(';');

    const country = document.getElementById('country');
    if(!country) {
        alert('country field is empty!')
        return;
    }
    currency.country = country.value;

    // continent can be empty
    const continent = document.getElementById('country');
    if(continent) {
        currency.continent = continent.value;
    }
    
    const success = await CurrencyAPI.CreateNewCurrency(currency);
    if(success) {
        alert('Currency successfully sent')
        OnClearButtonClick();
    }
    
}