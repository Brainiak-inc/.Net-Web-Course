function Calculator(input) {
	let operations = {
		addition: '+', 
		substraction: '-',
		multiplication: '*',
		division: '/',
	};

	operations.operationsOrder = [
		[
			[operations.multiplication],
			[operations.division],
		],
		[
			[operations.addition],
			[operations.substraction],
		]
	]	

	input = input.replace(/\s/g, '');

	let output;

	for(let i = 0, n = operations.operationsOrder.length; i < n; i++){
		let calculation = new RegExp('(\\d+\\.?\\d*)([\\' + operations.operationsOrder[i].join('\\') + '])(\\d+\\.?\\d*)');
		
		calculation.lastIndex = 0;
		
		while(calculation.test(input)){
			output = _calculate(RegExp.$1, RegExp.$2, RegExp.$3);
			if (isNaN(output) || !isFinite(output)) {
				return output;
			} 
			input = input.replace(calculation, output);
		}
	}
	return output;

	function _calculate(a, operation, b) {
		a = a * 1;
		b = b * 1;
		switch(operation){
			case operations.addition: return a + b;
		    break;
		    case operations.substraction: return a - b;
		    break;
		    case operations.multiplication: return a * b;
		    break;
		    case operations.division: return a / b;
		    break;
		    default: null;
		}
	}
}

