const inputField = document.getElementById('calculator-input');
const historyContainer = document.getElementById('history');
let history = JSON.parse(localStorage.getItem('calculatorHistory')) || [];

// Update history on page load
updateHistory();

// Append value to the input field
function appendValue(value) {
    inputField.value += value;
}

// Clear input field
function clearInput() {
    inputField.value = '';
}

// Calculate the expression
function calculate() {
    try {
        const result = eval(inputField.value);
        if (result !== undefined) {
            const expression = inputField.value + ' = ' + result;
            history.push(expression);
            localStorage.setItem('calculatorHistory', JSON.stringify(history));
            updateHistory();
            inputField.value = result;
        }
    } catch (error) {
        alert('Nepareiza izteiksme!');
    }
}

// Update history section
function updateHistory() {
    historyContainer.innerHTML = '';
    history.forEach((entry, index) => {
        const div = document.createElement('div');
        div.innerHTML = `
            <span>${entry}</span>
            <button onclick="deleteEntry(${index})">X</button>
        `;
        historyContainer.appendChild(div);
    });
}

// Delete single entry from history
function deleteEntry(index) {
    history.splice(index, 1);
    localStorage.setItem('calculatorHistory', JSON.stringify(history));
    updateHistory();
}

// Clear entire history
function clearHistory() {
    history = [];
    localStorage.removeItem('calculatorHistory');
    updateHistory();
}
