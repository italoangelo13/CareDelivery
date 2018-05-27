function showLoading(msg) {
    $('#text-load').val(msg);
    $('#loader').css('display', 'flex');
}


function hideLoading() {
    $('#loader').css('display', 'none');
}