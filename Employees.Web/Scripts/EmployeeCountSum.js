$(document).ready(function () {
    var employeeCount = $('.employeeCount');
    var employeeCountSum = $('#employeeCountSum');
    employeeCountSum.html('0');
    $.each(employeeCount, function (index, object) {
        var boldTag = $(object).find('count');
        if (boldTag && boldTag.length > 0 && $(boldTag[0]).html() != '') {
            employeeCountSum.html(parseInt(employeeCountSum.html()) + parseInt($(boldTag[0]).html().replace(/,/g, '')));
        }
    })
});