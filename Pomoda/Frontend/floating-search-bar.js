let lastScrollTop = 0;

window.addEventListener("scroll", function () {
    const scrollY = window.scrollY;
    const floatingSearchBar = document.getElementById("floating-search-bar");

    if (scrollY > lastScrollTop) {
        floatingSearchBar.classList.add("scrolled-down");
    } else {
        floatingSearchBar.classList.remove("scrolled-down");
    }

    lastScrollTop = scrollY;
});