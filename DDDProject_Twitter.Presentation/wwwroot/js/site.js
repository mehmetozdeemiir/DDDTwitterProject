import { error } from "jquery";


function Follow(isExist) {
    var model = {
        FollowerId: parseInt($("#FollowerId").val()),
        FollowingId: parseInt($("#FollowingId").val()),
        isExsist: isExist
    };

    $.ajax({
        data: { FollowerId: model.FollowerId, FollowingId: model.FollowingId, isExist: model.isExsist },
        type: "POST",
        url: "/Follow/Follow/",
        dataType: "JSON",
        success: function (result) {
            if (result == "Success") {
                if (!isExist) {
                    $("#Follow").replaceWith('<button onclick="Follow(true)" id="UnFollow" class="btn btn-info btn-sm">Unfollow</button>');
                    FollowersCount = FollowersCount + 1;
                    $("#FollowersCount").replaceWith('<li id="FollowersCount"><strong>' + FollowersCount + '</strong> - Followers</li>')
                }
                else {
                    $("#UnFollow").replaceWith('<button onclick="Follow(false)" id="Follow" class="btn btn-info btn-sm">Follow</button>');
                    FollowersCount = FollowersCount - 1;
                    $("#FollowersCount").replaceWith('<li id="FollowersCount"><strong>' + FollowersCount + '</strong> - Followers</li>')
                }
            }
        }
    });
}

$(document).ready(function () {

    $("#btnSendTweet").click(function (e) {

        var formData = new FormData();

        formData.append("AppUserId", JSON.stringify(parseInt($("#AppUserId").val())));
        formData.append("Text", $("#Text").val());
        formData.append("Image", $("#Image").val());

        $.ajax({
            data: formData,
            type: "POST",
            url: "/Tweet/AddTweet",
            success: function (result) {
                if (result == "Success") {
                    document.getElementById("Text").value = "";
                    $("#tweetValidation").addClass("alert alert-success").text("Send Successfully..!");
                    $("#tweetValidation").alert();
                    $("#tweetValidation").fadeOut(2000, 2000).slideDown(800, function () { });
                }
                else {
                    $("#tweetValidation").addClass("alert alert-danger").text("Error Occured..!");
                    $("#tweetValidation").alert();
                    $("#tweetValidation").fadeOut(2000, 2000).slideDown(800, function () { });
                }
            },
            error: function (result) {
                $("#tweetValidation").addClass("alert alert-success").text(result.responseText);
                $("#tweetValidation").alert();
                $("#tweetValidation").fadeOut(2000, 2000).slideDown(800, function () { });
            }
        });

    });

});
