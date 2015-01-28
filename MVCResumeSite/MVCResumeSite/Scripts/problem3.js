// Problem 3

function fact(num) {
    if (num < 0)
        return "Undefined";
    var fact = 1;
    for (var i = num; i > 1; i--)
        fact *= i;
    return fact;
}

document.write("<br/>");