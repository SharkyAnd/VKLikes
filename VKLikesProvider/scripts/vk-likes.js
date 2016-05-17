var VKLikesApp = {
    init: function () {
        VK.init({ apiId: 5466083, onlyWidgets: true });
    },
    addWidget: function () {
        VK.Widgets.Like("vk_like", { type: "button", page_id: page_id });
        VK.Observer.subscribe("widgets.like.liked", function (data) {
            VKLikesApp.like();
        });
    },
    like: function () {
        DB.like_page(page_id)
    }
}

var DB = {
    get_page_likes: function (page_id) {
        var d = new $.Deferred();
        $.ajax({
            url: '/Likes/GetPageLikes',
            type: 'GET',
            data: { pageId: page_id },
            success: function (data) {
                d.resolve(data);
            },
            error: function (message) {
                alert("An error occured during processing the request\nMessage: " + message.responseText + "\nStatus code: " + message.Status);
                d.reject();
            }
        })
        return d.promise();
    },
    like_page: function (page_id) {
        var d = new $.Deferred();
        $.ajax({
            url: '/Likes/Like',
            type: 'POST',
            data: { like: JSON.stringify({ PageId: page_id, Moment: new Date() }) },
            success: function (data) {
                alert("New like were added: " + data);
                d.resolve(data);
            },
            error: function (e) {
                alert("An error occured during processing the request\nMessage: " + e.statusText + "\nStatus code: " + e.status);
                d.reject();
            }
        })
        return d.promise();
    }
}