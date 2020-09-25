const storage = new Service();  
const body = document.querySelector('.body');
const editor = document.getElementById('editor');
const saveButton = document.getElementById('b2');
const awardsEditor = document.querySelector('.editorAwards');
const mainPageBody = document.querySelector('.body-container');
const effectsSwitcher = document.getElementById('switcher-1');
const editorEmblem = document.querySelector('.editor-avatar');
const fileSelectorButton = document.querySelector('.editor-window-button-label');
const editorEmblemImage = document.querySelector('.editor-avatar-image')
const awardsEditorEmblem = document.querySelector('.awards-editor-avatar');
const awardsEditorEmblemImage = document.querySelector('.awards-editor-avatar-image')
const hightlightSwitcher = document.getElementById('switcher-2');
const editorTitleField = document.getElementById('editorTindowTitle');
const editorDateField = document.querySelector('.editor-date-field');   
const effectsSwitcherBox = document.getElementById('switcher-body-1');

const hightlightSwitcherBox = document.getElementById('switcher-body-2');

let hightLightsLastStatus;
let editedNoteNeedToBeCleared = false;
let futureUserAwards = null;
let awardsSelector = false;
let selectedAvatar = null;
let curEditеdNote = null;
let curEditеdId = null;
let desktop;

if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {

    let head = document.querySelector('.head-element-right');
    head.removeChild(head.querySelector('.switchers-container'));
    desktop = false;

} else {
    desktop = true;
}

function EditorSaveClick() {

    let type;
    let insertion = "update"
    let transitionData = [editorTitleField.value]

    if (curEditеdNote != null) {
        type = 'Update';
    } else {
        insertion = "create"
        type = 'Create';
    }

    if (editorDateField) {
        type = 'user' + type;
        transitionData.push(editorDateField.value)
    }
    else {
        type = 'award' + type;
    }

    let data = new FormData();
    data.append('type', type);
    data.append('id', curEditеdNote);
    data.append('params', JSON.stringify(transitionData));

    fetch('./models/plInteraction', { method: "POST", body: data }).then(response => {

        if (response.status !== 200) {
            return Promise.reject();
        }
        return response.json();

    }).then(function (data) {
        if (data[0] == "null") {
            alert(`Can't ${insertion} element! Check the correctness of the entered data!`);
        }
        else {

            if (!curEditеdNote) {

                let id = storage.add([data[1], data[3]]);
                let createdItem = new Map();
                createdItem.set(AddNote(data[0], id, data[1], data[2], data[3], true), 'cr');
                curEditеdNote = data[0];
                ContentManager(createdItem);
            }
            else {

                let note = document.getElementById(curEditеdId);
                let curNoteTitle = note.querySelector('.body-element-header');

                if (editorDateField != null) {
                    storage.updateByID(note.id, [data[1], storage.getCorrectDateString(data[3])]);
                }
                else {
                    storage.updateByID(note.id, [data[1], null]);
                }

                if (curNoteTitle.textContent != data[1]) {
                    curNoteTitle.textContent = data[1]
                }

                if (editorDateField) {
                    let curNoteDate = note.querySelector('.body-element-date');
                    let curNoteAge = note.querySelector('.body-element-age');

                    if (curNoteDate.textContent != data[3]) {
                        curNoteAge.textContent = `${data[2]} лет`;
                        curNoteDate.textContent = data[3];
                    }
                }
            }
        }

        EditorCloseButtonClick();

        if (futureUserAwards) {
            editedNoteNeedToBeCleared = true;
            AwardsEditorSaveClick()
        }

    }).catch(() => alert(`Can't ${insertion} element! Check the correctness of the entered data!`));
}


function AwardsEditorButtonClick() {

    awardsSelector = true;
    event.stopImmediatePropagation();

    if (curEditеdNote) {

        let data = new FormData();
        data.append('type', 'userAwardsRequest');
        data.append('id', curEditеdNote);

        fetch('./models/plInteraction', { method: "POST", body: data }).then(response => {

            if (response.status !== 200) {
                return Promise.reject();
            }
            return response.json();

        }).then(function (data) {

            for (let item of document.getElementsByClassName('awardCheckbox')) {

                if (data.includes(item.id)) {

                    item.checked = true;
                }
                else {

                    item.checked = false;
                }
            }
            awardsEditor.classList.add('editor-awards-container-to-top');
            ChangeOpacity(awardsEditor, 1, 20);

        }).catch(() => alert("Error getting list of awards!"));
    }
    else {
        for (let item of document.getElementsByClassName('awardCheckbox')) {

            item.checked = false;
        }
        awardsEditor.classList.add('editor-awards-container-to-top');
        ChangeOpacity(awardsEditor, 1, 20);
    }
}

