$(function () {
    /* BOOTSNIPP FULLSCREEN FIX */
    if (window.location == window.parent.location) {
        $('#back-to-bootsnipp').removeClass('hide');
        $('.alert').addClass('hide');
    }

    $('#fullscreen').on('click', function (event) {
        event.preventDefault();
        window.parent.location = "http://bootsnipp.com/iframe/Q60Oj";
    });

    $('#btnLogin').on('click', function (event) {
        event.preventDefault();
        $('#myModal').modal('show');
    })

    //$('#btnRegister').on('click', function (event) {
    //    event.preventDefault();
    //    $('#registerModal').modal('show');
    //})

    $('#registerForm').submit(function () {
            event.preventDefault();
            $('#registerModal').modal('show');
    });



    $('.btn-mais-info').on('click', function (event) {
        $('.open_info').toggleClass("hide");
    })


});