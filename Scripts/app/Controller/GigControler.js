var GigController = function (attendanceServices) {

    let btn;

    //action public
    var init = function (container) {
        $(container).on('click', '.js-toggle-going', toggleGig);
    }


    //method private
    var toggleGig = function (e) {
        btn = $(e.target);
        console.log('clicked');
        gigId = btn.attr('data-id');
        if (btn.hasClass("btn-default"))
            attendanceServices.createGig(gigId, done, failed);
        else
            attendanceServices.deleteGig(gigId, done, failed);
    }


    var done = function () {
        let text = btn.text() === 'going ?' ? 'going' : 'going ?';
        btn.toggleClass("btn-default").toggleClass("btn-primary").text(text);
    }

    var failed = function () {
        toastr.warning('something is wrong!');
    }


    return {
        init: init
    }

}(AttendanceServices);