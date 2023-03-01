let deletebutton = document.querySelectorAll(".deleteItemImage");

deletebutton.forEach(btn => btn.addEventListener("click", function () {
    btn.parentElement.remove()
}))


  
let btn = document.querySelectorAll(".deletebtn");



btn.forEach(btn => btn.addEventListener("click", function (e) {

    e.preventDefault()


    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {

            let url = btn.getAttribute("href");

            fetch(url)
                .then(res => {

                    if (res.status == 200) {
                        window.location.reload(true)
                    } else {
                        alert("Item not found")
                    }
                })
        }
    })
}))










$(function () {

    $('#dropzone').on('dragover', function () {
        $(this).addClass('hover');
    });

    $('#dropzone').on('dragleave', function () {
        $(this).removeClass('hover');
    });

    $('#dropzone input').on('change', function (e) {
        var file = this.files[0];

        $('#dropzone').removeClass('hover');



        $('#dropzone').addClass('dropped');
        $('#dropzone img').remove();

        if ((/^image\/(gif|png|jpeg)$/i).test(file.type)) {
            var reader = new FileReader(file);

            reader.readAsDataURL(file);

            reader.onload = function (e) {
                var data = e.target.result,
                    $img = $('<img />').attr('src', data).fadeIn();

                $('#dropzone div').html($img);
            };
        } else {
            var ext = file.name.split('.').pop();

            $('#dropzone div').html(ext);
        }
    });
});

$(function () {

    $('#Posterdropzone').on('dragover', function () {
        $(this).addClass('hover');
    });

    $('#Posterdropzone').on('dragleave', function () {
        $(this).removeClass('hover');
    });

    $('#Posterdropzone input').on('change', function (e) {
        var file = this.files[0];

        $('#Posterdropzone').removeClass('hover');



        $('#Posterdropzone').addClass('dropped');
        $('#Posterdropzone img').remove();

        if ((/^image\/(gif|png|jpeg)$/i).test(file.type)) {
            var reader = new FileReader(file);

            reader.readAsDataURL(file);

            reader.onload = function (e) {
                var data = e.target.result,
                    $img = $('<img />').attr('src', data).fadeIn();

                $('#Posterdropzone div').html($img);
            };
        } else {
            var ext = file.name.split('.').pop();

            $('#Posterdropzone div').html(ext);
        }
    });
});
