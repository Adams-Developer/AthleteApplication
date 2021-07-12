// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function setCityName() {
    $("#cityName").typeahead({
        hint: true,
        hightlight: true,
        minLength: 1,
        source: function (request, response) {
            $.ajax({
                url: "/Home/AutoCompleteCityName/",
                data: "{ 'term': } '" + request + "'}",
                type: 'GET',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    items = [];
                    map = {};
                    $.each(data, function (i, item) {
                        var id = item.City;
                        var name = item.City;
                        map[name] = {
                            id: id,
                            name: name
                        };
                        items.push(name);
                    });
                    response(items);
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        updater: function (item) { }
    })
}
