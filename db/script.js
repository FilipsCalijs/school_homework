document.addEventListener("DOMContentLoaded", function () {
    const firstName = localStorage.getItem('userFirstName');
    const lastName = localStorage.getItem('userLastName');

    if (firstName && lastName) {
        document.getElementById('userName').innerText = `${firstName} ${lastName}`;
    }
});