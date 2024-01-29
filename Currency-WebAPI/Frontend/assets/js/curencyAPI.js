const Base_URL = 'http://localhost:5223'

class _CurrencyAPI { 

    async GetAllCurrencies() {
        const URL = `${Base_URL}/api/Currency`;
        const response = await fetch(URL, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });

        if(!response.ok) {
            console.error('Could not get currencies from the API!')
            return null;
        }

        return response.json();
    }

    // Returns true if successful and false if failed
    async CreateNewCurrency(currency) {
        const URL = `${Base_URL}/api/Currency`;
        const response = await fetch(URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(currency)
        });

        if(!response.ok) {
            console.error('Could not create new currency.')
            if(response.status === 400) { /* Bad Request */
                alert(await response.text())
            }
            return false;
        }

        return true;
    }

    async DeleteCurrency(currencyId) {
        const URL = `${Base_URL}/api/Currency/${currencyId}`;
        const response = await fetch(URL, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json"
            }
        });

        if(!response.ok) {
            console.error(`Could not delete currency with id = ${currencyId}.`)
            if(response.status === 400) { /* Bad Request */
                alert(await response.text())
            }
        }
    }

}

export const CurrencyAPI = new _CurrencyAPI();