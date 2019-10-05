var AttendanceServices = function () {

    var createGig = function (gigId, done, failed) {
        $.ajax({
                url: "/api/attendance",
                method: 'POST',
                data: { GigId: gigId }
            })
            .done(done)
            .fail(failed);
    }

    var deleteGig = function (gigId, done, failed) {
        $.ajax({
                url: '/api/attendance/' + gigId,
                method: 'DELETE'
            })
            .done(done)
            .fail(failed);
    }

    return {
        createGig: createGig,
        deleteGig: deleteGig
    }

}();

