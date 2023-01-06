const html = document.documentElement;

function showPage() {
    document.head.style.visibility = "visible";
    document.head.style.opacity = 1;
    document.body.style.visibility = "visible";
    document.body.style.opacity = 1;
}

function getPreferredTheme() {
    const storedTheme = localStorage.getItem('user-theme');
    if (storedTheme) {
        return storedTheme;
    } else {
        return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    }
}

function setTheme(theme, stylesheet = "bootstrap5") {
    let cdnLink = document.getElementById("cssfile");
    cdnLink.href = 'https://cdn.syncfusion.com/ej2/20.4.38/' + stylesheet + '.css';
    if (theme === 'dark') {
        html.setAttribute('data-bs-theme', 'dark');
    } else {
        html.removeAttribute('data-bs-theme');
    }
}

function setDefaultTheme() {
    const pref = getPreferredTheme();
    switch (pref) {
        case 'dark':
            setTheme(pref, "bootstrap5-dark");
            break;
        default:
            setTheme(pref);
    }
}

function onThemeChange(choice) {
    document.getElementsByTagName('body')[0].style.display = 'none';
    let theme = choice.value;
    if (theme === 'bootstrap5-dark') {
        setTheme('dark', theme);
        window.localStorage.setItem('user-theme', 'dark');
    } else {
        setTheme('light', theme);
        window.localStorage.setItem('user-theme', 'light');
    }
    setTimeout(() => {
        document.getElementsByTagName('body')[0].style.display = 'block';
    }, 150);
}

window.addEventListener('DOMContentLoaded', () => {
    setDefaultTheme();
    console.log(`Theme loaded: ${getPreferredTheme()}`);
    setTimeout(() => {
        showPage();
    }, 150);
});
