// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const storedTheme = localStorage.getItem('theme');
const html = document.documentElement;

function getPreferredTheme() {
    if (storedTheme) {
        return storedTheme;
    } else {
        return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    }
}

function setTheme(theme) {
    if (theme === 'dark') {
        html.setAttribute('data-bs-theme', 'dark');
    } else {
        html.removeAttribute('data-bs-theme');
    }
}

function setDefaultTheme() {
    setTheme(getPreferredTheme);
}

window.addEventListener('DOMContentLoaded', () => {
    setDefaultTheme();
    console.log(`Theme loaded (${getPreferredTheme()})`);
});