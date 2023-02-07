
function dirtometer() { 
    const dirtSliders = document.getElementsByClassName("dirtometer-input");
    if (!dirtSliders) {
        return;
    } else {
        const kvpData = {};
        const arr = [];
        for (const slider of dirtSliders) {
            kvpData[slider.attributes["data-index"].value] = slider.value;
        }
        for (const prop in kvpData) {
            if (kvpData.hasOwnProperty(prop)) {
                arr.push({ Key: prop, Value: kvpData[prop] });
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
