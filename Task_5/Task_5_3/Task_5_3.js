"use strict"

class Service{
	newMapList = new Map();
	static id = 0;

	add(value){
		if(value === undefined){
			throw new SyntaxError('Invalid argument value');
		}
		if(typeof(value) != 'object'){
			throw new SyntaxError('Invalid argument value - not object');
		}
		this.newMapList.set(this.id.toString(), value);
		this.id++;
	}
	getByID(inputKey){
		if (inputKey === undefined || inputKey === null) {
			throw new SyntaxError('Invalid argument Key');
		}
		if (this.newMapList(inputKey.toString())) {
			return this.newMapList.get(inputKey.toString());
		}
		return null;
	}
	deleteByID(inputKey){
		if (inputKey === undefined || inputKey === null) {
			throw new SyntaxError('Invalid argument Key');
		}
		if (this.newMapList.has(inputKey.toString())) {
			let result = this.newMapList.getByID(inputKey);
			this.newMapList.delete(inputKey.toString());

			return result;
		}
		return null;
	}

	replaceByID(inputKey, value){
		if (inputKey === undefined || inputKey === null) {
			throw new SyntaxError('Invalid argument Key');
		}
		if (value === undefined) {
			throw new SyntaxError('Invalid argument value');
		}
		if(typeof(value) != 'object'){
			throw new SyntaxError('Invalid argument value - not object');
		}
		if (this.newMapList.has(inputKey.toString())) {
			this.newMapList.set(inputKey.toString, value);
			return true;
		}
		return false;
	}

	updateByID(inputKey, value){
		if (inputKey === undefined || inputKey === null) {
			throw new SyntaxError('Invalid argument value');
		}
		if(typeof(value) != 'object'){
			throw new SyntaxError('Invalid argument value - not object');
		}
		if (this.newMapList.has(inputKey, value)) {

		}
		if (this.newMapList.has(inputKey.toString())) {
			let object = this.getByID(inputKey);
			object = Object.assign(object, value);

			this.replaceByID(inputKey, value);
			return true;
		}
		return false;
	}
	getAll(){
		return Array.from(this.newMapList.values());
	}
}