function loadTweetList(pageIndex, userName, authUser) {
	$.ajax({
		url: "/Tweet/GetTweets",
		type: "POST",
		async: true,
		dataType: "Json",
		data: { pageIndex: pageIndex, userName: userName },
		success: function (result) {
			var html = "";
			if (result == "Success") {
				$.each(result, function (key, item) {
					if (item.ImagePath == null) {
						html += '<li id="tweet_' + item.Id + '"><img src="' + item.UserImage + '"><a href="/profile/' + item.UserName + '">' + item.Name + '</a></li>'
					}
				});
			}
		},
		error: function (result) {

		}
	});
}