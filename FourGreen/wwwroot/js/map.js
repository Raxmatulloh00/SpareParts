// wwwroot/map.js
function initZoneMap(mapId) {
    ymaps.ready(() => {
        const map = new ymaps.Map(mapId, {
            center: [41.30694158608315, 69.2909497353349], // Initial map center
            zoom: 18
        });

        const drawnPoints = []; // Array to store clicked points
        let fillShape = null; // Reference to the filled shape polygon

        map.events.add('click', (e) => {
            const coords = e.get('coords');
            drawnPoints.push(coords);

            // Draw a draggable point on the map
            const point = new ymaps.Placemark(coords, {}, {
                draggable: true // Enable dragging for the point
            });
            point.events.add('dragend', (e) => {
                // Update the drawn points array when the point is dragged
                const newPosition = e.get('target').geometry.getCoordinates();
                const index = drawnPoints.indexOf(coords);
                if (index !== -1) {
                    drawnPoints[index] = newPosition;
                    redrawPolygon();
                }
            });
            map.geoObjects.add(point);

            // Draw lines between clicked points
            if (drawnPoints.length > 1) {
                const line = new ymaps.Polyline([drawnPoints[drawnPoints.length - 2], coords], {}, {
                    strokeColor: "#0000FF", // Line color
                    strokeWidth: 2 // Line width
                });
                map.geoObjects.add(line);
            }

            // Remove existing filled shape polygon
            if (fillShape) {
                map.geoObjects.remove(fillShape);
            }

            // Create a polygon from the drawn points
            redrawPolygon();
        });

        function redrawPolygon() {
            // Remove existing filled shape polygon
            if (fillShape) {
                map.geoObjects.remove(fillShape);
            }

            // Create a polygon from the drawn points
            fillShape = new ymaps.Polygon([drawnPoints], {
                fillColor: '#FF0000', // Fill color (red)
                fillOpacity: 0.6 // Opacity (0.6)
            });
            map.geoObjects.add(fillShape);
        }
    });
}
