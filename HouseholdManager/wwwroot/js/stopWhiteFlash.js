//This is a fast check to prevent an irritating white flash on page load when set to dark mode
(function () {
    const userTheme = localStorage.getItem('user-theme');
    const topElement = document.documentElement;
    if (userTheme !== 'light') {
        topElement.setAttribute('data-bs-theme', userTheme);
    }
})();
