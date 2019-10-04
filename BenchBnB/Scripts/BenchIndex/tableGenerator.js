(async () => {

    const getBenchesUrl = 'http://localhost:52169/api/benches';

    async function getListOfBenches() {
        return await fetch(getBenchesUrl);
    };

    const response = await getListOfBenches();
    const benchInfo = await response.json();
    console.log(benchInfo)

    const inputField = document.querySelector('#SeatFilter')
    const minSeats = document.querySelector('#minSeats');
    const maxSeats = document.querySelector('#maxSeats');

    // Filter Bench List
    let filterMinMaxSeats = function () {
        inputField.addEventListener('change', () => {
            console.log("change event");
            let filteredBenches = [];
            if (minSeats.value === '' && maxSeats.value === ''){
                console.log("no values!")
                benchInfo.forEach(bench => {
                    filteredBenches.push(bench);
                });
            }
            if (minSeats.value !== '' && maxSeats.value === ''){
                console.log("min value!");
                benchInfo.forEach(bench => {
                    if (bench.Seats >= minSeats.value) {
                        filteredBenches.push(bench);
                    }
                });
            }
            if (minSeats.value === '' && maxSeats.value !== ''){          
                console.log("max value!");
                benchInfo.forEach(bench => {
                    if (bench.Seats <= maxSeats.value) {
                        filteredBenches.push(bench);
                    }
                });
            }
            if (minSeats.value !== '' && maxSeats.value !== ''){ 
                console.log("both values!");
                benchInfo.forEach(bench => {
                    if (bench.Seats >= minSeats.value && bench.Seats <= maxSeats.value) {
                        filteredBenches.push(bench);
                    }
                });
            }
            createTable(filteredBenches);
        });
    };

    // Build-A-Table Workshop
    let createTable = function (benchList) {
        let HTML = '<table id="table" class="table table-hover table-scroll">';
        HTML += '<thead class="thead-dark">';
        HTML += '<tr>';
        HTML += '<th>Bench</th>';
        HTML += '<th>Description</th>';
        HTML += '</tr>';
        HTML += '</thead>';
        HTML += '<tbody>';
        benchList.forEach( bench => {
            HTML += '<tr ' + 'data="Bench/View/' + bench.Id + '">';
            HTML += '<td>' + bench.Name + '</td>';
            HTML += '<td>' + bench.Description + '</td>';
            HTML += '</tr>';
        });
        HTML += '</tbody>';
        HTML += '</table>';

        const myTableDiv = document.getElementById("myDynamicTable");
        myTableDiv.innerHTML = HTML;
    };

    // Default Full Table
    createTable(benchInfo);

    filterMinMaxSeats();
})();
