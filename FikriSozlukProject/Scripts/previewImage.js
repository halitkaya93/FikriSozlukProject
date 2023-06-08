function previewImage(event) {
    var fileInput = event.target;
    var previewImage = document.getElementById('preview');

    var fileReader = new FileReader();
    fileReader.onload = function () {
        previewImage.src = fileReader.result;
        previewImage.style.display = 'block';
    };
    fileReader.readAsDataURL(fileInput.files[0]);
}