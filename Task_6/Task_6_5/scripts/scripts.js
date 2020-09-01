let noteStorage = new Service();
let body = document.querySelector('.body-container');
let editor = document.querySelector('.note-editor');
let content = document.querySelector('.content-container');
let saveButton = document.querySelector('.window-editor-savebutton');
let addButton = document.querySelector('.add-button');
let titleEditor = document.querySelector('.window-title-editor-text');
let textEditor = document.querySelector('.textarea-window-editor');
let editingNote = null;
let desktop;



noteStorage.add(["Запись 1","Надо выполнить таску до 18:00, время поджимает"]);
noteStorage.add(["Запись 2","Времени все меньше...."]);
noteStorage.add(["Запись 3","Надежды почти не осталось...."]);

publicNote();	

function publicNote(){
	let notes = noteStorage.getAll();
	for(let key of notes.keys()){
		notesAdder(key, notes.get(key)[0], notes.get(key)[1]);
	}
}

function NoteClick(note){
	editingNote = note;
	let selectedNode = noteStorage.getByID(note.id);
	titleEditor.value = selectNote[0];
	textEditor.value = selectNode[1];
	saveButton.textContent = "Сохранить";
	editor.classList.add('content-to-top');
	ChangeOpacity(editor, 1, 20);
}

function addButtonClick(){
	titleEditor.value = "";
	textEditor.value = "";
	editor.classList.add('content-to-top');
	saveButton.textContent = "Создать";
	ChangeOpacity(editor, 1, 20);
}


function closeClick(event){
	event.stopImmediatePropagation();

	if (confirm("Удалить заметку?")) {
		let close = new Map();
		close.set(event.target.id, "rm");
		ContentManager(close);
	}
}

function saveClick(){
	if (editingNote != null) {
		noteStorage.updateByID(editingNote.id, [titleEditor.value, textEditor.value])

		let editingTitle = editingNote.querySelector('.content-element-header'); 
		let editingText = editingNote.querySelector('.content-element-text');

		editingTitle.textContent = titleEditor.value;
		editingText.innerHTML = textEditor.value.replace(/\n/g, '<br>')

		editingNote = null;
	}
	else{
		let id = noteStorage.add([titleEditor.value, textEditor.value]);
		let newItem = new Map();
		newItem.set(AddNote(id, titleEditor.value, textEditor.value, true), "cr");
		ContentManager(newItem);
	}
	editorCloseButton();
}

function editorCloseButton(){
	ChangeOpacity(editor, 0, 20, 
		function(){
			editor.classList.remove('content-to-top')
		}
		);
}

function notesAdder(id, title, text, opacity = false){
	let contentElement = document.createElement('div');
	contentElement.className = 'content-element';
	contentElement.id = id;
	contentElement.style.opacity = 1;
	contentElement.setAttribute('onclick', 'NoteClick(this)');
	if (opacity) {
		contentElement.style.opacity = 0;
		contentElement.style.position = 'fixed';
	}

	let contentElementTitle = document.createElement('p');
	contentElementTitle.className = 'content-element-header';
	contentElementTitle.id = `${id}-title`;
	contentElementTitle.appendChild(document.createTextNode(`${text}`));

	let contentElementText = document.createElement('p');
	contentElementText.className = 'content-element-text';
	contentElementText.id = `${id}-text`;
	contentElementText.innerHTML = text.replace(/\n/g, '<br>');

	let deleteButton = document.createElement('div');
	closeButton.className = 'window-content-editor-close-button';
	closeButton.id = id;
	closeButton.setAttribute('onclick', 'deleteClick(event)');

	let deleteButtonImg = document.createElement('img');
	deleteButtonImg.src = 'properties/cancel.png';
	deleteButtonImg.id = id;
	deleteButtonImg.className = 'window-content-editor-close-button-img';

	deleteButton.appendChild(deleteButtonImg);
	contentElement.appendChild(contentElementTitle);
	contentElement.appendChild(contentElementText);
	contentElement.appendChild(deleteButton);

	if (opacity) {
		return contentElement;
	}
	else{
		content.appendChild(contentElement);
	}
}

