﻿$(doc).ready(function () {
    $(".close button").on('click', hideTempData);
    setTimeout(hideTempData, 500);
    $('.side-toggle > button').on('click', function (event) {
        $('.side-bar').animate({
            width: 'toggle'
        });
        $('.side-toggle button i').toggleClass('color-white');
    });

});

function hideTempData() {
    $(".temp-data").animate({
            top: "-100px",
            opacity: "0.1"
        },
        1000,
        function (success) {
            $(".temp-data").remove();
        });
}


var doc = document;