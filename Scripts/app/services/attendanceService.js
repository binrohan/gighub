var AttendanceService = function () {
    var createAttendance = function (gigId, done, fail) {
        $.post("/api/Attendences", { "gigId": gigId })
            .done(done)
            .fail(fail);
    }

    var deleteAttendance = function (gigId, done, fail) {
        $.ajax({
            url: "/api/Attendences/" + gigId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail)
    }

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    }
}();

