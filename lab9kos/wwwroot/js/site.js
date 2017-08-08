$(doc).ready(function () {
    $(".close button").on('click', function (event) {
        $(".temp-data").animate({
                top: "-100px",
                opacity: "0.1"
            },
            1000,
            function (success) {
                $(".temp-data").remove();
            });
    });
    $('.side-toggle > button').on('click', function (event) {
        $('.side-bar').animate({
            width: 'toggle'
        });
    });

});

var doc = document;