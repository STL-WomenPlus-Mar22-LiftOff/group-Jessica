//This is a fast check to prevent an irritating white flash on
//page load when set to any theme other than light

(function () {
    const userTheme = localStorage.getItem('user-theme');
    const topElement = document.documentElement;
    if (userTheme !== 'light') {
        topElement.setAttribute('data-bs-theme', userTheme);
        switch (userTheme) {
            //This is really messy, but it's the only thing I've found that consistently works
            case "deepblue":
                document.body.style.setProperty('background-color', '#001526');
                break;
        }
    }
})();
