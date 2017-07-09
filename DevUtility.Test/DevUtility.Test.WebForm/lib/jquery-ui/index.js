$("#accordion").accordion();

var availableTags = [
    "ActionScript",
    "AppleScript",
    "Asp",
    "BASIC",
    "C",
    "C++",
    "Clojure",
    "COBOL",
    "ColdFusion",
    "Erlang",
    "Fortran",
    "Groovy",
    "Haskell",
    "Java",
    "JavaScript",
    "Lisp",
    "Perl",
    "PHP",
    "Python",
    "Ruby",
    "Scala",
    "Scheme"
];

var selected = false;

$('#autocomplete').change(function () {
    console.log('change');
    selected = false;
});

//$("#autocomplete").autocomplete({
//    source: [
//        { label: 'asd', value: 'zxc' },
//        { label: 'qwe', value: 'haha' }],
//    select: function (event, ui) {
//        console.log('select');
//        console.log(event);
//        console.log(ui);
//        console.log(ui.item);
//    }
//});

$("#autocomplete").autocomplete({
    source: availableTags,
    select: function (event, ui) {
        console.log('select');
        console.log(event);
        console.log(ui);
        console.log(ui.item);
        selected = true;
        console.log(selected);
    }
});

$("#button").button();

$("#button-icon").button({
    icon: "ui-icon-gear",
    showLabel: false
});

$("#radioset").buttonset();

$("#controlgroup").controlgroup();

$("#tabs").tabs();

$("#dialog").dialog({
    autoOpen: false,
    width: 400,
    buttons: [
        {
            text: "Ok",
            click: function () {
                $(this).dialog("close");
            }
        },
        {
            text: "Cancel",
            click: function () {
                $(this).dialog("close");
            }
        }
    ]
});

// Link to open the dialog
$("#dialog-link").click(function (event) {
    $("#dialog").dialog("open");
    event.preventDefault();
});

$("#datepicker").datepicker({
    inline: true
});

$("#slider").slider({
    range: true,
    values: [17, 67]
});

$("#progressbar").progressbar({
    value: 20
});

$("#spinner").spinner();

$("#menu").menu();

$("#tooltip").tooltip();

$("#selectmenu").selectmenu();

// Hover states on the static widgets
$("#dialog-link, #icons li").hover(
    function () {
        $(this).addClass("ui-state-hover");
    },
    function () {
        $(this).removeClass("ui-state-hover");
    }
);

$('#div-ui-weidget').load('ui-weidget.html');