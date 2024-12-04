window.showModal = (modalId) => {
    var modalElement = document.getElementById(modalId);
    if (modalElement) {
        var modal = new bootstrap.Modal(modalElement, {
            backdrop: false, // Disable backdrop
        });
        modal.show();
    }
};