function AwardsEditorSaveClick() {

    if (!futureUserAwards) {
        futureUserAwards = new Array();

        for (let item of document.getElementsByClassName('awardCheckbox')) {

            if (item.checked) {
                futureUserAwards.push(item.id)
            }
        }
    }

    if (curEditеdNote) {

        let data = new FormData();
        data.append('type', 'userAwardsSet');
        data.append('user', curEditеdNote);
        data.append('awards', JSON.stringify(futureUserAwards));

        fetch('./models/plInteraction', { method: "POST", body: data }).then(response => {

            if (response.status !== 200) {
                alert("Couldn't set award to user!")
                return Promise.reject();
            }
            return response.json();

        }).then(function (data) {

            if (data[0] == "false") {
                alert("Couldn't set award to user!");
            }
            else {
                let item = document.getElementsByClassName(curEditеdNote)[0];
                let column1 = document.getElementsByClassName(`c1-${curEditеdNote}`)[0];
                let column2 = document.getElementsByClassName(`c2-${curEditеdNote}`)[0];
                let aditionalContentName = document.getElementsByClassName(`a-${curEditеdNote}`)[0];
                let aditionalContentContent = document.getElementsByClassName(`ac-${curEditеdNote}`)[0];

                if (aditionalContentName) {
                    if (data[0] == "\n") {
                        column1.removeChild(aditionalContentName);
                        column2.removeChild(aditionalContentContent);
                    }
                    else {
                        aditionalContentContent.textContent = data[0];
                    }
                }
                else {
                    let name = document.createElement('p');
                    name.id = `${item.id}-text`;
                    name.className = `body-element-text a-${curEditеdNote}`;
                    name.appendChild(document.createTextNode('\nНаграды:'));

                    let content = document.createElement('p');
                    content.id = `${item.id}-text`;
                    content.className = `body-element-text ac-${curEditеdNote}`;
                    content.appendChild(document.createTextNode(data[0]));

                    column1.appendChild(name);
                    column2.appendChild(content);
                }

                if (editedNoteNeedToBeCleared) {
                    editedNoteNeedToBeCleared = false;
                    futureUserAwards = null;
                    curEditеdNote = null;
                    curEditеdId = null;
                }
            }
        }).catch(() => alert("Couldn't set award to user!"));
    }

    EditorAwardsCloseButtonClick();
}


function RemoveClick(item) {

    event.stopImmediatePropagation();

    if (confirm('You sure you want to delete element?')) {

        let action = "awardRemove";

        if (editorDateField) {
            action = "userRemove";
        }

        let data = new FormData();
        data.append('type', action);
        data.append('id', item.classList[1]);

        fetch('./models/plInteraction', { method: "POST", body: data }).then(response => {

            if (response.status !== 200) {
                return Promise.reject();
            }
            return response.json();

        }).then(function (data) {

            if (data[0] == "true") {

                let toRemove = new Map();
                toRemove.set(item.id, 'rm');
                ContentManager(toRemove);
            }
            else {
                alert('Element hasnt been deleted!');
            }
        }).catch(() => alert('Element hasnt been deleted!'));
    }
}


function RemoveEmblem() {

    if (editorEmblemImage.hidden == true) {

        if (confirm('You sure you want to delete the emblem?')) {

            let note = document.getElementsByClassName(curEditеdNote)[0];
            let userEmblem = note.querySelector('.emblem');
            let userEmblemContainer = note.querySelector('.body-element-avatar');

            let data = new FormData();
            data.append('type', 'removeEmblem');
            data.append('id', curEditеdNote);

            if (editorDateField) {
                data.append('for', 'user');
            }
            else {
                data.append('for', 'award');
            }

            fetch('./models/plInteraction', { method: "POST", body: data }).then(response => {

                if (response.status !== 200) {
                    return Promise.reject();
                }
                return response.json();

            }).then(function (data) {
                if (data[0] == "false") {
                    alert("Couldn't delete emblem!");
                }
                else {
                    userEmblem.hidden = false;
                    editorEmblemImage.hidden = false;
                    userEmblemContainer.style.backgroundImage = null;
                    editorEmblem.style.backgroundImage = null;

                    if (awardsEditor) {
                        awardsEditorEmblemImage.hidden = false;
                        awardsEditorEmblem.style.backgroundImage = null;
                    }
                }
            }).catch(() => alert("Couldn't delete emblem!"));
        }
    }
}

