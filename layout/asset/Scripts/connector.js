function get(url) {
    return new Promise(function (succeed, fail) {
        $.ajax({
            type: "GET",
            url: url,
            success: function (responce) {
                return succeed({
                    data: responce,
                    status: 1
                });
            },
            error: function (responce) {
                return fail ({
                    data: responce,
                    status: 0
                });
            }
        });
    });
}

function post(url, data) {
    return new Promise(function (succeed, fail) {
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: function (responce) {
                return succeed({
                    data: responce,
                    status: 1
                });
            },
            error: function (responce) {
                return fail({
                    data: responce,
                    status: 0
                });
            }
        });
    });
}