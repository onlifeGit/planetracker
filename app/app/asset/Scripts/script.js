var check;
var check_email;
var password_val;
var confirm_password_val;

$(document).ready(function () {
    // map_routes();
    select_race();
    get_coordinates();
    // marker_listener();

    //***************************  REMOVE FROM MAP  *****************************************

    $(".name > a").text("Компанія рейсу");
    $(".name > a").click(function () {

        $(".unsubscribe_for_company").css("display", "none");
        $(".subscribe_for_company").css("display", "none");
        get("/home/GetSubscribedCompanies").then(function (responce) {
            // markers_length = responce.data.length;
            if (responce.data === "Error") {
                $(".subscribe_for_company").css("display", "block");
            }
            if (responce.status === 1) {
                for (var i = 0; i < responce.data.length; i++) {
                    if (responce.data[i] === code) {
                        identic = 1;
                        $(".subscribe_for_company").css("display", "none");
                        $(".unsubscribe_for_company").css("display", "block");
                        break;
                    }
                }

                if (identic !== 1) {
                    $(".subscribe_for_company").css("display", "block");
                    $(".unsubscribe_for_company").css("display", "none");
                }

                identic = 0;
                post("/home/GetAirlineInfo", {ident: code}).then(function (responce) {
                    if (responce.status === 1) {
                        click1++;
                        markup1 = responce.data;
                        if (click1 > 1) {
                            $(".no_result1").remove();
                        }
                        $(markup1).insertAfter($(".close1"));

                    }
                    $(".container2").addClass("open-sidebar");

                });
            }

        });

    });

    $(".click_favorite").click(function () {
        get("/home/GetFavouriteFlights").then(function (responce) {
            if (responce.status === 1) {
                click++;
                markup = responce.data;
                if (click > 1) {
                    $(".no_result2").remove();
                }

                $(".container > .sidebar > .popup").append(markup);

                enableSelectBoxes();
                $(".container").addClass("open-sidebar");

            }

        });
    });


    $(".subscribe_for_race").click(function () {
        post("/home/subscribeFlight", {flightId: data}).then(function (responce) {
            if (responce.status === 1) {
                if (responce.data === "OK") {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap").html("Ви успішно підписалися на рейс.");
                }
                if (responce.data === "NoAuth") {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap ").html("Авторизуйтесь, щоб підписатися на рейс.");
                }
                if (responce.data === "Exist") {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap ").html("Ви вже підписані на цей рейс.");
                }
                if (responce.data === "Error") {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap ").html("Помилка підписки.");
                }

                $(".new_popup > a > span.modal_close").click(function () {
                    $(".subscribes_popup").removeClass("open-sidebar");
                });

            }
        });
    });

    $(".unsubscribe_for_race").click(function () {
        post("/home/unsubscribeFlight", {flightId: data}).then(function (responce) {
            if (responce.status === 1) {
                if (responce.data === true) {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap").html("Ви успішно відписалися від рейсу.");
                }
                if (responce.data === false) {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap ").html("Ви не відписалися від рейсу.");
                }

                $(".new_popup > a > span.modal_close").click(function () {
                    $(".subscribes_popup").removeClass("open-sidebar");
                });

            }
        });
    });

    $(".subscribe_for_company").click(function () {
        post("/home/subscribeCompany", {companyId: code}).then(function (responce) {
            if (responce.status === 1) {
                if (responce.data === "OK") {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap").html("Ви успішно підписалися на компанію.");
                }
                if (responce.data === "NoAuth") {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap ").html("Авторизуйтесь, щоб підписатися на компанію.");
                }
                if (responce.data === "Exist") {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap ").html("Ви вже підписані на цю компанію.");
                }
                if (responce.data === "Error") {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap ").html("Помилка підписки.");
                }

                $(".new_popup > a > span.modal_close").click(function () {
                    $(".subscribes_popup").removeClass("open-sidebar");
                });

            }
        });
    });

    $(".unsubscribe_for_company").click(function () {
        post("/home/unsubscribeCompany", {companyId: code}).then(function (responce) {
            if (responce.status === 1) {
                if (responce.data === true) {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap").html("Ви успішно відписалися від компанії.");
                }
                if (responce.data === false) {
                    $(".subscribes_popup").addClass("open-sidebar");
                    $(".result_popap ").html("Ви не відписалися від компанії.");
                }

                $(".new_popup > a > span.modal_close").click(function () {
                    $(".subscribes_popup").removeClass("open-sidebar");
                });

            }
        });
    });


    var i;
    var click3 = 0;
    $(".found_race").click(function () {
        search_race = $(".field_search").val();
        post("/home/GetFlightsInfoStatus", {ident: search_race}).then(function (responce) {

            if (responce.status === 1) {

                $(".not_found_race").css("display", "none");
                $(".unsubscribe_for_race").css("display", "none");
                $(".subscribe_for_race").css("display", "none");
                click++;
                markup = responce.data;

                if (click > 1) {
                    $(".no_result").remove();
                }

                for (i = 0; i < markers_length; i++) {
                    check_race = markers[i].get("id");

                    if (search_race !== check_race) {
                        $(".name").css("display", "block");
                        $(".subscribe_for_race").css("display", "none");
                        $(".unsubscribe_for_race").css("display", "none");

                        if (i === markers_length - 1) {
                            $(".name").css("display", "none");
                            $(".not_found_race").css("display", "block");
                            error_responce = $(".not_found_race").text("Не знайдено такий рейс :(");
                            $(error_responce).insertAfter($(".close"));
                            $(".container1").toggleClass("open-sidebar");
                        }
                    }

                    if (search_race === check_race) {
                        $(".name").css("display", "block");
                        $(".subscribe_for_race").css("display", "none");

                        //post(parametr) subscribeFlight/unsubscribeFlight
                        data = markers[i].get("id");
                        //post(parametr) subscribeCompany/unsubscribeCompany
                        code = markers[i].get("code");

                        get("/home/GetSubscribedFlights").then(function (responce) {
                            // markers_length = responce.data.length;

                            if (responce.data[i] === "Error") {
                                $(".subscribe_for_race").css("display", "block");
                            }

                            if (responce.status === 1) {
                                for (var i = 0; i < responce.data.length; i++) {
                                    if (responce.data[i] === check_race) {
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
                                identic = 0;
                            }

                        });

                        $(markup).insertAfter($(".close"));

                        if ($(markup).hasClass("time")) {
                            $(".subscribe_for_race").css("display", "none");
                            $(".unsubscribe_for_race").css("display", "none");
                            $(".name").css("display", "none");
                        }

                        $(".container1").addClass("open-sidebar");

                        var lat_coordinate = markers[i].getPosition().lat();
                        var lng_coordinate = markers[i].getPosition().lng();

                        map.setCenter({lat: lat_coordinate, lng: lng_coordinate});
                        markers[i].setMap(map);
                        break;
                    }
                    //  else {
                    //     $(".name").css("display", "none");
                    //     $(".not_found_race").css("display", "block");
                    //     error_responce = $(".not_found_race").text("Not found :(");
                    //     $(error_responce).insertAfter($(".close"));
                    //     $(".container1").toggleClass("open-sidebar");
                    // }
                }

            }

        });
    });

    //*******************************************************************

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
        $("#email").removeClass("invalid_filling");
        $('#valid').text('');
        $('#valid_psw').text('');
        $("#email").removeClass("invalid_filling");
        $("#phone").removeClass("invalid_filling");
        $("#name").removeClass("invalid_filling");
        $("#last_name").removeClass("invalid_filling");
        $(".password").removeClass("invalid_filling");
        $(".confirm_password").removeClass("invalid_filling");
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

    $("[data-toggle = '.container']").click(function () {
        var toggle_el = $(this).data("toggle");
        $(".container1").removeClass("open-sidebar");
        $(".container2").removeClass("open-sidebar");

        $(toggle_el).toggleClass("open-sidebar");
    });

    $(".click_favorite").click(function () {
        var toggle_el = $(this).data("toggle");
        $(".container1").removeClass("open-sidebar");
        $(".container2").removeClass("open-sidebar");

        //$(toggle_el).toggleClass("open-sidebar");
    });

    $("[data-toggle = '.container1']").click(function () {
        var toggle_el = $(this).data("toggle");
        $(".container2").removeClass("open-sidebar");
        $(".container").removeClass("open-sidebar");

        $(toggle_el).toggleClass("open-sidebar");
    });

    $("[data-toggle = '.container2']").click(function () {
        var toggle_el = $(this).data("toggle");
        $(".container1").removeClass("open-sidebar");
        $(".container").removeClass("open-sidebar");

        $(toggle_el).toggleClass("open-sidebar");
    });

    $('.open_about').click(function () {
        $(".container1").removeClass("open-sidebar");
        $(".container").removeClass("open-sidebar");
        $(".container2").removeClass("open-sidebar");
        $(".click_favorite").removeClass("open-sidebar");
        $(".subscribes_popup").removeClass("open-sidebar");
    });

    $('.open_registrate').click(function () {
        $(".container1").removeClass("open-sidebar");
        $(".container").removeClass("open-sidebar");
        $(".container2").removeClass("open-sidebar");
        $(".click_favorite").removeClass("open-sidebar");
        $(".subscribes_popup").removeClass("open-sidebar");
    });

    //  $(".name > a").click(function(){
    //     $(".container2").toggleClass("open-sidebar");
    // });
    //
    // $(".close").click(function(){
    //     $(".container1").toggleClass("open-sidebar");
    // });

    enableSelectBoxes();

    $('#email').blur(function () {
        if ($(this).val() != '') {
            var pattern = /^([a-z0-9_\.-])+@[a-z0-9-]+\.([a-z]{2,4}\.)?[a-z]{2,4}$/i;
            if (pattern.test($(this).val())) {
                // $(this).css({'border': '2px solid #569b44'});
                //  $('#valid').text('Вірно').css({'text-align': 'center', 'color': 'green'});
                check_email = 1;
            }
            if (pattern.test($(this).val()) == false) {
                $(this).addClass("invalid_filling");
                $('#valid').text('Не вірно введена пошта')
                    .css({'text-align': 'center', 'color': 'red'});
                check_email = 2;
            }
        } else {
            $(this).addClass("invalid_filling");
            $('#valid').text('Поле email не повинно бути порожнім')
                .css({'text-align': 'center', 'color': 'red'});
            check_email = 3;
        }
    });

    $('#email').focus(function () {
        $("#email").removeClass("invalid_filling");
        // $("#email").css('border', '');
        $('#valid').text('')
            .css({'text-align': 'center', 'color': 'red'});
    });

    $(".password, .confirm_password").blur(function () {
        password_val = $(".password");
        confirm_password_val = $(".confirm_password");
        if (password_val.val() !== confirm_password_val.val()) {
            $(".password").addClass("invalid_filling");
            $(".confirm_password").addClass("invalid_filling");
            $('#valid_psw').text('Паролі не співпадають')
                .css({'text-align': 'center', 'color': 'red'});
            stop_register = 1;
        }
        else{
            stop_register = 0;
        }
    });

    $(".password, .confirm_password").focus(function () {
        $(".password").removeClass("invalid_filling");
        $(".confirm_password").removeClass("invalid_filling");
        $('#valid_psw').text('')
            .css({'text-align': 'center', 'color': 'red'});
        if (password_val.val() !== confirm_password_val.val()) {
            stop_register = 0;
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

    if (valid === false) {
        $('#valid').text('Заповніть обов`язкові поля')
            .css({'text-align': 'center', 'color': 'red'});
    }

    if (email === "") {
        $("#email").addClass("invalid_filling");
    } else {
        post("/authentication/isEmail", {email: email}).then(function (responce) {
            if (responce.status === 1 && !responce.data && valid && stop_register !== 1 && check_email !== 2)
                createUser(data);

            if (responce.status === 1 && responce.data) {
                $("#email").addClass("invalid_filling");
                $('#valid').text('Email вже існує')
                    .css({'text-align': 'center', 'color': 'red'});
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
                $(this).parent().children("span.selectArrow").text('▼');
            } else {
                $(this).parent().children('div.selectOptions').css('display', 'none');
                $(this).parent().children("span.selectArrow").text('◀');
            }
        });
    });
}

function select_race() {
    $(".selectOptions span").click(function () {
        alert("id=" + this.id);
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
