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
                console.log(data);
                $("#student-count").text("Students " + data.studentCount);
                $("#school-count").text("Schools " + data.schoolCount);
                $("#teacher-count").text("Teachers " + data.teacherCount);
                $("#deparment-count").text("Departments " + data.departmentCount);
                $("#classroom-count").text("Classrooms " + data.classroomCount);
                $("#course-count").text("Courses " + data.courseCount);
                console.log("Successfully Got Data!");
            },
            error: function (e) {
                console.log("Error Happened!", e);
            }
        });
    });
});
