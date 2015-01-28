// Problem 2
function sum(array) {
    var sum = 0;
    for (var counter = 0; counter < array.length; counter++) {
        sum += array[counter];
    }
    
    return sum;
}

function sumInput() {
    
    var number1 = document.getElementById("problemTwoInput1").value;
    var number2 = document.getElementById("problemTwoInput2").value;
    var number3 = document.getElementById("problemTwoInput3").value;
    number1 = parseInt(number1);
    number2 = parseInt(number2);
    number3 = parseInt(number3);
    document.getElementById("problemTwoOutput").innerHTML = sum([number1, number2, number3]);
}



function multiply(array) {
    var multiply = 1;
    for (var counter = 0; counter < array.length; counter++) {
        multiply = (multiply * array[counter]);
    }
    return multiply;

}

function multiplyInput() {

    var number1 = document.getElementById("mProblemTwoInput1").value;
    var number2 = document.getElementById("mProblemTwoInput2").value;
    var number3 = document.getElementById("mProblemTwoInput3").value;
  
    number1 = parseInt(number1);
    number2 = parseInt(number2);
    number3 = parseInt(number3);
    
    document.getElementById("mProblemTwoOutput").innerHTML = multiply([number1, number2, number3]);

}