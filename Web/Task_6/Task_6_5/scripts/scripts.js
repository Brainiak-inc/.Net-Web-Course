const noteStorage = new Service();
const body = document.querySelector('.body-container');
const editor = document.querySelector('.note-editor');
const content = document.querySelector('.content-container');
const saveButton = document.querySelector('.window-editor-savebutton');
const addButton = document.querySelector('.add-button');
const editorTitleField = document.querySelector('.window-title-editor-text');
const editorTextField = document.querySelector('.textarea-window-editor');
let editingNote = null;
let onPage;



noteStorage.add(['Надежда', 'Надежда умирает последней!']);
noteStorage.add(['Дэдлайн....', 'Тут без комментариев:)']);
noteStorage.add(['Работает', 'Оно живое!']);


publicNotes();

function publicNotes() {

    let notes = noteStorage.getAll();

    for (let key of notes.keys()) {

        addNote(key, notes.get(key)[0], notes.get(key)[1]);
    }
}

function noteClick(note) {

    editingNote = note;
    let selectedNote = noteStorage.getByID(note.id);
    editorTextField.value = selectedNote[1];
    editorTitleField.value = selectedNote[0];
    saveButton.textContent = 'Сохранить';
    editor.classList.add('content-to-top');
    ChangeOpacity(editor, 1, 20);
}


function addButtonClick() {

    editorTextField.value = '';
    editorTitleField.value = '';
    editor.classList.add('content-to-top');
    saveButton.textContent = 'Создать';
    ChangeOpacity(editor, 1, 20);
}


function removeClick(event) {

    event.stopImmediatePropagation();

    if (confirm('Вы действительно хотите удалить заметку?')) {

        let toRemove = new Map();
        toRemove.set(event.target.id, 'rm');
        contentManager(toRemove);
    }
}


function editorSaveClick() {

    if (editingNote != null){

        noteStorage.updateByID(editingNote.id, [editorTitleField.value, editorTextField.value])

        let curNoteTitle = editingNote.querySelector('.content-element-header');
        let curNoteText = editingNote.querySelector('.content-element-text');

        curNoteTitle.textContent = editorTitleField.value;
        curNoteText.textContent = editorTextField.value;

        editingNote = null;

    } else {

        let id = noteStorage.add([editorTitleField.value, editorTextField.value]);
        let createdItem = new Map();
        createdItem.set(addNote(id, editorTitleField.value, editorTextField.value, true), 'cr');
        contentManager(createdItem);
    }

    editorCloseButtonClick();
}

function editorCloseButtonClick() {
    
    ChangeOpacity(editor, 0, 20, function() {
        editor.classList.remove('content-to-top')} 
        );
    editingNote = null;
}

function addNote(id, title, text, opacity = false) {
    let bodyElement = document.createElement('div');
    bodyElement.className = 'content-element';
    bodyElement.id = id;
    bodyElement.style.opacity = 1;
    bodyElement.setAttribute('onclick', 'noteClick(this)');
    if (opacity) {
        bodyElement.style.opacity = 0;
        bodyElement.style.position = 'fixed';
    }

    let bodyElementHeader = document.createElement('p');
    bodyElementHeader.className = 'content-element-header';
    bodyElementHeader.id = `${id}-title`;
    bodyElementHeader.appendChild(document.createTextNode(`${title}`));

    let bodyElementText = document.createElement('p');
    bodyElementText.className = 'content-element-text';
    bodyElementText.id = `${id}-text`;
    bodyElementText.appendChild(document.createTextNode(`${text}`));

    let bodyRemoveButton = document.createElement('div');
    bodyRemoveButton.className = 'window-content-editor-close-button';
    bodyRemoveButton.id = id;
    bodyRemoveButton.setAttribute('onclick', 'removeClick(event)');

    let bodyRemoveButtonImg = document.createElement('img');
    bodyRemoveButtonImg.src = "properties/cancel.png";
    bodyRemoveButtonImg.id = id;
    bodyRemoveButtonImg.className = "window-content-editor-close-button-img";

    bodyRemoveButton.appendChild(bodyRemoveButtonImg);
    bodyElement.appendChild(bodyElementHeader);
    bodyElement.appendChild(bodyElementText);
    bodyElement.appendChild(bodyRemoveButton);

    if (opacity) {

        return bodyElement;
    }
    else {

        content.appendChild(bodyElement);
    }
}