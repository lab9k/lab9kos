$(doc).ready(function () {
    $(".close button").on('click', hideTempData);
    setTimeout(hideTempData, 3000);
    $('.side-toggle > button').on('click', showSideBar);
    $("#week-search").on('change keydown paste input', filterWeekRows);
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

function showSideBar() {
    $('.side-bar').animate({
        width: 'toggle'
    });
    $('.side-toggle button i').toggleClass('color-white');
}

function filterWeekRows() {
    var rows = $("td[data-th='Naam']").parent();
    var text = $('#week-search').val();
    for (var i = 0; i < rows.length; i++) {
        var rowText = $(rows[i])[0].children[0].innerText;
        if (rowText.indexOf(text) !== -1) {
            $(rows[i]).css('display', 'table-row');
        } else {
            $(rows[i]).css('display', 'none');
        }
        if (text === null || text === "") {
            $(rows[i]).css('display', 'table-row');
        }
    }
}


var doc = document;