function openModalLoginRegister(event) {

    const url = "/Account/ModalLoginRegister/";
       
    $.ajax({
        type: 'GET',
        url: url,
        dataType: "html",

        success: function (viewHTML) {
            $('#my_login_modal').empty();
            $('#my_login_modal').html(viewHTML);            
            $('#MyLoginForm').modal('show');
        },
        error: function (errorData) { onError(errorData); }
    });
}