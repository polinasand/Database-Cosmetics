const uri = 'api/CosmTypes';
let cosmTypes = [];

function getCosmTypes() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCosmTypes(data))
        .catch(error => console.error('Unable to get types.', error));
}

function addCosmtype() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-info');

    const cosmtype = {
        name: addNameTextbox.value.trim(),
        info: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cosmtype)
    })
        .then(response => response.json())
        .then(() => {
            getCosmTypes();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add type.', error));
}

function deleteCosmType(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCosmTypes())
        .catch(error => console.error('Unable to delete type.', error));
}

function displayEditForm(id) {
    const cosmtype = cosmTypes.find(cosmtype => cosmtype.id === id);

    document.getElementById('edit-id').value = cosmtype.id;
    document.getElementById('edit-name').value = cosmtype.name;
    document.getElementById('edit-info').value = cosmtype.info;
    document.getElementById('editForm').style.display = 'block';
}

function updateCosmType() {
    const cosmtypeId = document.getElementById('edit-id').value;
    const cosmtype = {
        id: parseInt(cosmtypeId, 10),
        name: document.getElementById('edit-name').value.trim(),
        info: document.getElementById('edit-info').value.trim()
    };

    fetch(`${uri}/${cosmtypeId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cosmtype)
    })
        .then(() => getCosmTypes())
        .catch(error => console.error('Unable to update cosmtype.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayCosmTypes(data) {
    const tBody = document.getElementById('cosmTypes');
    tBody.innerHTML = '';


    const button = document.createElement('button');
    button.style.color= '#fff';
    button.style.backgroundColor = '#070707';
    button.style.borderColor = '#010000';
    button.style.fontFamily = "Nunito Sans"
    data.forEach(cosmtype => {
        let editButton = button.cloneNode(false);
       
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${cosmtype.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deletecosmtype(${cosmtype.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(cosmtype.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(cosmtype.info);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    cosmTypes = data;
}
