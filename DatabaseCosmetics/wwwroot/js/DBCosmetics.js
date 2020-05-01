const uri = 'api/Collections';
let collections = [];

function getCollections() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCollections(data))
        .catch(error => console.error('Unable to get collections.', error));
}

function addCollection() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-info');

    const collection = {
        name: addNameTextbox.value.trim(),
        info: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(collection)
    })
        .then(response => response.json())
        .then(() => {
            getCollections();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add collection.', error));
}

function deleteCollection(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCollections())
        .catch(error => console.error('Unable to delete collection.', error));
}

function displayEditForm(id) {
    const collection = collections.find(collection => collection.id === id);

    document.getElementById('edit-id').value = collection.id;
    document.getElementById('edit-name').value = collection.name;
    document.getElementById('edit-info').value = collection.info;
    document.getElementById('editForm').style.display = 'block';
}

function updateCollection() {
    const collectionId = document.getElementById('edit-id').value;
    const collection = {
        id: parseInt(collectionId, 10),
        name: document.getElementById('edit-name').value.trim(),
        info: document.getElementById('edit-info').value.trim()
    };

    fetch(`${uri}/${collectionId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(collection)
    })
        .then(() => getCollections())
        .catch(error => console.error('Unable to update collection.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayCollections(data) {
    const tBody = document.getElementById('collections');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(collection => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${collection.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCollection(${collection.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(collection.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(collection.info);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    collections = data;
}
