$(document).ready(function () {

    $('.phone-post').addClass('active');

    setTimeout(function () {
        $('.phone-post').removeClass('active');
    }, 1500);

    setInterval(function () {
        $('.phone-post').addClass('active');

        setTimeout(function () {
            $('.phone-post').removeClass('active');
        }, 1500);
    }, 2000);

});