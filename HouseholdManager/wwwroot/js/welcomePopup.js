

function dismissWelcome() {
    const welcomePopup = document.getElementById("welcomePopup");
    const dismissButton = document.getElementById("dismissButton");
    welcomePopup.classList.remove("fade-in-1s");
    welcomePopup.classList.add("fade-out-1s");
    welcomePopup.style.opacity = 0;
    dismissButton.classList.add("active");
    dismissButton.setAttribute("disabled", "true");
    setTimeout(() => {
        welcomePopup.style.display = "none";
    }, 1200);
}

window.addEventListener("load", () => {
    const welcomePopup = document.getElementById("welcomePopup");
    const dismissButton = document.getElementById("dismissButton");
    welcomePopup.classList.remove("fade-out-1s");
    welcomePopup.classList.add("fade-in-1s");
    dismissButton.removeAttribute("disabled");
    welcomePopup.style.opacity = 1;
});
