

const dirtSliders = document.getElementsByClassName("dirtometer-input");

function dirtometer() { 
    if (!dirtSliders) {
        return;
    } else {
        const kvpData = {};
        for (const slider of dirtSliders) {
            if (slider.attributes["data-updated"].value === "true") {
                kvpData[slider.attributes["data-index"].value] = slider.value;
            }
        }
        $.ajax({
            type: 'POST',
            url: '/Room/DirtHandler',
            data: JSON.stringify(kvpData),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: (response) => {
                console.log(response);
            },
            error: (response) => {
                console.error('Error with dirtometer POST request.');
                console.error(response);
            }
        });

    }
};

function flagForUpdate(elem) {
    if (elem.hasAttribute("data-updated") && elem.attributes["data-updated"].value !== "true") {
        elem.attributes["data-updated"].value = "true";
    }
}
