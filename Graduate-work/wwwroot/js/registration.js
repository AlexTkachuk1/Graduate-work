$(document).ready(showHidePassword);
function showHidePassword() {
	$('body').on('click', '.password-checkbox', function () {
		if ($(this).is(':checked')) {
			$('#password-input').attr('type', 'text');
		} else {
			$('#password-input').attr('type', 'password');
		}
	}); 
	$('body').on('click', '.password-checkbox1', function () {
		if ($(this).is(':checked')) {
			$('#password-input2').attr('type', 'text');
		} else {
			$('#password-input2').attr('type', 'password');
		}
	});
};
