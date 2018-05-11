

$(document).ready(function(){
    $("#postReview").click(function() {
        debugger;
        var book = $("#BookId").val();
        var rating = $("input[name=Rating]:checked").val();
        var actualReview = $("#textPart").val();
        var review = {BookId : book, Rating : rating, ActualReview : actualReview };
        $.post("../../Review/Create", review, function(data, status) {
            var newReview = "<li><h2>" + rating + "</h2><h2>" + actualReview + "</h2></li>";
            $("#insertNewReview").append(newReview);
            $("#textPart").val("");
            console.log("Success")

        }).fail(function(){
            alert("You can only post one review.");
        });
    });
});
