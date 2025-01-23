var modalElement = document.getElementById('addUserModal');

// Mostrar el modal
function mostrarAddUserModal() {
    var modal = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
    modal.show();
}

// Ocultar el modal
function ocultarAddUserModal() {
    var modal = bootstrap.Modal.getInstance(modalElement);
    if (modal) {
        modal.hide();
    }
}
