let queue = [];
let filteredNotes;
let lastInput = "";
let hiddenNotes = [];
let removedNotes = [];
let contentDown = true;
let treatmentList = new Map();
let moveMap = new Map();

let contentChangerDown = true;

function search(inputValue){
	let step = new Map();
	let notes = noteStorage.getAll();

	lastInput = inputValue.toLowerCase();
	filteredNotes = noteStorage.getByData(inputValue);

	for(let key of notes.keys()){
		if (!filteredNotes.has(key)) {
			step.set(key, "hd")
		}
		else{
			if (hiddenNotes.filter(function(a) {return a.id == key}).length > 0) {
				step.set(key, "rs");
			}
		}
	}
	if (step) {
		contentManager(step);
	}
}
function ContentManager(step) {

    queue.push(step);
    if (сontentManagerDown) {

        сontentManagerDown = false; 

        let temp = document.getElementsByClassName('content-element');
        let noteInContent = [];
    
        for (let note of temp) {    
            notesOnPage.push(note);

            if (desktop) {
                note.style.left = `${(note.getBoundingClientRect()['x'])}px`;
                note.style.top = `${note.getBoundingClientRect()['y']-10}px`;
            }
        }
        if (desktop) {

            for (let note of temp) {

                note.style.position = 'fixed';
            }
        }
    
        while (queue.length > 0) {
            let curStep = queue.shift();

            for (let item of curStep.keys()) {
                
                if (curStep.get(item) == 'cr') {
                    let tmp = document.getElementsByClassName('content-element');
                    let left = tmp[tmp.length-1].getBoundingClientRect()['x'];
                    let top = tmp[tmp.length-1].getBoundingClientRect()['y'];

                    item.style.top = `${top}px`;
                    item.style.left = `${left}px`;
                    notesOnPage.push(item);

                    if (storage.getByData(lastInput).has(item.id)) {
                        if (desktop) {
                            ChangeOpacity(item, 1);
                        }
                        else {
                            item.style.opacity = '1';
                        }
                        content.appendChild(item); 
                    }
                    else {
                        hiddenNotes.push(item);
                    }
                }
            }
            for (let id of curStep.keys()) {    

                if (curStep.get(id) == 'rm' && document.getElementById(id)) {

                    storage.deleteById(id);
                    let item = document.getElementById(id);
                    noteInContent.splice(noteInContent.indexOf(item), 1);

                    if (desktop) {
                        let commonHeight = 0;
                        for (let elem of noteInContent) {
                            commonHeight += elem.getBoundingClientRect()['height'] + 10;
                            
                            if (commonHeight >= window.innerHeight - 65) {
                                body.style.overflowY = 'scroll';
                                break;
                            }
                        }
    
                        removedNotes.push(item);
                        ChangeOpacity(item, 0);
                    }
                    else {
                        content.removeChild(item);
                    }
                }
            }

            for (let id of curStep.keys()) {    

                if (curStep.get(id) == 'hd' && document.getElementById(id)) {
                    
                    let item = document.getElementById(id);

                    if (desktop) {

                        let commonHeight = 0;

                        for (let elem of noteInContent) {    
                            commonHeight += elem.getBoundingClientRect()['height'] + 10;
                            
                            if (commonHeight >= window.innerHeight - 65) {
                                body.style.overflowY = 'scroll';
                                break;
                            }
                        }

                        ChangeOpacity(item, 0);
                    }
                    else {
                        content.removeChild(item);
                    }
    
                    if (!hiddenNotes.includes(item)) {
                        hiddenNotes.push(item);
                    }
    
                }
            }

            for (let id of curStep.keys()) {    

                if (curStep.get(id) == 'rs') {
    
                    let note;
    
                    for (let item of hiddenNotes) {
                        if (item.id == id) {
                            note = item;
                            hiddenNotes.splice(hiddenNotes.indexOf(item), 1);
                            break;
                        }
                    }
                    if (treatmentList.has(note)) {
                        treatmentList.set(note, 1);
                    }
                    else {
                        itemPlaced = false;
    
                        for (let item of noteInContent) {

                            if (parseInt(item.id) >= parseInt(id)) {    
                                content.insertBefore(note, item);
                                itemPlaced = true;
                                break;
                            }
                        }
                        if (!itemPlaced) {

                            content.appendChild(note);
                        }

                        if (desktop) {
                            ChangeOpacity(note, 1);
                        }
                        else {
                            note.style.opacity = '1';
                        }
                    }
                }
            }

            if (desktop) {

                MoveItems();
            }
        }
        сontentManagerDown = true;
    }
} 
function MoveItems() {
    let notesInContent = document.getElementsByClassName('content-element');
    let top = 50;
    let upperOffset = -10;
    let bottomOffset = 50;

    for (let note of notesInContent) {
        if (!hiddenNotes.includes(note) && !removedNotes.includes(note)) {

            if (top < window.innerHeight || note.getBoundingClientRect()['top']-10 < window.innerHeight || moveMap.has(note) ) {
                if (note.getBoundingClientRect()['top'] > window.innerHeight) {

                    note.style.top = `${window.innerHeight + upperOffset}px`;
                    upperOffset += (note.getBoundingClientRect()['height'] + 10);
                }

                if (note.getBoundingClientRect()['top'] < 55-note.getBoundingClientRect()['height']) {
                    note.style.top = `${bottomOffset-note.getBoundingClientRect()['height']}px`;
                    bottomOffset -= (note.getBoundingClientRect()['height'] + 10);
                }
                MoveItem(note, top);
            }
            else {                              
                note.style.top = `${top}px`;
            } 
           
            top = top + note.getBoundingClientRect()['height'] + 10;
        }
    }
}

