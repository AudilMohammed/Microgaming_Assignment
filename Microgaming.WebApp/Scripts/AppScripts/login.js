$(document).ready(function () {

    $('#linkClose').click(function () {
        $('#divError').hide('fade');
    });

    $('#btnLogin').click(function () {
        $.ajax({
            url: '/token',
            method: 'POST',
            contentType: 'application/json',
            data: {
                username: $('#txtUsername').val(),
                password: $('#txtPassword').val(),
                grant_type: 'password'
            },    
            success: function (response) {
                sessionStorage.setItem("accessToken", response.access_token);
                window.location.href = "CharityRecord/CharityRecord";
            },
            // Display errors if any in the Bootstrap alert <div>
            error: function (jqXHR) {
                $('#divErrorText').text(jqXHR.responseText);
                $('#divError').show('fade');
            }
        });
    });
});