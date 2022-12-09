const showInfo = async (id) => {

    const response = await fetch(`https://localhost:7004/Home/GetInfo?id=${id}`);

    if (response.ok) {
        const data = await response.json();

        Swal.fire({
            html: `<h1>${data.name}</h1>`
                + `<p><b>Description:</b> ${data.description}</p>`
                + `<p><b>Price:</b> ${data.price}</p>`
                + `<p><b>Count:</b> ${data.count}</p>`
                + `<p><b>Product type:</b> ${ProductTypeById(data.productType)} </p>`
                + `<p><b>Created:</b> ${data.creationDate}</p>`
        })
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
        })
    }
}

function ProductTypeById(id) {
    switch (id) {
        case 0:
            return "Phone"
            break;
        case 1:
            return "Device"
            break;
        case 2:
            return "Monitor"
            break;
        case 3:
            return "Headset"
            break;
        case 4:
            return "Other"
            break;
        default:
            break;
    }
}