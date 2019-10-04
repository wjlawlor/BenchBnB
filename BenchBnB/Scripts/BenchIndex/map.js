(async () => {

    const getBenchesUrl = 'http://localhost:52169/api/benches';

    async function getListOfBenches() {
        return await fetch(getBenchesUrl);
    };

    const response = await getListOfBenches();
    const benchInfo = await response.json();

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
    benchInfo.forEach(bench => {
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
})();
