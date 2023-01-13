(function () {
    const userTheme = localStorage.getItem('user-theme');
    const topElement = document.documentElement;
    if (userTheme !== 'light') {
        topElement.setAttribute('data-bs-theme', userTheme);
    }
})();