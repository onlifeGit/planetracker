function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 4,
        center: {lat: 48, lng: 32},
        mapTypeId: 'terrain'
    });

    var flightPlanCoordinates = [
        {lat: 37.772, lng: -122.214},
        {lat: 21.291, lng: -157.821},
        {lat: -18.142, lng: 178.431},
        {lat: -27.467, lng: 153.027}
    ];

    var flightPath = new google.maps.Polyline({
        path: flightPlanCoordinates,
        // geodesic: true,
        strokeColor: '#FF0000',
        strokeOpacity: 1.0,
        strokeWeight: 2
    });

    var marker = new google.maps.Marker({
        draggable: false,
        // animation: google.maps.Animation.DROP,
        position: {lat: 50.26617532, lng: 32.71933818},
        map: map,
        icon: "asset/Content/icons/png/icons8-Аэропорт-25.png"
    });

    flightPath.setMap(map);
    marker.setMap(map);
};

$(document).ready(function () {
    $('.modal_close,.overlay,.btn_autorise_cancel').click(function () {
        $('.modal_autorization')
            .animate({opacity: 0, top: '45%'}, 200,  // уменьшаем прозрачность
                function () { // пoсле aнимaции
                    $(this).css('display', 'none'); // скрываем окно
                    $('.overlay').fadeOut(400); // скрывaем пoдлoжку
                }
            );
    });

    $('.modal_4').click(function (event) {
        event.preventDefault();
        $('.modal_autorization').hide();
        $('.overlay').fadeIn(400, // анимируем показ обложки
            function () { // далее показываем мод. окно
                $('.modal_remember_psw')
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
            });
    });

    $('.modal_close,.overlay').click(function () {
        $('.modal_remember_psw')
            .animate({opacity: 0, top: '45%'}, 200,  // уменьшаем прозрачность
                function () { // пoсле aнимaции
                    $(this).css('display', 'none'); // скрываем окно
                    $('.overlay').fadeOut(400); // скрывaем пoдлoжку
                }
            );
    });

    $('.open_about').click(function (event) {
        // event.preventDefault();
        $('.overlay').fadeIn(400, // анимируем показ обложки
            function () { // далее показываем мод. окно
                $('.modal_about')
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
                $(".container").css('z-index', '1');
            });
    });

    $('.modal_close,.overlay,.btn_about_ok').click(function () {
        $('.modal_about')
            .animate({opacity: 0, top: '45%'}, 200,  // уменьшаем прозрачность
                function () { // пoсле aнимaции
                    $(this).css('display', 'none'); // скрываем окно
                    $('.overlay').fadeOut(400); // скрывaем пoдлoжку
                }
            );
    });

    $('.open_registrate').click(function (event) {
        event.preventDefault();
        $('.overlay').fadeIn(400, // анимируем показ обложки
            function () { // далее показываем мод. окно
                $('.modal_registration')
                    .css('display', 'block')
                    .animate({opacity: 1, top: '40%'}, 200);
            });
    });

    $('.modal_close,.overlay').click(function () {
        $('.modal_registration')
            .animate({opacity: 0, top: '45%'}, 200,  // уменьшаем прозрачность
                function () { // пoсле aнимaции
                    $(this).css('display', 'none'); // скрываем окно
                    $('.overlay').fadeOut(400); // скрывaем пoдлoжку
                }
            );
    });

    $('.modal_5').click(function () {
        $('.modal_autorization').hide();
        $('.overlay').fadeIn(400, // анимируем показ обложки
            function () { // далее показываем мод. окно
                $('.modal_registration')
                    .css('display', 'block')
                    .animate({opacity: 1, top: '30%'}, 200);
            });
    });

    $('.modal_registration')
        .animate({opacity: 0, top: '45%'}, 200,  // уменьшаем прозрачность
            function () { // пoсле aнимaции
                $(this).css('display', 'none'); // скрываем окно
                $('.overlay').fadeOut(400); // скрывaем пoдлoжку
            });

    $('.btn_log,.modal_5,.modal_close').click(function () {
        clearModal($(".modal_autorization"));
    });

    $('.modal_close,#register_cancel').click(function () {
        clearModal($(".modal_registration"));

        $('input:checked').prop('checked', false);
    });

    $(function () {
        $("#datepicker").datepicker({
            dateFormat: 'dd-mm-yy'
        });
    });

    $('#register_cancel').click(function () {
        $('.modal_registration')
            .animate({opacity: 0, top: '45%'}, 200,  // уменьшаем прозрачность
                function () { // пoсле aнимaции
                    $(this).css('display', 'none'); // скрываем окно
                    $('.overlay').fadeOut(400); // скрывaем пoдлoжку
                }
            );
    });

    $("#register_ok").click(function () {
        var data = $("form").serializeArray();
        registration(data);
    });

    $(".inputs").click(function () {
        // if (registration_valid_form() === false) {
        click_invalid_form();
        // }
    });

    $("#phone").keypress(function (e) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            e.preventDefault();
        }
    });


    $("[data-toggle]").click(function () {
        var toggle_el = $(this).data("toggle");
        $(toggle_el).toggleClass("open-sidebar");
    });

    enableSelectBoxes();

    $('#email').blur(function () {
        if ($(this).val() != '') {
            var pattern = /^([a-z0-9_\.-])+@[a-z0-9-]+\.([a-z]{2,4}\.)?[a-z]{2,4}$/i;
            if (pattern.test($(this).val())) {
                // $(this).css({'border': '1px solid #569b44'});
                // $('#valid').text('Верно').css({'text-align': 'center'});
                $(this).css({'border': 'none'});
                $('#valid').text('');
            }
            if (pattern.test($(this).val()) == false) {
                $(this).css({'border': '1px solid #ff0000'});
                $('#valid').text('Не верно')
                    .css({'text-align': 'center', 'color': 'red'});
            }
        } else {
            $(this).css({'border': '1px solid #ff0000'});
            $('#valid').text('Поле email не должно быть пустым')
                .css({'text-align': 'center', 'color': 'red'});
        }
    });

});

