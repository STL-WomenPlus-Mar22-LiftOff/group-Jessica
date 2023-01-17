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

//stylesheet is used by Syncfusion elements
function setTheme(theme = "light", stylesheet = "bootstrap5") {
    let cdnLink = document.getElementById("cssfile");
    const deepblue = document.getElementById("deepblue-css"); //TODO: rework this when more themes are added
    //const bootstrap = document.getElementById("bootstrap");
    cdnLink.href = 'https://cdn.syncfusion.com/ej2/20.4.38/' + stylesheet + '.css';
    switch (theme) {
        case "deepblue":
            html.setAttribute('data-bs-theme', 'deepblue');
            deepblue.disabled = false;
            document.body.style.removeProperty("style");
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
            break;
    }
}

function onThemeChange(choice) {
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
}

window.addEventListener('DOMContentLoaded', () => {
    setDefaultTheme();
    console.log(`Theme loaded: ${getPreferredTheme()}`);
    showPage();
});
