
function onConfirmDelete(uniqueId, isDeleteClicked) {
    debugger
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + confirmDeleteSpan).hide();
        $('#' + deleteSpan).show();
    }
}
