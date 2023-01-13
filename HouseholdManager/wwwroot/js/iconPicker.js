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

//this generator relies on an iconCollection variable that has to be defined by html helper in the view
async function* getRandomIcon() {
    let i;
    while (true) {
        i = Math.floor(Math.random() * iconCollection.length);
        yield await Promise.resolve(iconCollection[i]);
    }
}

iconRandom.addEventListener("click", () => {
    try {
        const generator = getRandomIcon();
        generator.next()
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
    const term = e.target.value;
    for (const listItem of document.querySelectorAll("li[title]")) {
        if (listItem.getAttribute("title").includes(term.toLowerCase())) {
            listItem.style.display = "flex";
        } else {
            listItem.style.display = "none";
        }
    }
});