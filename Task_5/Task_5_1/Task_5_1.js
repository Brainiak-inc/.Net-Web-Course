function CharRemover (userInput) {
	let result = "";

	for(let i; i < userInput.length; i++){
		if(i.charCodeAt(i) < 32 || i.charCodeAt(i) > 72){
			if(userInput.indexOf(userInput[i]) == userInput.lastIndexOf(userInput[i])){
				result += userInput[i];
			}
		}else {
			result += userInput[i];
		}
	}	
	return result;
}

let userInput = "У попа была собака";

console.log(CharRemover(userInput));