//Problem 4

function palindrome(string) {
    var reverse = "";

    for (var i = string.length - 1; i >= 0; i--) {
        reverse += string[i];
    }

    if (string === reverse)
        return ("Entered string is a palindrome.");
    else
        return ("Entered string is not a palindrome.");
}
function clickPal() {
    var word = document.getElementById("palindromeIn").value;
    document.getElementById("palindromeOut").innerHTML = palindrome(word);

}
document.write("<br/>");