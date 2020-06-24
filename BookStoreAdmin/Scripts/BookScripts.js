var itemId = -1;
var selectorTop = '.pagination-list-top li';
var selectorBottom = '.pagination-list-bottom li';

$(function () {
    $("#multiSelectDropDownCategory").chosen();
    $("#multiSelectDropDownPublisher").chosen();
    $("#multiSelectDropDownAuthor").chosen();



    $(".pagination-list-top li:first-child").addClass('active');
    $(".pagination-list-bottom li:first-child").addClass('active');



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
                $(".pagination-list-top li:first-child").addClass('active');
                $(".pagination-list-bottom li:first-child").addClass('active');
            }
        });

    });
    $('#confirmModal').on('show.bs.modal',
        function (e) {

            var btn = $(e.relatedTarget);

            itemId = btn.data("book-id");
        });


});


var DeleteBook = function () {

    $.ajax({
        type: "POST",
        url: "/Book/Delete",
        data: { "id": itemId }
    }).done(function (data) {
        $('#confirmModal').modal('hide');
        if (data.result) {
            $('#successModal').modal('show');
            $("#bookList").load("/Book/LoadFilteredResults");
        } else {
            $('#errorModal_body').remove('.error-message');
            $('#errorModal_body').append("<p class='error-message'>Silerken bir hata oluştu. Lütfen tekrar deneyiniz!</p>");
            $('#errorModal').modal('show');
        }

    });
}



function paging(val) {

    var value = $(val).text();
    var pageNum = parseInt(value);



    var pagingModel = {
        StartDate: $("#start-date").val(),
        EndDate: $("#end-date").val(),
        CategoryIds: $("#multiSelectDropDownCategory").val(),
        PublisherIds: $("#multiSelectDropDownPublisher").val(),
        AuthorIds: $("#multiSelectDropDownAuthor").val(),
        BookName: $("#book-val").val(),
        page: pageNum,
    }

    $.ajax({

        type: "POST",
        url: "/Book/LoadFilteredResults",
        data: pagingModel,
        success: function (response) {
            $("#bookList").html(response);

            $(selectorTop).removeClass('active');
            $(selectorBottom).removeClass('active');
            $('.pagination-list-bottom').find(val).addClass('active');
            $('.pagination-list-top').find(val).addClass('active');
        }
    });


}