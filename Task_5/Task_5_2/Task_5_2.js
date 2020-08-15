function Calculator(input) {
	let operations = {
		addition: '+', 
		substraction: '-',
		multiplication: '*',
		division: '/'
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
	
}