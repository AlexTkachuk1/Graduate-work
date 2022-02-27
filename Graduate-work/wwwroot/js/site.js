$(document).ready(function () {
    //const buttonElem = document.querySelector(".card");
    //const optionElem = document.querySelector(".card-option");


    //buttonElem.addEventListener("click", () => {
    //    optionElem.classList.toggle("hidden");
    //});
    var Fetch = (async function () {
        var value = null;
        var name = $(".image-block").prop('id');
        const requestURL = "https://localhost:5001/Home/SliderData?Name=" + name;

        var response = await fetch(requestURL);

        if (response.ok) { // если HTTP-статус в диапазоне 200-299
            // получаем тело ответа (см. про этот метод ниже)
            value = await response.json();
            CreateSliderModule.Start(value);
        } else {
            alert("Ошибка HTTP: " + response.status);
        }
    })();
});
