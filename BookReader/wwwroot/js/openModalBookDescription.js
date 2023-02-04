function openModalBookDescription(paremeters) {

    const data = paremeters.data;
    const querystring = paremeters.url;
    const modal = $('#my_card_modal_show');

    
    $.ajax({
        type: 'get',
        url: querystring,
        data: {"id":data},
        success: function (result) {
            $('#my_card_modal').empty();
            $('#my_card_modal').html(result);
            modal.modal('show');
        }
    })
}