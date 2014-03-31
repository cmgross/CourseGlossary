$(document).ready(function () {
    $("#ddlCourses").change(function (event) {
        var selectedId = $(this).val();
        var chaptersDiv = $("#partialPlaceHolder");
        var url = "/Chapter/GetCourseChapters";
        $.ajax({
            url: url,
            type: "GET",
            dataType: "html",
            data: { id: selectedId },
            //beforeSend: function () {
            //    $.blockUI({
            //        message: "Loading",
            //        css: {
            //            border: 'none',
            //            padding: '15px',
            //            backgroundColor: '#000',
            //            '-webkit-border-radius': '10px',
            //            '-moz-border-radius': '10px',
            //            opacity: .5,
            //            color: '#fff'
            //        }
            //    });
            //},
            success: function (data) {
                chaptersDiv.html(data);
            },
            //complete: function () {
            //    $.unblockUI();
            //}
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve chapters: ' + thrownError);
            }
        });
    });
});  