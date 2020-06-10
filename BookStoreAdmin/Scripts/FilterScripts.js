

$(function () {
    $("#multiSelectDropDownCategory").chosen();
    $("#multiSelectDropDownPublisher").chosen();
    $("#multiSelectDropDownAuthor").chosen();

    $("#btnBookFilter").on("click", function () {

        var model = {
            StartDate: $("#start-date").val(),
            EndDate: $("#end-date").val(),
            CategoryIds: $("#multiSelectDropDownCategory").val(),
            PublisherIds: $("#multiSelectDropDownPublisher").val(),
            AuthorIds: $("#multiSelectDropDownAuthor").val(),
            BookName: $("#book-val").val(),
        }

        console.log(model);
        $.ajax({

            type: "POST",
            url: "/Book/LoadFilteredResults",
            data: model,
            success: function (response) {
                $("#bookList").html(response);
            }
        });

    });



});