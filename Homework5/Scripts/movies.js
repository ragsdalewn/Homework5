$(document).ready(function () {

    var ajaxFormSubmit = function () {
        var form = $(this);

        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data: form.serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $(form.attr("data-movies-target"));
            target.replaceWith(data);
        });

        return false;
    };

    $("form[data-moviess-ajax='true']").submit(ajaxFormSubmit);

});
