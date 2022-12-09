const showInfo = async (id) => {

    const response = await fetch(`https://localhost:7068/Home/GetInfo?id=${id}`);

    if (response.ok) {
        const data = await response.json();

        Swal.fire({
            html: `<h1>${data.title}</h1>`
                + `<p><b>Description:</b> ${data.description}</p>`
                + `<p><b>Author:</b> ${data.author}</p>`
                + `<p><b>Genre:</b> ${getGenreById(data.genre)}</p>`
        })
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
        })
    }
}

function getGenreById(id) {
    switch (id) {
        case 0:
            return "Classics"
            break;
        case 1:
            return "Detective"
            break;
        case 2:
            return "Mystery"
            break;
        case 3:
            return "Fantasy"
            break;
        case 4:
            return "Historical fiction"
            break;
        case 5:
            return "Literary fiction"
            break;
        case 6:
            return "Other"
            break;
        default:
            break;
    }
}