$(document).ready(function () {

    // Add scrollspy to <body>
    $('body').scrollspy({ target: ".navbar", offset: 121 });

    $('a[href^="#"]').on('click', function (e) {
        e.preventDefault();

        var target = this.hash,
            $target = $(target);

        $('html, body').stop().animate({
            'scrollTop': $target.offset().top - 120
        }, 900, 'swing', function () {
        });
    });
});

