let toggleButton = function () {
    const form = document.querySelector('#AddForm');
    const name = document.querySelector('#Name');
    const seats = document.querySelector('#Seats');
    const description = document.querySelector('#Description');
    const latitude = document.querySelector('#Latitude');
    const longitude = document.querySelector('#Longitude');
    const submitButton = document.querySelector('#addBenchButton');

    form.addEventListener('keyup', () => {
        if (name.value === '' ||
            seats.value === '' ||
            description.value === '' ||
            latitude.value === '' ||
            longitude.value === '')
        {
            submitButton.disabled = true;
        }
        else
        {
            submitButton.disabled = false;
        }
    });
};

toggleButton();
