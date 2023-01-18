const html = document.documentElement;

function showPage() {
    document.head.style.visibility = "visible";
    document.head.style.opacity = 1;
    document.body.style.visibility = "visible";
    document.body.style.opacity = 1;
}

function hidePage() {
    document.head.style.visibility = "hidden";
    document.head.style.opacity = 0;
    document.body.style.visibility = "hidden";
    document.body.style.opacity = 0;
}

function getPreferredTheme() {
    const storedTheme = localStorage.getItem('user-theme');
    if (storedTheme) {
        return storedTheme;
    } else {
        return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    }
}

//stylesheet is used by Syncfusion elements
function setTheme(theme, stylesheet = "bootstrap5") {
    html.setAttribute('data-bs-theme', theme);
    let cdnLink = document.getElementById("cssfile");
    cdnLink.href = 'https://cdn.syncfusion.com/ej2/20.4.38/' + stylesheet + '.css';
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
            break;
    }
}

function onThemeChange(choice) {
    const theme = choice.value;
    const previous = html.getAttribute('data-bs-theme');
    switch (theme) {
        case 'dark':
            setTheme('dark', 'bootstrap5-dark');
            window.localStorage.setItem('user-theme', 'dark');
            break;
        case 'deepblue':
            setTheme('deepblue', 'bootstrap5-dark');
            window.localStorage.setItem('user-theme', 'deepblue');
            break;
        default:
            setTheme('light', 'bootstrap5');
            window.localStorage.setItem('user-theme', 'light');
            break;
    }
    if (theme !== previous) {
        hidePage();
        location.reload(true);
    }
}

window.addEventListener('DOMContentLoaded', () => {
    setDefaultTheme();
    console.log(`Theme loaded: ${getPreferredTheme()}`);
});

window.addEventListener('load', () => {
    showPage();
});
