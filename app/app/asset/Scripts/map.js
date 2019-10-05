var map;

var flightPath;
var polyCoordinates = [{lat: 0, lng: 0}];

var markers = [];

var data;
var markup;
var markup1;

var name;
var code;

var markers_length;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 3,
        center: {lat:38.770662, lng: -9.173422},
        mapTypeId: 'terrain'
    });
    flightPath = initFlightPath(polyCoordinates);
    flightPath.setMap(map);
}

function map_routes() {
    post("/home/GetFlightsInfoTrack", {ident: data}).then(function (responce) {
        if (responce.status === 1) {
            polyCoordinates = route_mapper(responce.data.Coordinates.tracks);
            flightPath = initFlightPath(polyCoordinates);
            flightPath.setMap(map);
        } else {
            console.log("Can't load routes");
        }
    });
}

function route_mapper(roadArray) {
    var arr = [];
    for (var i = 0; i < roadArray.length; i++) {
        arr.push(
            {
                lat: roadArray[i].latitude,
                lng: roadArray[i].longitude
            });
    }
    return arr;
}

function initFlightPath(coordinates) {
    return new google.maps.Polyline({
        path: coordinates,
        // geodesic: true,
        strokeColor: '#FF0000',
        strokeOpacity: 1.0,
        strokeWeight: 2
    });
}

function get_coordinates() {
    get("/home/GetFlightsCoordinate").then(function (responce) {
        markers_length = responce.data.FlightInfoVM.length;
        // $(".unsubscribe_for_race").css("display", "none");
        if (responce.status === 1) {
            for (var i = 0; i <  markers_length; i++) {
                markers[i] = marker_creator(responce.data.FlightInfoVM[i]);
            }
            if(responce.data.Email !== 'Error'){
                $(".user_email").text(responce.data.Email);
           }
        }
        else {
            console.log("Can`t load coordinates");
        }
    });
}

var click = 0;
var click1 = 0;
var search_race;
var check_race;
var error_responce;
var identic =0;
var check = 0;

function marker_listener(marker) {
    google.maps.event.addListener(marker, 'click', function () {

        $(".container1").removeClass("open-sidebar");
        $(".container").removeClass("open-sidebar");
        $(".container2").removeClass("open-sidebar");
        $(".click_favorite").removeClass("open-sidebar");
        $(".subscribes_popup").removeClass("open-sidebar");

        data = marker.get("id");
        code = marker.get("code");

        $(".unsubscribe_for_race").css("display", "none");
        $(".subscribe_for_race").css("display", "none");
        get("/home/GetSubscribedFlights").then(function (responce) {
            markers_length = responce.data.length;
            if(responce.data === "Error" ){
                $(".subscribe_for_race").css("display", "block");
            }
            if (responce.status === 1) {
                for (var i = 0; i < responce.data.length; i++) {
                    if (responce.data[i] === data) {
                        identic = 1;
                        $(".subscribe_for_race").css("display", "none");
                        $(".unsubscribe_for_race").css("display", "block");
                        break;
                    }
                }

                if (identic !== 1) {
                    $(".subscribe_for_race").css("display", "block");
                    $(".unsubscribe_for_race").css("display", "none");
                }

                identic =0;
                // if($(markup).hasClass("time")){
                //     $(".subscribe_for_race").css("display", "none");
                //     $(".unsubscribe_for_race").css("display", "none");
                //     $(".name").css("display", "none");
                //     $(".container1").toggleClass("open-sidebar");
                // }
            }
        });

        map_routes();

        post("/home/GetFlightsInfoStatus", {ident: data}).then(function (responce) {
            if (responce.status === 1) {
                click++;
                $(".name").css("display", "block");
                //$(".subscribe_for_race").css("display", "block");
                $(".not_found_race").css("display", "none");
                markup = responce.data;
                if (click > 1) {
                    $(".no_result").remove();
                }

                $(markup).insertAfter($(".close"));

                    $(".container1").toggleClass("open-sidebar");
            }
        });
        // map_routes();
    });



}

function marker_creator(coordinates) {
    var new_marker = new google.maps.Marker({
        draggable: false,
        // animation: google.maps.Animation.DROP,
        position: {lat: 0, lng: 0},
        map: map,
        icon: "/asset/Content/icons/png/icons8-Аэропорт-25.png"
    });

    var set_latlng_for_m = new google.maps.LatLng(
        coordinates.Latitude,
        coordinates.Longitude);

    new_marker.setPosition(set_latlng_for_m);
    new_marker.setMap(map);
    new_marker.set("id", coordinates.FlightId);
    // new_marker.set("name", coordinates.Airline.Name);
    new_marker.set("code", coordinates.Airline);

    marker_listener(new_marker);

    return new_marker;
}