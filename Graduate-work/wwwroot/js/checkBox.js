$(document).ready(function () {
    $("#check").click(function () {
        if ($("#check").val() == 0) {
            $("#check").val(false);
        }
        else {
            $("#check").val(true);
        }
        var valueForTest = $("#check").val();
    });
});