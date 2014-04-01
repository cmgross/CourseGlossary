$(document).ready(function () {
    $("#btnSearch").click(function () {
        var searchTerm = $("#termSearch").val();
        var courseId = $("#CourseId").val();
        var url = "/Home/SearchGlossaryTerms";
        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            data: { searchTerm: searchTerm, courseId: courseId },
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
                $("#tblResults").find('tbody').empty();
                $.each(data, function (index, optiondata) {
                    $("#tblResults").find('tbody')
                        .append("<tr><td>" + optiondata.ChapterNumber.toString() + "</td><td>" + optiondata.Term + "</td><td> " + optiondata.Page.toString() + "</td></tr>");
                });
            },
            //complete: function () {
            //    $.unblockUI();
            //}
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve results: ' + thrownError);
            }
        });
    });
});