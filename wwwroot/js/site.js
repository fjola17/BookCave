

$(document).ready(function(){
    $("#postReview").click(function() {
        debugger;
        var book = $("#BookId").val();
        var rating = $("input[name=Rating]:checked").val();
        var actualReview = $("#textPart").val();
        var review = {BookId : book, Rating : rating, ActualReview : actualReview };
        $.post("../../Review/Create", review, function(data, status) {
            location.reload();
        }).fail(function(){
            alert("You can only post one review.");
        });
    });

    var check = function() {
        if (document.getElementById("password").value ==
        document.getElementById("confirm_password").value) {
            document.getElementById("message").style.color = "green";
            document.getElementById("message").innerHTML = "matching";
        } 
        else {
        document.getElementById("message").style.color = "red";
        document.getElementById("message").innerHTML = "not matching";
        }

    }
});
