let toggleButton = function () {
    const form = document.querySelector('#RegisterForm');
    const firstName = document.querySelector('#FirstName');
    const lastName = document.querySelector('#LastName');
    const email = document.querySelector('#Email');
    const password = document.querySelector('#Password');
    const submitButton = document.querySelector('#registerButton');

    form.addEventListener('keyup', () => {
        if (firstName.value === '' ||
            lastName.value === '' ||
            email.value === '' ||
            password.value === '')
        {
            submitButton.disabled = true;
        }
        else {
            submitButton.disabled = false;
        }
    });
};

toggleButton();
