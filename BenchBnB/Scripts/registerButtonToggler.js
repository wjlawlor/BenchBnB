let toggleButton = function () {
    const firstName = document.querySelector('#FirstName');
    const lastName = document.querySelector('#LastName');
    const email = document.querySelector('#Email');
    const password = document.querySelector('#Password');
    const loginButton = document.querySelector('#registerButton');

    firstName.addEventListener('keyup', () => {
        if (firstName.value === '' || lastName.value === '' || email.value === '' || password.value === '') {
            loginButton.disabled = true;
        }
        else {
            loginButton.disabled = false
        }
    });
    lastName.addEventListener('keyup', () => {
        if (firstName.value === '' || lastName.value === '' || email.value === '' || password.value === '') {
            loginButton.disabled = true;
        }
        else {
            loginButton.disabled = false
        }
    });
    email.addEventListener('keyup', () => {
        if (firstName.value === '' || lastName.value === '' || email.value === '' || password.value === '') {
            loginButton.disabled = true;
        }
        else {
            loginButton.disabled = false
        }
    });
    password.addEventListener('keyup', () => {
        if (firstName.value === '' || lastName.value === '' || email.value === '' || password.value === '') {
            loginButton.disabled = true;
        }
        else {
            loginButton.disabled = false
        }
    });
};

toggleButton();
