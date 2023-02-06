function CheckLoginExist() {

    var login = $("#LoginInputField").val();
    $.ajax({
        type: "POST",
        url: "Account/IfLoginExist",
        data: {input_login: login},
       
        success: function (result) {
            var message = $("#LoginInputSpan");
            if (login != "") {
                if (result.data) {
                    message.html(login + "  " + 'already exist!');
                    message.css("color", "red");
                }
                else {
                    message.html(login + "  " + 'is free to use');
                    message.css("color", "green");
                }
                setTimeout(8000);
            }
            else {
                message.html("");
            }            
        }
        })
}