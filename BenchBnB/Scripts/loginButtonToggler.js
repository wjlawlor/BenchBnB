let toggleButton = function () {
    const email = document.querySelector('#Email');
    const password = document.querySelector('#Password');
    const loginButton = document.querySelector('#loginButton');

    email.addEventListener('keyup', () => {
        if (email.value === '' || password.value === '') {
            loginButton.disabled = true;
        }
        else {
            loginButton.disabled = false
        }
    });
    password.addEventListener('keyup', () => {
        if (email.value === '' || password.value === '') {
            loginButton.disabled = true;
        }
        else {
            loginButton.disabled = false
        }
    });
};

toggleButton();
