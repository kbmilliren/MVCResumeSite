// Problem 1

function maxInput() {
    var number1 = document.getElementById("problemOneInput1").value;
    var number2 = document.getElementById("problemOneInput2").value;
    var number3 = document.getElementById("problemOneInput3").value;
    number1 = parseInt(number1);
    number2 = parseInt(number2);
    number3 = parseInt(number3);
    document.getElementById("max").innerHTML = Math.max(number1, number2, number3);
}