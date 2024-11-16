var map, branchPlacemark;
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms))
}
async function initYandex(mapId, latitude, longitude, isDelivery, dotNetHelper, shouldRender) {
    if (shouldRender) {
        ymaps.ready(function () {
            map = new ymaps.Map(mapId, {
                center: [latitude, longitude],
                zoom: 18
            });
            if (isDelivery == false) {
                branchPlacemark = new ymaps.Placemark([latitude, longitude], {
                }, {
                    preset: 'islands#icon',
                    iconColor: 'red'
                });
                map.geoObjects.add(branchPlacemark);
            }
            if (isDelivery) {
                branchPlacemark = new ymaps.Placemark([latitude, longitude], {
                    balloonContent: 'Your location'
                }, {
                    preset: 'islands#icon',
                    iconColor: 'red'
                });
                map.geoObjects.add(branchPlacemark);
                map.events.add('click', function (e) {
                    var coords = e.get('coords');
                    branchPlacemark.geometry.setCoordinates(coords)
                    branchPlacemark.coords = coords;
                    //dotNetHelper.InvokeMethodAsync('getCoords', coords.latitude, coords.longitude);
                    var lat = coords[0];
                    var longtu = coords[1];
                    dotNetHelper.invokeMethodAsync('GetCoordinates', lat, longtu);
                    //dotNetHelper.invokeMethodAsync('getCoords');
                });
            }
        });
    }
    else {
        if (!isDelivery) {

            if (map != 'undefined' && map != null) {
                var zoomOut = new ymaps.map.action.Single({
                    //center: [latitude, longitude],
                    zoom: 15,
                    duration: 1500,
                    timingFunction: "ease-in"
                });
                map.action.execute(zoomOut);
            }
            sleep(2000).then(() => {

                var myAction = new ymaps.map.action.Single({
                    center: [latitude, longitude],
                    zoom: 17,
                    duration: 1500,
                    timingFunction: "ease-in"
                });
                if (branchPlacemark != 'undefined' && branchPlacemark != null) {

                    branchPlacemark.geometry.setCoordinates([latitude, longitude])
                    branchPlacemark.coords = [latitude, longitude];
                    map.action.execute(myAction);
                    console.log(latitude, longitude);
                }
                console.log(map);
            })
        }
        //await delay(1000);
    }
};
//function changeLocation(latitude, longitude) {
//    map.center = [latitude, longitude];
//    map.zoom = 7;
//    branchPlacemark.geometry.setCoordinates([latitude, longitude])
//    //branchPlacemark.coords = [latitude, longitude];
//}