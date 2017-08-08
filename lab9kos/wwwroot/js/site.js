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
});

var doc = document;