function createUser(data) {
    post("/authentication/registrate", data).then(function (responce) {
            if (responce.status && responce.data !== false) {
                $('.modal_registration')
                    .animate({opacity: 0, top: '45%'}, 200,  // уменьшаем прозрачность
                        function () { // пoсле aнимaции
                            $(this).css('display', 'none'); // скрываем окно
                            $('.overlay').fadeOut(400); // скрывaем пoдлoжку
                        }
                    );
                window.location.href = responce.data;
            } else {
                alert("User creation server error!");
}
}
    );
}

function clearModal(modal) {
    modal.find("input[type=text]").val('');
    modal.find("input[type=password]").val('');
    modal.find("input[type=email]").val('');
}

function registration(data) {
    var valid = validation();
    var email = $('#email').val();

    if (email === "") {
        $("#email").addClass("invalid_filling");
    } else {
        post("/authentication/isEmail", {email: email}).then(function (responce) {
            if (responce.status === 1 && !responce.data && valid)
                createUser(data);
            
            if (responce.status === 1 && responce.data){
                $("#email").addClass("invalid_filling");
                $('#valid').text('Email вже існує');
            }
        });
    }
}

function validation() {
    var flag = true;

    if ($("#name").val() == "") {
        $("#name").addClass("invalid_filling");
        flag = false;
    }
    if ($("#last_name").val() == "") {
        $("#last_name").addClass("invalid_filling");
        flag = false;
    }
    if ($("#phone").val() == "") {
        $("#phone").addClass("invalid_filling");
        flag = false;
    }

    if ($(".password").val() == "") {
        $(".password").addClass("invalid_filling");
        flag = false;
    }

    if ($(".confirm_password").val() == "") {
        $(".confirm_password").addClass("invalid_filling");
        flag = false;
    }

    var password_val = $(".password");
    var confirm_password_val = $(".confirm_password");

    if (password_val.val() !== confirm_password_val.val()) {
        $(".password").addClass("invalid_filling");
        $(".confirm_password").addClass("invalid_filling");
    }

    return flag;
}

function click_invalid_form() {
    $("input").removeClass("invalid_filling");
}

function enableSelectBoxes() {
    $('div.selectBox').each(function () {
        $(this).children('span.selected,span.selectArrow').click(function () {
            if ($(this).parent().children('div.selectOptions').css('display') == 'none') {
                $(this).parent().children('div.selectOptions').css('display', 'block');
            } else {
                $(this).parent().children('div.selectOptions').css('display', 'none');
            }
        });
    });
}

/*----------  MODAL AUTORIZE  -------------*/
/* $('.open_autorize').click(function (event) {
        event.preventDefault();
        $('.overlay').fadeIn(400, // анимируем показ обложки
            function () { // далее показываем мод. окно
                $('.modal_autorization')
                    .css('display', 'block')
                    .animate({opacity: 1, top: '50%'}, 200);
                $(".container").css('z-index', '1');
            });
    });*/
