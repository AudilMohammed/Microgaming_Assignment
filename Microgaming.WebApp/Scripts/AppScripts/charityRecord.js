$(document).ready(function () {
    if (sessionStorage.getItem('accessToken') == null) {
        window.location.href = "Login/Index";
    }
    else {
        $.ajax({
            url: '/api/Charity/Get',
            method: 'GET',
            headers: {
                'Authorization': 'Bearer '
                    + sessionStorage.getItem("accessToken")
            },
            success: function (data) {
                $('#divData').removeClass('hidden');
                $('#tblBody').empty();
                $.each(data, function (index, value) {
                    var row = $('<tr><td>' + value.Title + '</td><td>'
                        + value.Charity + '</td><td>'
                        + value.Amount + '</td><td>'
                        + value.Status + '</td><td>'
                        );
                    $('#tblData').append(row);
                });
            },
            error: function (jQXHR) {
                // If status code is 401, access token expired, so
                // redirect the user to the login page
                if (jQXHR.status == "401") {
                    $('#errorModal').modal('show');
                }
                else {
                    $('#divErrorText').text(jqXHR.responseText);
                    $('#divError').show('fade');
                }
            }
        });   
    }

    $('#linkClose').click(function () {
        $('#divError').hide('fade');
    });

    $('#errorModal').on('hidden.bs.modal', function () {
        window.location.href = "Login/Index";
    });

    $('#btnLoadEmployees').click(function () {
        $.ajax({
            url: '/api/Charity/Get',
            method: 'GET',
            headers: {
                'Authorization': 'Bearer '
                    + sessionStorage.getItem("accessToken")
            },
            success: function (data) {              
                $('#tblBody').empty();
                $.each(data, function (index, value) {
                    var row = $('<tr><td>' + value.Title + '</td><td>'
                        + value.Charity + '</td><td>'
                        + value.Amount + '</td><td>'
                        + value.Status + '</td><td>'
                        );
                    $('#tblData').append(row);
                });
            },
            error: function (jQXHR) {
                // If status code is 401, access token expired, so
                // redirect the user to the login page
                if (jQXHR.status == "401") {
                    $('#errorModal').modal('show');
                }
                else {
                    $('#divErrorText').text(jqXHR.responseText);
                    $('#divError').show('fade');
                }
            }
        });
    });
});