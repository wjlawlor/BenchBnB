const table = document.querySelector('#myDynamicTable');

table.addEventListener('click', (event) => {
    console.log(event.target);
    const td = event.target;
    const tr = event.target.parentNode;
    const redirectLink = tr.getAttribute('data')

    window.location.href = redirectLink;
});
