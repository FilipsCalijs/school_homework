// Найти кнопку переключения
const darkModeToggle = document.getElementById('darkModeToggle');

// Обработчик события нажатия
darkModeToggle.addEventListener('click', function(e) {
    e.preventDefault(); // предотвращаем переход по ссылке

    // Переключаем класс темного режима на body и nav
    document.body.classList.toggle('dark-mode');
    document.querySelector('nav').classList.toggle('dark-mode');
});
console.log("12");