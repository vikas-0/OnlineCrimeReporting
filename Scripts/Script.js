$(document).ready(function () {
    var menu = $('nav');
    var origOffsetY = menu.offset().top;

    function pushFooterDown() {
        if ($('html').height() < $(window).height()) {
            $('.footer').addClass('pushTOBottom');
        }
        else {
            $('.footer').removeClass('pushTOBottom');
        }
    }

    function scroll() {
        if ($(window).scrollTop() >= origOffsetY) {
            $('nav').addClass('navbar-fixed-top');
            $('.container').addClass('container-padding');
        } else {
            $('nav').removeClass('navbar-fixed-top');
            $('.container').removeClass('container-padding');
        }


    }

    //$(document).ready(function () {
    //    var url = window.location.pathname;
    //    var substr = url.split('/');
    //    var urlaspx = substr[substr.length - 1];
    //    $('.nav').find('.active').removeClass('active');
    //    $('.nav li a').each(function () {
    //        if (this.href.indexOf(urlaspx) >= 0) {
    //            $(this).parent().addClass('active');
    //        }
    //    });
    //});

    pushFooterDown();
    document.onscroll = scroll;
    window.onresize = pushFooterDown;
});


