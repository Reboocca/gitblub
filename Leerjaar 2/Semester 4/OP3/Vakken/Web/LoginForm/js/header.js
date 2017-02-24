var headers = ['header1.jpg', 'header2.jpg', 'header3.jpg'];
var index = 0;


setInterval(function(){
	if (index > 2){
		index = 0;
	}

var path = "url('../afb/" + headers[index] + "')"
alert(path);
	$("header").css('background', path);
		index++;


	}, 2000);