function ChangeOpacity(item, targetOpacity, speed = 35, func = null) {

    if (treatmentList.has(item)) {   

        treatmentList.set(item, targetOpacity);
    }
    else {
        treatmentList.set(item, targetOpacity);

        let opacity = parseFloat(item.style.opacity);

        if (!opacity) {opacity = 0};

        let changeTreatment = setInterval(function() {    
    
            if ((treatmentList.get(item) > 0 && opacity > treatmentList.get(item)) || (treatmentList.get(item) == 0 && opacity < treatmentList.get(item))) {
              
                clearInterval(changeTreatment);
    
                if (opacity.toFixed(0) == 0) {    // TODO

                    if (func) {
                        func();
                    }
                    else {
                        content.removeChild(item);

                        if (removedNotes.includes(item) ) {
                            removedNotes.splice(removedNotes.indexOf(item), 1);
                        }
                    }
                }
    
                treatmentList.delete(item);
                
                if (moveMap.size == 0 && treatmentList.size == 0) {

                    for (let item of document.getElementsByClassName('content')) {

                        item.style.position = 'static';
                    }

                    if (hiddenNotes.length == 0 && body.style.overflowY == 'scroll') {
                        body.style.overflowY = '';
                    }
                }
                return;
            }
            if (item.style.opacity > treatmentList.get(item)) {
                opacity -= 0.1;
                item.style.opacity = opacity;
            }
            else {
                opacity += 0.1;
                item.style.opacity = opacity;
            }
        }, speed);
    }
}

function MoveItem(note, target) {

    if (moveMap.has(note)) { 

        moveMap.set(note, target);

    }
    else {

        moveMap.set(note, target);

        let step = 5;
        let initialStep = 5;
        let topOffset = 0;
        let topPosition = note.getBoundingClientRect()['y']-10;

        if (Math.abs(note.getBoundingClientRect()['y']-10 - moveMap.get(note)) < step && step == initialStep) {

            step = 1;
        }
    
        let mooving = setInterval(function() {
    
            if ((note.getBoundingClientRect()['y']-10 > window.innerHeight && topOffset > step) || (note.getBoundingClientRect()['y']-10 < 0 && topOffset < 0-step)) {

                note.style.top = `${moveMap.get(note)}px`;
            }

            if ((note.getBoundingClientRect()['y']-10 < moveMap.get(note) + step && note.getBoundingClientRect()['y']-10 > moveMap.get(note) - step)) {
                
                clearInterval(mooving);
                moveMap.delete(note);
    
                if (moveMap.size == 0 && processingList.size == 0) {
                    for (let item of document.getElementsByClassName('content')) {

                        item.style.position = 'static';
                    }
                    
                    if (hiddenNotes.length == 0 && body.style.overflowY == 'scroll') {
                        body.style.overflowY = '';
                    }
                }
    
                return;
            }
    
            note.style.top = `${topPosition+topOffset}px`

            if (Math.abs(note.getBoundingClientRect()['y']-10 - moveMap.get(note)) < step && step == initialStep) {
                step = 1;
            }

            if (Math.abs(note.getBoundingClientRect()['y']-10 - moveMap.get(note)) > step * 5 && step != initialStep) {
                step = initialStep;
            }
    
            if (note.getBoundingClientRect()['y']-10 > moveMap.get(note)) {
                
                topOffset -= step;
            }
            else {
                topOffset += step;
            }
    
        }, 5);
    }
}