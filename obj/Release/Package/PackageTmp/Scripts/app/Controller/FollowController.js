var FollowController = function (followServices) {
    let btn;

    function init() {
        $(".js-toggle-follow").on("click",toggleFollow);
    }

    function toggleFollow(e) {
        btn = $(e.target);
        followeeId = btn.data('id');

        if (btn.hasClass('btn-link'))
            followServices.createFollow(followeeId, done, failed);
        else
            followServices.deleteFollow(followeeId, done, failed);

    }

    function done() {
        let text = btn.text() === 'btn-link' ? 'Following' : 'Follow';
        btn.toggleClass('btn-link').toggleClass('btn-primary').text(text);
    }

    function failed(){
        toastr.warning('something is wrong!');
    }


    return {
        init: init
    }


}(FollowServices);
