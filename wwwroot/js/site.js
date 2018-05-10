

$(document).ready(function(){
    $("#postReview").click(function() {
        debugger;
        var book = $("#BookId").val();
        var rating = $("input[name=Rating]:checked").val();
        var review = $("#textPart").val();
        var review = {BookId : book, Rating : rating, ActualReview : review };
        $.post("Review/Create", review, function(data, status) {
            console.log("Success")
        }).fail(function(){
            alert("Something went wrong.");
        });
    });
});
