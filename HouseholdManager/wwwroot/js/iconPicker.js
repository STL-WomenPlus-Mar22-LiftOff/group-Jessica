const iconToggle = document.getElementById("iconSelectButton");
const iconMenu = document.getElementById("iconMenu");
const iconSearchBar = document.getElementById("iconSearch");
const iconFormField = document.getElementById("iconInput");
const iconDisplay = document.getElementById("iconDisplay");
const iconRandom = document.getElementById("iconRandomizer");
const phText = iconSearchBar.getAttribute("placeholder");

function selectIcon({ mouseoverText, character, options = "" }) {
    if (!options.includes("keepMenuOpen")) {
        iconMenu.style.visibility = "hidden";
        iconSearchBar.setAttribute("placeholder", phText);
        iconSearchBar.value = "";
    }
    iconFormField.setAttribute("value", character);
    iconDisplay.innerText = character;
    iconDisplay.title = mouseoverText;
}

function searchIcons(term) {
    for (const listItem of document.querySelectorAll("li[title]")) {
        if (term === "" || listItem.getAttribute("title").includes(term.toLowerCase())) {
            listItem.style.display = "flex";
        } else {
            listItem.style.display = "none";
        }
    }
}

iconRandom.addEventListener("click", () => {
    try {
        //iconGenerator relies on ASP.NET HTML helper and must be defined in the view
        iconGenerator.next()
            .then((res) => {
                selectIcon({
                    mouseoverText: res.value["slug"],
                    character: res.value["character"],
                    options: "keepMenuOpen"
                });
                iconSearchBar.setAttribute("placeholder", res.value["slug"]);
            });
    } catch (error) {
        console.error(error);
    }
});

iconToggle.addEventListener("click", () => {
    switch (window.getComputedStyle(iconMenu).visibility) {
        case "visible":
            iconMenu.style.visibility = "hidden";
            iconSearchBar.setAttribute("placeholder", phText);
            break;
        default:
            iconMenu.style.visibility = "visible";
            break;
    }
});

iconSearchBar.addEventListener("keyup", e => {
    iconSearchBar.setAttribute("placeholder", phText);
    searchIcons(e.target.value);
});
