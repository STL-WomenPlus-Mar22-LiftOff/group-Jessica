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
    const deepblue = document.getElementById("deepblue-css");
    cdnLink.href = 'https://cdn.syncfusion.com/ej2/20.4.38/' + stylesheet + '.css';
    switch (theme) {
        case "deepblue":
            html.setAttribute('data-bs-theme', 'deepblue');
            deepblue.disabled = false;
            return;
        case "dark":
            html.setAttribute('data-bs-theme', 'dark');
            break;
        default:
            html.removeAttribute('data-bs-theme');
            break;
    }
    deepblue.disabled = true;
}

function setDefaultTheme() {
    const pref = getPreferredTheme();
    switch (pref) {
        case 'dark':
            setTheme(pref, "bootstrap5-dark");
            break;
        case "deepblue":
            setTheme(pref, "bootstrap5-dark");
            break;
        default:
            setTheme(pref);
    }
}

function onThemeChange(choice) {
    document.getElementsByTagName('body')[0].style.display = 'none';
    let theme = choice.value;
    switch (theme) {
        case 'bootstrap5-dark':
            setTheme('dark', theme);
            window.localStorage.setItem('user-theme', 'dark');
            break;
        case 'bootstrap5-deepblue-custom':
            setTheme('deepblue', 'bootstrap5-dark');
            window.localStorage.setItem('user-theme', 'deepblue');
            break;
        default:
            setTheme('light', theme);
            window.localStorage.setItem('user-theme', 'light');
            break;
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
