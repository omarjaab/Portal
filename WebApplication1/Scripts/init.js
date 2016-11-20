/*
	Solarize by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
*/

(function($) {

	

	$(function() {

		var	$window = $(window),
			$body = $('body');

		// Disable animations/transitions until page has loaded.
			$body.addClass('loading');
			
			$window.on('load', function() {
				$body.removeClass('loading');
			});
						


		// Dropdowns.
			$('#nav > ul').dropotron({
				offsetY: -15,
				hoverDelay: 0
			});
		

	});

})(jQuery);