function LoginReq() {
    var LogVal = {
        Userid: $('#Userid').val(),
        Password: $('#Password').val()
    }

    $.ajax({
        url: "/Login/Loginvalidation",
        data: JSON.stringify(LogVal),
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result == 1) {
                window.location = "/MRF/MRFIndex";
            }
            else {
                alert('Login failed');
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}