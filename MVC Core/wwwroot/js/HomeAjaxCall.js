// When Document is Ready Using Jquery library
$(document).ready(function () {

    // Get the DOM Element
    $("#ajax-call-button").click(function () {

        // In case the button clicked Perform an Asynchronous HTTP Request (Ajax)
        $.ajax({

            // Object => [ url, type, dataType, success, error ]
            url: "/Home/GetDetails",
            type: "GET",
            dataType: "json",
            success: function (data) {

                // In case the request is completed successfully we get the dom element in the page
                // and update its inner text 
                console.log("Successfully Got Data!");
                $("#student-count").text("Students " + data.studentCount);
                $("#school-count").text("Schools " + data.schoolCount);
            },
            error: function (e) {
                console.log("Error Happened!", e);
            }
        });
    });
});
