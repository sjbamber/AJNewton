$(document).ready(function () {

    // confirmation dialog
    $("#contact_notification").dialog({
        resizable: false,
        width: 400,
        modal: true,
        buttons: {
            'OK': function () {
                $(this).dialog('close');
            }
        }
    });

    $("input:submit").button()
    if (!$('#name').val()) {
        $('#name').css("color", "#999");
        $('#name').val("Name");
    } else {
        $('#name').css("color", "#000");
    }
    if (!$('#email').val()) {
        $('#email').css("color", "#999");
        $('#email').val("Email");
    } else {
        $('#email').css("color", "#000");
    }
    if (!$('#phone').val()) {
        $('#phone').css("color", "#999");
        $('#phone').val("Phone");
    } else {
        $('#phone').css("color", "#000");
    }
    if (!$('#message').val()) {
        $('#message').css("color", "#999");
        $('#message').val("Message");
    } else {
        $('#message').css("color", "#000");
    }

    $('input, textarea').focus(function () {
        if ($(this).val() === $(this).attr("title")) {
            $(this).val("");
            $(this).css("color", "#000");
        }
    });

    $('input, textarea').focusout(function () {
        if ($(this).val() === "") {
            $(this).css("color", "#999");
            $(this).val($(this).attr("title"));
        }
    });

    $('#ContactForm').submit(function () {
        $('input:text, textarea').each(function (k, v) {
            if (v.value === $(this).attr("title")) {
                $(this).val("");
            }
        });
    });
});