(async () => {

    const getBenchesUrl = 'http://localhost:52169/api/benches';

    async function getListOfBenches() {
        return await fetch(getBenchesUrl);
    };

    const response = await getListOfBenches();
    const benchInfo = await response.json();

    const inputField = document.querySelector('#SeatFilter')
    const minSeats = document.querySelector('#minSeats');
    const maxSeats = document.querySelector('#maxSeats');

    // Filter Bench List
    let filterMinMaxSeats = function () {
        inputField.addEventListener('change', () => {
            let filteredBenches = [];
            if (minSeats.value === '' && maxSeats.value === ''){
                benchInfo.forEach(bench => {
                    filteredBenches.push(bench);
                });
            }
            if (minSeats.value !== '' && maxSeats.value === ''){
                benchInfo.forEach(bench => {
                    if (bench.Seats >= parseInt(minSeats.value,10)) {
                        filteredBenches.push(bench);
                    }
                });
            }
            if (minSeats.value === '' && maxSeats.value !== ''){          
                benchInfo.forEach(bench => {
                    if (bench.Seats <= parseInt(maxSeats.value,10)) {
                        filteredBenches.push(bench);
                    }
                });
            }
            if (minSeats.value !== '' && maxSeats.value !== ''){ 
                benchInfo.forEach(bench => {
                    if (bench.Seats >= parseInt(minSeats.value,10) && bench.Seats <= parseInt(maxSeats.value,10)) {
                        filteredBenches.push(bench);
                    }
                });
            }
            createTable(filteredBenches);
            generateMap(filteredBenches);
        });
    };

    // Build-A-Table Workshop
    let createTable = function (benchList) {
        let HTML = '<table id="table" class="table table-hover table-scroll">';
        HTML += '<thead class="thead-dark">';
        HTML += '<tr>';
        HTML += '<th>Bench</th>';
        HTML += '<th>Seats</th>';
        HTML += '<th>User</th>';
        HTML += '<th>Avg Rating</th>';
        HTML += '<th>Description</th>';
        HTML += '</tr>';
        HTML += '</thead>';
        HTML += '<tbody>';
        benchList.forEach( bench => {
            HTML += '<tr ' + 'data="Bench/View/' + bench.Id + '">';
            HTML += '<td>' + bench.Name + '</td>';
            HTML += '<td>' + bench.Seats + '</td>';
            HTML += '<td>' + bench.User.FirstName + ' ' +bench.User.LastName[0] + '.</td>';
            if (bench.AverageRating === null)
            {
                HTML += '<td>No rating.</td>';
            }
            else
            {
                HTML += '<td>' + bench.AverageRating + '</td>';
            }

            const array = bench.Description.split(" ");           
            HTML += '<td>';
            if (array.length <= 10)
            {
                HTML += bench.Description;
            }
            else 
            {
                for(let i = 0; i < 10 ; i++)
                {
                    HTML += array[i] + ' ';
                }
                HTML += '...';
            }
            HTML+= '</td>';
            HTML += '</tr>';
        });
        HTML += '</tbody>';
        HTML += '</table>';

        const myTableDiv = document.getElementById("myDynamicTable");
        myTableDiv.innerHTML = HTML;
    };

    const generateMap = function (benchList) {
        var map = new ol.Map({
            target: 'map',
            layers: [
                new ol.layer.Tile({
                    source: new ol.source.OSM()
                })
            ],
            view: new ol.View({
                center: ol.proj.fromLonLat([-73.145, 40.7891]),
                zoom: 8
            })
        });

        var vectorSource = new ol.source.Vector({});

        const markerArray = [];
        benchList.forEach(bench => {
            var marker = new ol.Feature({
                geometry: new ol.geom.Point(
                    ol.proj.fromLonLat([bench.Longitude, bench.Latitude])
                )
            });
            vectorSource.addFeature(marker);
        });

        var markerVectorLayer = new ol.layer.Vector({
            source: vectorSource
        });
        map.addLayer(markerVectorLayer);

        map.on('singleclick', async function (event) {
            event.coordinate = ol.proj.transform(event.coordinate, 'EPSG:3857', 'EPSG:4326');
            latitude = event.coordinate[1];
            longitude = event.coordinate[0];

            let alreadyExists = false;

            benchInfo.forEach(bench => {
                if (Math.abs(bench.Latitude - latitude) < 0.00025 && Math.abs(bench.Longitude - longitude) < 0.00025){
                    window.location.href = "Bench/View/" + bench.Id;
                    alreadyExists = true;
                }
            });
            if (!alreadyExists)
            {
                window.location.href = "Bench/Add?Lat=" + latitude + "&Lon=" + longitude;
            }
        });
    }

    // Default Full Table
    createTable(benchInfo);

    filterMinMaxSeats();

    generateMap(benchInfo);
})();
