// Problem 6
function is_perfect(number) {
    var temp = 0;
    for (var i = 1; i <= number / 2; i++) {
        if (number % i === 0) {
            temp += i;
        }
    }

    if (temp === number) {
        return ("It is a perfect number.");
    }
    else {
        return ("It is not a perfect number.");
    }
    return is_perfect;
}

function perfectInput() {

    var number1 = document.getElementById("perfectInput1").value;
    number1 = parseInt(number1);
    document.getElementById("perfectOutput").innerHTML = is_perfect(number1);
}

function isPerfect(n)
{
    var sum = 1, i, sqrt=Math.floor(Math.sqrt(n));
    for (i = sqrt-1; i>1; i--)
    {
        if (n % i == 0) {
            sum += i + n/i;
        }
    }
    if(n % sqrt == 0)
        sum += sqrt + (sqrt*sqrt == n ? 0 : n/sqrt);
    return sum === n;
}
 

var i;
function listPerfect() {
    $('#prob6out').html('');
    for (i = 1; i < 10000; i++)
    {
        if (isPerfect(i))
            $('#prob6out').append(i + " ");
            
    }
}
document.write("<br/>");
