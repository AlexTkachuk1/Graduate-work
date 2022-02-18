$(document).ready(showHidePassword);
function showHidePassword() {
    /*$('.password-checkbox').click(showAndHide());*/

    $('body').on('click', '.password-checkbox', function () {
        if ($('.password-checkbox').is(':checked')) {
            $('#password-input').attr('type', 'text');
        } else {
            $('#password-input').attr('type', 'password');
        }
    });
    $('body').on('click', '.password-checkbox1', function () {
        if ($('.password-checkbox1').is(':checked')) {
            $('#password-input2').attr('type', 'text');
        } else {
            $('#password-input2').attr('type', 'password');
        }
    });
   
};
