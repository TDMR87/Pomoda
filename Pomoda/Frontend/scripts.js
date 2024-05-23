let lastScrollTop = 0;

window.addEventListener("scroll", function () {
    const scrollY = window.scrollY;
    const floatingSearchBar = document.getElementById("search-bar");

    if (scrollY > lastScrollTop) {
        floatingSearchBar.classList.add("scrolled-down");
    } else {
        floatingSearchBar.classList.remove("scrolled-down");
    }

    lastScrollTop = scrollY;
});

function SetModalOpen() {
    document.getElementById('htmlElement').classList.add('modal-is-opening');
    document.getElementById('htmlElement').classList.add('modal-is-open');
}

function SetModalClosed() {
    document.getElementById('htmlElement').classList.remove('modal-is-opening');
    document.getElementById('htmlElement').classList.remove('modal-is-open');
}