function FileUpload(input) {

    let note = document.getElementsByClassName(curEditеdNote)[0];
    let userEmblem = note.querySelector('.emblem');
    let userEmblemContainer = note.querySelector('.body-element-avatar');

    let data = new FormData();
    data.append('type', 'filestream');
    data.append('id', curEditеdNote);
    data.append('attachfile', input.files[0]);

    if (editorDateField) {
        data.append('for', 'user');
    }
    else {
        data.append('for', 'award');
    }

    fetch('./models/plInteraction', { method: "POST", body: data }).then(response => {

        if (response.status !== 200) {
            return Promise.reject();
        }
        return response.json();

    }).then(function (data) {
        if (data[0] == "false") {
            alert("Couldn't save emblem!");
        }
        else {
            userEmblem.hidden = true;
            editorEmblemImage.hidden = true;
            userEmblemContainer.style.backgroundImage = data[1];
            editorEmblem.style.backgroundImage = data[1];

            if (awardsEditor) {
                awardsEditorEmblemImage.hidden = true;
                awardsEditorEmblem.style.backgroundImage = data[1];
            }
        }
    }).catch(() => alert("Couldn't save emblem!"));
}


function NoteClick(note) {
    
    curEditеdId = note.id;
    curEditеdNote = note.classList[1];
    let selectedNote = storage.getByID(note.id);
    if (editorDateField) {
        editorDateField.value = selectedNote[1];
    }
    editorTitleField.value = selectedNote[0];
    saveButton.textContent = 'Save';

    let item = document.getElementsByClassName(curEditеdNote)[0];
    let itemImageContainer = item.querySelector('.body-element-avatar');
    let itemImage = item.querySelector('.emblem');

    if (itemImage.hidden) {
        editorEmblemImage.hidden = true;
        editorEmblem.classList.add('editor-avatar-opacity');
        editorEmblem.style.backgroundImage = itemImageContainer.style.backgroundImage;

        if (awardsEditor) {
            awardsEditorEmblemImage.hidden = true;
            awardsEditorEmblem.style.backgroundImage = itemImageContainer.style.backgroundImage;
        }
    }
    else {
        editorEmblemImage.hidden = false;
        editorEmblem.style.backgroundImage = null;
        editorEmblem.classList.remove('editor-avatar-opacity');

        if (awardsEditor) {
            awardsEditorEmblemImage.hidden = false;
            awardsEditorEmblem.style.backgroundImage = null;
        }
    }

    fileSelectorButton.hidden = false;
    editor.classList.add('editor-window-container-to-top');
    ChangeOpacity(editor, 1, 20);
}


function AddButtonClick() {

    if (editorDateField) {
        editorDateField.value = '';
    }

    if (editorEmblemImage.hidden) {
        editorEmblemImage.hidden = false;
        editorEmblem.style.backgroundImage = null;
        editorEmblem.classList.remove('editor-avatar-opacity');

        if (awardsEditor) {
            awardsEditorEmblemImage.hidden = false;
            awardsEditorEmblem.style.backgroundImage = null;
        }
    }

    fileSelectorButton.hidden = true;
    editorTitleField.value = '';
    editor.classList.add('editor-window-container-to-top');
    saveButton.textContent = 'Create';
    ChangeOpacity(editor, 1, 20);
}


function EditorCloseButtonClick() {

    if (awardsSelector) {
        EditorAwardsCloseButtonClick();
    }

    ChangeOpacity(editor, 0, 20, function () { editor.classList.remove('editor-window-container-to-top') });

    if (!futureUserAwards) {
        curEditеdNote = null;
    }
    if (futureUserAwards && !curEditеdNote) {
        futureUserAwards = null;
    }
    curEditеdId = null;
}


function EditorAwardsCloseButtonClick() {

    if (awardsSelector) {
        ChangeOpacity(awardsEditor, 0, 20, function () { awardsEditor.classList.remove('editor-awards-container-to-top') });
        awardsSelector = false;
    }
}


function EditorFormClick() {

    event.stopImmediatePropagation();
}


function SwitchEffectsClick() {

    if (desktop) {

        SearchInput('');
        document.querySelector('.search-input').value = '';
        effectsSwitcher.classList.add('switcher-disabled');
        effectsSwitcherBox.classList.add('hightlights-switcher-disabled');

        if (hightLights) {

            SwitchHighlightsClick()
            hightlightSwitcherBox.classList.remove('hightlights-switcher-disabled');
            hightLightsLastStatus = true;

        }
        else {
            hightLightsLastStatus = false;
        }

        desktop = false;
        hightlightSwitcher.classList.add('switcher-blocked');
        hightlightSwitcherBox.classList.add('hightlights-switcher-blocked');
    }
    else {

        SearchInput('');
        document.querySelector('.search-input').value = '';
        effectsSwitcher.classList.remove('switcher-disabled');
        effectsSwitcherBox.classList.remove('hightlights-switcher-disabled');

        if (hightLightsLastStatus) {

            SwitchHighlightsClick()
        }

        desktop = true;
        hightlightSwitcher.classList.remove('switcher-blocked');
        hightlightSwitcherBox.classList.remove('hightlights-switcher-blocked');
    }
}


