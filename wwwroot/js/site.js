

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

    $('#Password, #ConfirmPassword').on('keyup', function () {
        if ($('#Password').val() == $('#ConfirmPassword').val()) {
            $('#message').html('Matching').css('color', 'green');
        } 
        else {
            $('#message').html('Not Matching').css('color', 'red');
        }
    });

    
});
