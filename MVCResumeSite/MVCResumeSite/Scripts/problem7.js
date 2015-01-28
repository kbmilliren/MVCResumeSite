function happy(number) {
    var m, digit;
    var cycle = [];

    while (number != 1 && cycle[number] !== true) {
        cycle[number] = true;
        m = 0;
        while (number > 0) {
            digit = number % 10;
            m += digit * digit;
            number = (number - digit) / 10;
        }
        number = m;
    }
    return (number == 1);
}

var cnt = 5;
var number = 1;
function listHappy() {
    $('#prob7out').html('');
    while (cnt-- > 0) {
        while (!happy(number))
            number++;
       $('#prob7out').append(number + "<br/>");
        number++;
    }
}
document.write("<br/>")
