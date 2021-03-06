dragula([
    document.getElementById('1'),
    document.getElementById('2'),
    document.getElementById('3'),
    document.getElementById('4'),
    document.getElementById('5')
])

    .on('drag', function (el) {

        // add 'is-moving' class to element being dragged
        el.classList.add('is-moving');
    })
    .on('dragend', function (el) {
        var taakId = el.children[0].getAttribute('id').substring(11);

        if ($($(el)[0].parentNode)[0].id === '5') {
            console.log("removing");
            $(el).remove();


            var viewmodel = {
                rtvm: {
                    TaakId: taakId
                }
            };
            $.post("/Taken/RemoveTaak",
                $.toDictionary(viewmodel),
                function (data) {
                    //TODO handel af.
                    console.log(data);
                });

            return true;
        }

        var viewmodel = {
            ctrvm: {
                KolomId: el.parentNode.getAttribute('id'),
                TaakId: taakId
            }
        };
        $.post("/Taken/ChangeTaakNiveau",
            $.toDictionary(viewmodel),
            function (data) {
                //TODO handel af.
                console.log(data);
            });


        // remove 'is-moving' class from element after dragging has stopped
        el.classList.remove('is-moving');
        // add the 'is-moved' class for 600ms then remove it
        window.setTimeout(function () {
            el.classList.add('is-moved');
            window.setTimeout(function () {
                el.classList.remove('is-moved');
            }, 600);
        }, 100);
    });

var openPopup = (function () {
    function show() {
        var currentId = this.getAttribute('id');

        $("#dialog-" + currentId).dialog({
            width: function () {
                if ($(window).width() < 350) {
                    return 300;
                }
                if ($(window).width() < 500) {
                    return 400;
                }
                if ($(window).width() < 750) {
                    return 500;
                }
                return 700;
            },
            autoResize: true,
            height: 'auto',
            modal: true,
            fluid: true,
            resizable: false,
            classes: {
                "ui-dialog": "popup-dialog"
            },
            open: function () {
                $('.ui-widget-overlay').bind('click',
                    function () {
                        $('#dialog-' + currentId).dialog('close');
                    });
            }
        });
        $("button#popup-close").click(function () {
            $("#dialog-" + currentId).dialog("close");
        });
    }

    function hide() {
        $('.popup-window').fadeOut(100);
    }

    function init() {
        $('.drag-container').on('click', '.drag-item-inner', show);

    }

    return {
        init: init
    }
}());

openPopup.init();
function addEvents() {
    $.each($(".subscribe"), function (index, btn) {
        console.log("subscribing to: ", $(btn));
        $(btn).on('click', function (event) {
            $(btn).unbind('click');
            var taakId = btn.getAttribute('taak-id');
            console.log("taakId: " + taakId);
            var viewmodel = {
                rtvm: {
                    TaakId: taakId
                }
            };
            $.post("/Taken/Sub",
                $.toDictionary(viewmodel),
                function (data) {
                    var subBtn = $(btn);
                    var unsubBtn = $("button.unsubscribe[taak-id=" + taakId + "]");

                    subBtn[0].disabled = true;
                    subBtn[0].hidden = true;
                    unsubBtn[0].disabled = false;
                    unsubBtn[0].hidden = false;
                    console.log(data);
                    $(".taak-users-" + taakId).html(data);
                });
        });
    });
    $.each($(".unsubscribe"), function (index, btn) {
        console.log("unsubscribing from: ", $(btn));
        $(btn).unbind('click');
        $(btn).on('click', function (event) {
            var taakId = btn.getAttribute('taak-id');
            console.log("taakId: " + taakId);
            var viewmodel = {
                rtvm: {
                    TaakId: taakId
                }
            };
            $.post("/Taken/Unsub",
                $.toDictionary(viewmodel),
                function (data) {
                    var subBtn = $("button.subscribe[taak-id=" + taakId + "]");
                    var unsubBtn = $(btn);

                    subBtn[0].disabled = false;
                    subBtn[0].hidden = false;
                    unsubBtn[0].disabled = true;
                    unsubBtn[0].hidden = true;
                    console.log(data);
                    $(".taak-users-" + taakId).html(data);
                });
        });
    });
}

$(document).ready(function () {
    addEvents();
});