/*
	Note: this file was updated on June 19th 2011, to reflect
	changes in the Facebook API, so some lines differ from those
	in the tutorial.
*/

$(document).ready(function(){

	// Calling our plugin with a page id and an access token
	// that you will need to generate as explained in the tutorial:
	
	$('#wall').facebookWall({
		id:'kuijpersNL',
		access_token:'191042970944652|NGJyz1d0Kclt2XO3AyrjHmrKOHo'
	});

});

// Creating our plugin. You can optionally
// place it in a separate file.

(function($){
	
	$.fn.facebookWall = function(options){
		
		options = options || {};
		
		if(!options.id){
			throw new Error('You need to provide an user/page id!');
		}
		
		if(!options.access_token){
			throw new Error('You need to provide an access token!');
		}
		
		// Default options of the plugin:
		
		options = $.extend({
			limit: 18	// You can also pass a custom limit as a parameter.
		},options);

		// Putting together the Facebook Graph API URLs:

		var graphUSER = 'https://graph.facebook.com/'+options.id+'/?fields=name,picture&access_token='+options.access_token+'&callback=?',
			graphPOSTS = 'https://graph.facebook.com/'+options.id+'/posts/?access_token='+options.access_token+'&callback=?&date_format=U&limit='+options.limit;
		
		var wall = this;
		
		$.when($.getJSON(graphUSER),$.getJSON(graphPOSTS)).done(function(user,posts){
			
			// user[0] contains information about the user (name and picture);
			// posts[0].data is an array with wall posts;
			
			var fb = {
				user : user[0],
				posts : []
			};

			$.each(posts[0].data,function(){
				
				// We only show links and statuses from the posts feed:
				if((this.type != 'link' && this.type!='status') || !this.message){
					return true;
				}

				// Copying the user avatar to each post, so it is
				// easier to generate the templates:
				this.from.picture = fb.user.picture.data.url;
				
				// Converting the created_time (a UNIX timestamp) to
				// a relative time offset (e.g. 5 minutes ago):
				this.created_time = relativeTime(this.created_time*1000);
				
				// Converting URL strings to actual hyperlinks:
				this.message = urlHyperlinks(this.message);

				fb.posts.push(this);
			});

			// Rendering the templates:
			$('#headingTpl').tmpl(fb.user).appendTo(wall);
			
			// Creating an unordered list for the posts:
			var ul = $('<ul>').appendTo(wall);
			
			// Generating the feed template and appending:
			$('#feedTpl').tmpl(fb.posts).appendTo(ul);
		});
		
		return this;

	};

	// Helper functions:

	function urlHyperlinks(str){
		return str.replace(/\b((http|https):\/\/\S+)/g,'<a href="$1" target="_blank">$1</a>');
	}

	function relativeTime(time){
		
		// Adapted from James Herdman's http://bit.ly/e5Jnxe
		
		var period = new Date(time);
		var delta = new Date() - period;

		if (delta <= 10000) {	// Less than 10 seconds ago
			return 'Just now';
		}
		
		var units = null;
		
		var conversions = {
			millisecond: 1,		// ms -> ms
			seconde: 1000,		// ms -> sec
			minuut: 60,			// sec -> min
			uur: 60,			// min -> hour
			dag: 24,			// hour -> day
			maand: 30,			// day -> month (roughly)
			jaar: 12			// month -> year
		};
		
		for (var key in conversions) {
			if (delta < conversions[key]) {
				break;
			}
			else {
				units = key;
				delta = delta / conversions[key];
			}
		}
		
		// Pluralize if necessary:
		
		delta = Math.floor(delta);
		if (delta !== 1) 
		{ 
			switch (units) {
				case "seconde":
					units = "secondes";
					break;
				case "minuut":
					units = "minuten";
					break;
				case "dag":
					units = "dagen";
					break;
				case "maand":
					units = "maanden";
					break;
				default:
					units = units;
					break;
			} 
		}
		return [delta, units, "geleden"].join(' ');
		
	}
	
})(jQuery);