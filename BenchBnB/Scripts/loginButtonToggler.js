let toggleButton = function () {
    const form = document.querySelector('#LoginForm');
    const email = document.querySelector('#Email');
    const password = document.querySelector('#Password');
    const submitButton = document.querySelector('#loginButton');

    form.addEventListener('keyup', () => {
        if (email.value === '' ||
            password.value === '')
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
