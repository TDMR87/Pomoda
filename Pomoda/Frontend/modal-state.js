function SetModalOpen() {
    document.getElementById('htmlElement').classList.add('modal-is-opening');
    document.getElementById('htmlElement').classList.add('modal-is-open');
}

function SetModalClosed() {
    document.getElementById('htmlElement').classList.remove('modal-is-opening');
    document.getElementById('htmlElement').classList.remove('modal-is-open');
}