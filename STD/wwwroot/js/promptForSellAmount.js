function promptForSellAmount(initialAmount) {
    const amount = window.prompt("Wpisz ilość akcji które chcesz sprzedać (pomiędzy 1 a " + initialAmount + "):", "");
    if (amount) {
        const parsedAmount = parseInt(amount);
        if (!isNaN(parsedAmount) && parsedAmount > 0 && parsedAmount <= initialAmount) {
            return parsedAmount;
        }
    }
    return 0;
}
