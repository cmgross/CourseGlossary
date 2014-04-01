$(document).ready(function () {
    $("#ddlCourses").change(function (event) {
        var selectedId = $(this).val();
        var url = "/Chapter/GetCourseChaptersJson";
        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
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
                $("#ddlChapters").empty();
                $("#ddlChapters").append("<option></option>");
                $.each(data, function (index, optiondata) {
                    $("#ddlChapters").append("<option value='" + optiondata.Id + "'>" + optiondata.ChapterNumber.toString() + " " + optiondata.Title+ "</option>");
                });
            },
            //complete: function () {
            //    $.unblockUI();
            //}
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve chapters: ' + thrownError);
            }
        });
    });
    $("#ddlChapters").change(function (event) {
        var chapterNumber = $(this).val();
        var courseId = $("#ddlCourses").val();
        var termsDiv = $("#partialPlaceHolder");
        var url = "/GlossaryTerm/GetGlossaryTerms";
        $.ajax({
            url: url,
            type: "GET",
            dataType: "html",
            data: { courseId: courseId, chapterNumber: chapterNumber },
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
                termsDiv.html(data);
            },
            //complete: function () {
            //    $.unblockUI();
            //}
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve terms: ' + thrownError);
            }
        });
    });
});