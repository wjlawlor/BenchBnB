let toggleButton = function () {
    const form = document.querySelector('#AddReviewForm');
    const rating = document.querySelector('#Rating');
    const description = document.querySelector('#Description');
    const submitButton = document.querySelector('#addReviewButton');

    form.addEventListener('keyup', () => {
        if (rating.value === '' ||
            description.value === '') {
            submitButton.disabled = true;
        }
        else {
            submitButton.disabled = false;
        }
    });
};

toggleButton();
