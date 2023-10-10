document.onclick = hideMenu;
let lastRightClickedElementId = "";

function createNewWorkItem() {

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
    const data = event.dataTransfer.getData("id");  // accordian-0
    let whereToMove = event.target.id;
    console.log(whereToMove);

    if (whereToMove.split("-").slice(0, 2).join("-") === "droppable-div") {
        event.target.insertAdjacentElement("afterend", document.getElementById(data));
        const id = data.split("-")[1];
        const dropDivToTransfer = "droppable-div-" + id;
        document.getElementById(data).insertAdjacentElement("afterend", document.getElementById(dropDivToTransfer));
    }
    if (["doing-section", "done-section", "todo-section"].includes(whereToMove)) {
        document.getElementById(whereToMove).children[1].appendChild(document.getElementById(data));
        const id = data.split("-")[1];
        const dropDivToTransfer = "droppable-div-" + id;
        document.getElementById(data).insertAdjacentElement("afterend", document.getElementById(dropDivToTransfer));
    }
}

function onDragOverHandler(event) {
    event.preventDefault();
    event.stopPropagation();
}