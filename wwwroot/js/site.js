
$("#postReview").click(function() {
    debugger;
    var user = $.get("#UserId").val();
    var book = $.get("#BookId").val();
    var rating = $.get("input[name=Rating]:checked").val();
    var review = $.get("#textPart").val();
    var reviewInputModel = { UserId : user, BookId : book, Rating : rating, ActualReview : review }
    $.post("Review/Create", reviewInputModel, function(data, status) {
        console.log("Success")
    }).fail(function(){
        alert("Something went wrong.");
    });
});