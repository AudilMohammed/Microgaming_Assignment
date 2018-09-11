$(document).ready(function () {

    var MyScript = new function () {
        var m_options;

        this.init = function (options) {
            m_options = options;
        };
    }

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
                var url = $("#RedirectToCharityRecord").val();
                window.location.href = url;
    
            },
            // Display errors if any in the Bootstrap alert <div>
            error: function (jqXHR) {
                $('#divErrorText').text(jqXHR.responseText);
                $('#divError').show('fade');
            }
        });
    });
});