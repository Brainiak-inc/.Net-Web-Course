function CharRemover(){
	let userInput = document.getElementById("userInput");
	let splitter = ["?", "!", ".", ",", "!?", "?!", ";", " ",];
	let letters = {}, result;

	let words = userInput.split(' ');

	words.forEach(function (word) {
		word.split('').forEach(function(letter, i){
			if(!letters[letter] && splitter.indexOf(letter) == -1 && -1 != word.indexOf(letter, i + 1)){
				letters[letter] = 1;
			}
		});
	});
	result = userInput.split('').filter(function (v){
		return !letters[v];
	}).join('');

	//alert(result);
				
	let p = document.createElement('p');
	p.innerHTML = "<p>"result"</p>";

	document.body.append(p);
}