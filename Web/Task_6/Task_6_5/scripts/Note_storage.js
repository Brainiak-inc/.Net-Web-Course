class Service{

	constructor(){
	this.newMapList = new Map();
}

	add(value){
		if (value instanceof Array) {
			let id = 0;

			for(let key of this.newMapList.keys()){
				if (parseInt(key) > id) {
					id = parseInt(key);
				}
			}

			id+=1;
			this.newMapList.set(`${id}`, value);

			return id;
		}
		else{
			console.log("Argument is  not array");

			return null;
		}
	}

	getByID(inputKey){
		if(this.newMapList.has(`${inputKey}`)){
			return this.newMapList.get(`${inputKey}`);
		}
		else{
			return null;
		}
	}

	getByData(data){
		let temp = new Map();
		data = data.toLowerCase();

		for(let key of this.newMapList.keys()){
			for(let item of this.newMapList.get(key)){
				item = item.toLowerCase();
			if (item.includes(data)) {temp.set(key, this.newMapList.get(key));}
			}
		}
		return temp;
	}

	deleteByID(inputKey){
		if (this.newMapList.has(`${inputKey}`)) {
			this.newMapList.delete(`${inputKey}`);
		}
		else{
			console.log('There is no element with such ID');
		}
	}

	replaceByID(inputKey, value){
		if (this.newMapList.has(`${inputKey}`)) {
			if (arr instanceof Array) {
				this.newMapList.set(`${inputKey}`, value);
			}
			else{
				console.log("Programm takes only arrays");
			}
		}
		else{
			console.log("There is no element with such ID or ID has been entered incorrect");
		}
	}

	updateByID(inputKey, value){
		if (this.newMapList.has(`${inputKey}`)) {
			if (value instanceof Array) {
				for(let key in value){
					if (this.newMapList.get(`${inputKey}`)[key] != value[key]) {
						this.newMapList.get(`${inputKey}`)[key] = value[key];
					}
				}
			}
			else{
				console.log("Programm takes only arrays");
			}
		}
		else{
			console.log("There is no element with such ID or ID has been entered incorrect");
		}
	}

	getAll(){
		return this.newMapList;
	}
}