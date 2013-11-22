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
            var jQData = $(data);
            target.replaceWith(jQdata);
            jQData.effect("bounce", "fast");
        });

        return false;
    };

    $("form[data-movies-ajax='true']").submit(ajaxFormSubmit);

});

var createAutocomplete = function () {
    var input = $(this);

    var options = {
        source: input.attr("data-movies-autocomplete"),
        select: submitAutocompleteForm
    }

    input.autocomplete(options);
};

$("input[data-movies-autocomplete]").each(createAutocomplete);

var submitAutocompleteForm = function (event, ui) {
    var input = $(this);

    input.val(ui.item.label);

    var form = input.parents("form:first");
    form.submit();
}
