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