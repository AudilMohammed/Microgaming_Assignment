$(document).ready(function () {

    if (sessionStorage.getItem('accessToken') == null) {
        var url = $("#RedirectToLogin").val();
        window.location.href = url;
    }
    else {
      
            
        reload_record();
        
    }
    $(document).on('click', '#btnNavigate', function () {
        $('#SubCharity').modal('show');
        $("#btnUpdate").hide();
        $("#btnCreate").show();
    });
    function reload_record() {
        $.ajax({
            url: '/api/Charity/Get',
            method: 'GET',
            headers: {
                'Authorization': 'Bearer '
                    + sessionStorage.getItem("accessToken")
            },
            success: function (data) {
                var a = $("#IsAdmin").val();

                $('#tblBody').empty();
                $.each(data, function (index, value) {

                    var btnShow = value.IsAdmin && value.status == 'Processing' ? " <input type='button' value='Approve'  class='btn btn-sm btn-success approve-charity' id=" + value.id + "/>" : "";
                    var editbtnShow = value.status == 'Processing' ? "<div><input type='button' value='Edit'  class='btn btn-sm btn-success load-edit' id=" + value.id + "/> <input type='button' value='Delete' class='btn btn-sm btn-success delete-charity' id=" + value.id + "/> " : "";
                    var row = $('<tr><td>' + value.Title + '</td><td>'
                         + value.Description + '</td><td>'
                        + value.Charity + '</td><td>'
                        + value.Currency + '</td><td>'
                        + value.status + "</td><td>" + editbtnShow + btnShow + "</td>"

                        );
                    $('#tblData').append(row);
                });
            },
            error: function (jQXHR, textStatus, errorThrown) {
                // If status code is 401, access token expired, so
                // redirect the user to the login page
                if (jQXHR.status == "401") {
                    $('#errorModal').modal('show');
                }
                else {
                    $('#divErrorText').text(errorThrown);
                    $('#divError').show('fade');
                }
            }
        });
    }
    $(document).on('click', '.delete-charity', function () {
        var trid = $(this).prop("id");
        $.ajax({
            url: '/api/Charity/DeleteRecord',
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            data: {
                trid: parseInt(trid.slice(0, -1))
            },
            headers: {
                'Authorization': 'Bearer '
                    + sessionStorage.getItem("accessToken")
            },
            success: function () {
                reload_record();
            }

        });
    });

    $(document).on('click', '.approve-charity', function () {
        var id = $(this).prop("id");
        $.ajax({
            url: '/api/Charity/ApproveCharity',
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            data: {
                id: parseInt(id.slice(0, -1))
            },
            headers: {
                'Authorization': 'Bearer '
                    + sessionStorage.getItem("accessToken")
            },
            success: function () {
                reload_record();
            }

        });
    });

        $(document).on('click', '.load-edit', function () {
            var trid = $(this).prop("id");
            $.ajax({
                url: '/api/Charity/LoadRecordtoEdit',
                dataType: "json",
                type: "GET",
                contentType: 'application/json; charset=utf-8',
                data: {
                    trid: parseInt(trid.slice(0, -1))
                },
                headers: {
                    'Authorization': 'Bearer '
                        + sessionStorage.getItem("accessToken")
                },
                success: function (data) {
                    $('#SubCharity').modal('show');
                    $('#txttitle').val(data.Title);
                    $('#txtDescription').val(data.Description);
                    $('#txtCharity').val(data.Charity);
                    $('#txtPlayItfwd').attr('checked', data.PlayItFwd);
                    $('#charityId').val(data.id);
                    $('#txtAmount').val(data.Currency);                                   
                    $("#btnCreate").hide();
                    $("#btnUpdate").show();

                }
            });
        });



        $('#linkClose').click(function () {
            $('#divError').hide('fade');
        });

        $('#errorModal').on('hidden.bs.modal', function () {
            var url = $("#RedirectToLogin").val();
            window.location.href = url;

        });
        function createFormData() {
            var formdata = new FormData();
            var file = document.getElementById('txtFileUpload').files.length;
            for (var x = 0; x < file; x++) {
                formdata.append("fileToUpload[]", document.getElementById('txtFileUpload').files[x]);
            }
            // formdata.append('file', file.files[0]);
            formdata.append('Title', $('#txttitle').val());
            formdata.append('Description', $('#txtDescription').val());
            formdata.append('Charity', $('#txtCharity').val());
            formdata.append('Id', $('#charityId').val());
            formdata.append('PlayItFwd', $("#txtPlayItfwd").is(":checked"));
            formdata.append('Amount', parseFloat($('#txtAmount').val()));
            return formdata;
        }

        $('#btnLogoff').click(function () {
            var url = $("#RedirectToLogin").val();
            window.location.href = url;
        });
        $('#btnUpdate').click(function () {
            $.ajax({
                url: '/api/Charity/UpdateCharity',
                type: 'POST',
                data: createFormData(),
                headers: {
                    'Authorization': 'Bearer '
                        + sessionStorage.getItem("accessToken")
                },
                contentType: false,
                processData: false,
                success: function (d) {
                    $('#SubCharity').modal('hide');
                    reload_record();
                },
                error: function () {
                }

            })

        });


        $('#btnCreate').click(function () {

            $.ajax({
                url: '/api/Charity/CreateCharity',
                type: 'POST',
                data: createFormData(),
                headers: {
                    'Authorization': 'Bearer '
                        + sessionStorage.getItem("accessToken")
                },
                contentType: false,
                processData: false,
                success: function (d) {
                    $('#SubCharity').modal('hide');
                    reload_record();

                },
                error: function () {


                }

            })

        });

    });