function SwitchHighlightsClick() {

    if (hightLights) {

        hightLights = false;
        HightlightSearch(true);
        hightlightSwitcher.classList.add('switcher-disabled');
        hightlightSwitcherBox.classList.add('hightlights-switcher-disabled');
    }
    else {
        hightLights = true;
        HightlightSearch();
        hightlightSwitcher.classList.remove('switcher-disabled');
        hightlightSwitcherBox.classList.remove('hightlights-switcher-disabled');
    }
}


function AddNote(guid, id, title, age, date, opacity = false) {

    let bodyElement = document.createElement('div');
    bodyElement.className = `body-element ${guid}`;
    bodyElement.id = id;
    bodyElement.style.opacity = 1;
    bodyElement.setAttribute('onclick', 'NoteClick(this)');
    if (opacity) {
        bodyElement.style.opacity = 0;
        bodyElement.style.position = 'fixed';
    }

    let bodyElementMain = document.createElement('div');
    bodyElementMain.className = 'body-element-main';


    let bodyElementAvatar = document.createElement('div');
    bodyElementAvatar.className = 'body-element-avatar';

    let avatar = document.createElement('img');
    avatar.className = "emblem";
    avatar.src = './images/award.svg';
    if (editorDateField != null) {
        avatar.src = './images/user.svg';
    }
    avatar.alt = "avatar";
    bodyElementAvatar.appendChild(avatar);

    let bodyElementContent = document.createElement('div');
    bodyElementContent.className = 'body-element-content';

    let bodyElementHeader = document.createElement('p');
    bodyElementHeader.className = 'body-element-header';
    bodyElementHeader.id = `${id}-title`;
    bodyElementHeader.appendChild(document.createTextNode(`${title}`));

    let bodyElementColumns;
    if (editorDateField != null) {
        bodyElementColumns = document.createElement('div');
        bodyElementColumns.className = 'body-element-columns';

        let column1 = document.createElement('div');
        column1.className = `column1 c1-${guid}`;

        let column2 = document.createElement('div');
        column2.className = `column2 c2-${guid}`;

        let pfield1 = document.createElement('p');
        pfield1.className = 'body-element-text';
        pfield1.appendChild(document.createTextNode(`Возраст:`));

        let pfield2 = document.createElement('p');
        pfield2.className = 'body-element-text';
        pfield2.appendChild(document.createTextNode(`Дата рождения:`));
        column1.appendChild(pfield1);
        column1.appendChild(pfield2);

        let bodyElementAge = document.createElement('p');
        bodyElementAge.className = 'body-element-text body-element-age';
        bodyElementAge.appendChild(document.createTextNode(`${age} лет`));

        let bodyElementDate = document.createElement('p');
        bodyElementDate.className = 'body-element-text body-element-date';
        bodyElementDate.id = `${id}-date`;
        bodyElementDate.appendChild(document.createTextNode(`${date}`));
        column2.appendChild(bodyElementAge);
        column2.appendChild(bodyElementDate);

        bodyElementColumns.appendChild(column1);
        bodyElementColumns.appendChild(column2);
    }

    let bodyElementFooter = document.createElement('div');
    bodyElementFooter.className = 'body-element-footer';

    let bodyRemoveButton = document.createElement('div');
    bodyRemoveButton.className = `body-remove-button ${guid}`;
    bodyRemoveButton.id = id;
    bodyRemoveButton.setAttribute('onclick', 'RemoveClick(this)');

    let bodyRemoveButtonImg = document.createElement('img');
    bodyRemoveButtonImg.src = "./images/close.svg";
    bodyRemoveButtonImg.alt = "window closure icon";
    bodyRemoveButtonImg.className = "body-remove-button-img";

    bodyElementContent.appendChild(bodyElementHeader)
    if (editorDateField != null) {
        bodyElementContent.appendChild(bodyElementColumns)
    }
    bodyElementMain.appendChild(bodyElementAvatar);
    bodyElementMain.appendChild(bodyElementContent)
    bodyRemoveButton.appendChild(bodyRemoveButtonImg);
    bodyElementFooter.appendChild(bodyRemoveButton);
    bodyElement.appendChild(bodyElementMain);
    bodyElement.appendChild(bodyElementFooter);

    if (opacity) {

        return bodyElement;
    }
    else {

        mainPageBody.appendChild(bodyElement);
    }
}