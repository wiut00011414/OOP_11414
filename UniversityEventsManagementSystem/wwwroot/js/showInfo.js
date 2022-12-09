const showInfo = async (id) => {

    const response = await fetch(`https://localhost:7010/Home/GetInfo?id=${id}`);

    if (response.ok) {
        const data = await response.json();

        Swal.fire({
            html: `<h1>${data.title}</h1>`
                + `<p><b>Creator:</b> ${data.creator}</p>`
                + `<p><b>Created:</b> ${data.creationDate}</p>`
                + `<p><b>Expiry:</b> ${data.expiryDae}</p>`
        })
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
        })
    }
}