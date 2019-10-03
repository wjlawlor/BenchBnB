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

    debugger;
    // var marker = new ol.Feature({
    //     geometry: new ol.geom.Point(
    //       ol.proj.fromLonLat([-74.006, 40.7127])
    //     )
    // });

    var vectorSource = new ol.source.Vector({});

    const markerArray = [];
    benchInfo.forEach(bench => {
        var marker = new ol.Feature({
            geometry: new ol.geom.Point(
                ol.proj.fromLonLat([bench.Longitude, bench.Latitude])
            )
        });
        console.log(bench)
        vectorSource.addFeature(marker);
        //markerArray.push(marker);
    });

    //var vectorSource = new ol.source.Vector({
    //    features: markerArray
    //});

    var markerVectorLayer = new ol.layer.Vector({
        source: vectorSource
    });
    map.addLayer(markerVectorLayer);

})();
