$(document).ready(function () {
    $('.icon').hide();

    $('input[name=Login]').keyup(function (e) {
        var self = $(this);
        var currentName = self.val();

        var url = '/User/IsUniq?name=' + currentName;
        var promis = $.get(url)
        promis.done(function (respone) {
            $('.icon').hide();

            if (respone) {
                $('.icon.ok').show(); 
            } else {
                $('.icon.no').show();
            }
        });
    });
});