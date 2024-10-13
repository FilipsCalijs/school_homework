const toggleButton = document.getElementById('darkModeToggle');
const hamburger = document.getElementById("hamburger");
const navList = document.querySelector(".nav-list");
const modal = document.getElementById("modal");
const modalBtn = document.getElementById("modalBtn");
const closeBtn = document.querySelector(".close");

function toggleDarkMode() {
    if (toggleButton.textContent.includes('Dark mode')) {
        toggleButton.innerHTML = '<i class="fas fa-home"></i> Light mode';
        document.body.classList.add('dark-mode', 'dark-theme'); 
    } else {
        toggleButton.innerHTML = '<i class="fas fa-home"></i> Dark mode';
        document.body.classList.remove('dark-mode', 'dark-theme'); 
    }
}

function toggleMenu() {
    navList.classList.toggle("active");
    hamburger.classList.toggle("open");
}

function handleResize() {
    if (window.innerWidth > 770) {
        navList.classList.remove("active");
        hamburger.classList.remove("open");
    }
}

function openModal(event) {
    event.preventDefault();
    modal.style.display = "block";
    event.stopPropagation();
}

function closeModal() {
    modal.style.display = "none";
}

function outsideClick(event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
}

toggleButton.addEventListener('click', toggleDarkMode);
hamburger.addEventListener("click", toggleMenu);
window.addEventListener("resize", handleResize);
modalBtn.addEventListener("click", openModal);
closeBtn.addEventListener("click", closeModal);
window.addEventListener("click", outsideClick);
