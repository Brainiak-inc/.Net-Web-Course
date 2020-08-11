var words = "У попа была собака"
var resultString = ""

var charArray = words.split([" ", ",", ".", "?","!", "!?", "?!"])

charArray.forEach(function(simbol, i, charArray){
   if(words.includes(simbol)){
    resultString += simbol
   } else{
    resultString += simbol
    resultString += simbol
   }
});

console.log(resultString)