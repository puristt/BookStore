
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



});

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