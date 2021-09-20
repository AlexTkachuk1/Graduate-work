$(document).ready(function (){
	var coockeis = document.cookie.split('; ');
	if (filtrCoockeis) {
		var filtrCoockeis = coockeis.filter(x => x.split('=')[0] == 'lang');
		var currentCoockieLanguage = filtrCoockeis[0].split('=')[1];
		$('.language').val(currentCoockieLanguage);
	}

	$('.language').change(function () {
		var newLang = $('.language').val();
		document.cookie = 'lang=' + newLang;
		location.reload();
	});
})