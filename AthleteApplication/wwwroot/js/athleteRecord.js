$(document).ready(function () {
    SetCity();
    SetState();    
});

// Autocomplete
function SetCity() {
    $("#txtCustomer").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Home/City_AutoComplete',
                data: { "searchTerm": request.term },
                type: "POST",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $("#hfCustomer").val(i.item.val);
        },
        minLength: 1
    });
}

function SetState() {
    $("#StateAbbr").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Home/State_AutoComplete',
                data: { "searchTerm": request.term },
                type: "GET",
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        minLength: 1,
        hint: true,
        highlight: true
    });
}

// Does Not Work
function SetCityStateName() {
    $("#searchInput").autocomplete({
        hint: true,
        highlight: true,
        minLength: 0,
        source: function (request, response) {
            $.ajax({
                url: "/Home/AutoComplete",
                type: "POST",
                dataType: "json",
                data: { search: $("#searchInput").val().toLocaleUpperCase() },
                success: function (data) {
                    response($.map(data, function (item) {
                        return item.City;
                       
                    }));
                },
                error: function (xhr, status, error) {
                    alert("HELP!");
                }
            });
        },
        select: function (event, ui) {
            event.preventDefault();
            $('#searchInput').val(ui.item.label);
            $('#StateAbbr').val(ui.item.stateCode);

        }
    });
}


