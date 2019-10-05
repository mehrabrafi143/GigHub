var FollowServices = function () {

    function createFollow(followeeId, done, failed) {
        $.post("/api/follow/", { followeeId: followeeId })
            .done(done)
            .fail(failed);
    }

    function deleteFollow(id, done, failed) {
        $.ajax({
                url: "/api/follow/" + id,
                method: "DELETE"
            })
            .done(done)
            .fail(failed);
    }

    return {
        createFollow: createFollow,
        deleteFollow: deleteFollow
    }

}();