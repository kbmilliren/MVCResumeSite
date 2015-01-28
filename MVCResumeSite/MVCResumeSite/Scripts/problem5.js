function printNumbers(a, b) {
    var output = "";
    for (var counter = a; counter <= b && (counter - a <= 100) ; counter++) {
        if (counter % 15 == 0)
            output += "fizzbuzz<br />";
        else if (counter % 3 == 0)
            output += "fizz<br />";
        else if (counter % 5 == 0)
            output += "buzz<br />";
        else
            output += counter + "<br />"

    }
    return output;
}
function numberInput() {
    var number1 = document.getElementById("numberInput1").value;
    var number2 = document.getElementById("numberInput2").value;
    number1 = parseInt(number1);
    number2 = parseInt(number2);
    document.getElementById("numberOutput").innerHTML = printNumbers(number1, number2);
}