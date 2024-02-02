function downloadFileFromStream(fileName, string) {
    const url = URL.createObjectURL(new Blob([string], { type: "application/json" }));
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.setImage = async (imageElementId, imageStream, imagedata) => {
    const arrayBuffer = await imageStream.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const image = document.getElementById(imageElementId);
    image.src = url;
}


