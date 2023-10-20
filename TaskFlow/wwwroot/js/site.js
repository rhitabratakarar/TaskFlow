document.onclick = hideMenu;
let lastRightClickedElementId = "";
var deleteModal = null;

function createNewWorkItem(event) {
    let status = document.getElementById('create-new-modal-workitem-type').value;
    let header = document.getElementById('create-new-modal-title-text').value;
    let description = document.getElementById('create-new-modal-description-text').value;

    // updating the database.
    $.ajax({
        url: "/",
        dataType: "json",
        processData: true,
        data: { Header: header, Description: description, Status: status },
        type: "POST"
    });

    // refresh the component.
}

function handleDeleteModalOpen(event) {
    const delMod = new bootstrap.Modal(document.getElementById('deleteModal'));
    deleteModal = delMod;
    deleteModal.show();
}

function deleteLastRightClickedItem(event) {
    document.getElementById(lastRightClickedElementId).remove();
    deleteModal.hide();
    document.getElementById("droppable-div-" + lastRightClickedElementId.split("-").splice(-1)).remove();
    deleteModal = null;
    $.ajax({
        url: "/",
        dataType: "json",
        processData: true,
        data: { id: lastRightClickedElementId.split("-").splice(-1) },
        type: "DELETE"
    });
}

function hideMenu() {
    document.getElementById("contextMenu").style.display = "none";
}

function handleModalOpen(event) {
    document.getElementById(lastRightClickedElementId).click();
}

function showContextMenu(e) {
    var menu = document.getElementById("contextMenu");
    menu.style.display = 'block';
    menu.style.position = "absolute";
    menu.style.left = e.pageX + "px";
    menu.style.top = e.pageY + "px";
}

function rightClick(e) {
    e.preventDefault();
    if (document.getElementById("contextMenu").style.display == "block") {
        hideMenu();
    } else {
        lastRightClickedElementId = e.target.id;
        showContextMenu(e);
    }
}

function onContextMenuHandler(event) {
    event.preventDefault();
    rightClick(event);
}

function onDragStartHandler(event) {
    event.dataTransfer.setData("id", event.target.id);
    event.stopPropagation();
}

function onDropHandler(event) {
    event.preventDefault();
    event.stopPropagation();
    const elementId = event.dataTransfer.getData("id");  // accordian-0
    let whereToMove = event.target.id;

    if (whereToMove.split("-").slice(0, 2).join("-") === "droppable-div") {
        event.target.insertAdjacentElement("afterend", document.getElementById(elementId));
        const id = elementId.split("-")[1];
        const dropDivToTransfer = "droppable-div-" + id;
        document.getElementById(elementId).insertAdjacentElement("afterend", document.getElementById(dropDivToTransfer));
    }
    if (["doing-section", "done-section", "todo-section"].includes(whereToMove)) {
        document.getElementById(whereToMove).children[1].appendChild(document.getElementById(elementId));
        const id = elementId.split("-")[1];
        const dropDivToTransfer = "droppable-div-" + id;
        document.getElementById(elementId).insertAdjacentElement("afterend", document.getElementById(dropDivToTransfer));
    }
    const id = elementId.split("-")[1];
    let elmMovedTo = whereToMove.split("-")[0] === "droppable" ? document.getElementById(whereToMove).parentElement.parentElement.id : whereToMove;
    elmMovedTo = elmMovedTo[0].toUpperCase() + elmMovedTo.slice(1);
    updateWorkItemLocation(id, elmMovedTo);
}

function updateWorkItemLocation(elementId, elementMovedTo) {
    if (elementMovedTo.split("-").slice(-1)[0] === "section") {
        $.ajax({
            url: "/",
            type: "PUT",
            processData: true,
            dataType: "json",
            data: { Status: elementMovedTo.split("-")[0], WorkItemId: elementId }
        });
    } else {
        console.log("invalid location to move to.");
    }
}

function onDragOverHandler(event) {
    event.preventDefault();
    event.stopPropagation();
}