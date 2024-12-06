window.showCartToast = (message) => {
    // Update the toast message if provided
    if (message) {
        document.querySelector('#cartToast .toast-body').textContent = message;
    }

    // Initialize the toast if not already initialized
    const toastEl = document.getElementById('cartToast');
    let toast = bootstrap.Toast.getInstance(toastEl);
    if (!toast) {
        toast = new bootstrap.Toast(toastEl);
    }

    // Show the toast
    toast.show();
};