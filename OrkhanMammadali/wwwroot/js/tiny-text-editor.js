

tinymce.init({
    selector: '#editor',
    menubar: false,
    plugins: "link code emoticons hr lists charmap table media",
    external_plugins: { tiny_mce_wiris: 'https://www.wiris.net/demo/plugins/tiny_mce/plugin.js' },
    fontsize_formats: "8pt 10pt 12pt 13pt 14pt 18pt 24pt 36pt",
    toolbar1: 'undo redo  |  fontsizeselect | bold italic underline strikethrough | superscript subscript |bullist numlist | removeformat| alignleft aligncenter alignright alignjustify | forecolor | outdent indent | link emoticons charmap hr | code ',
    // enable automatic uploads of images represented by blob or data URIs
    automatic_uploads: true,
    // add custom filepicker only to Image dialog
    file_picker_types: 'image',
    file_picker_callback: function (cb, value, meta) {
        var input = document.createElement('input');
        input.setAttribute('type', 'file');
        input.setAttribute('accept', 'image/*');
        input.onchange = function () {
            var file = this.files[0];
            var reader = new FileReader();
            reader.onload = function () {
                var id = 'blobid' + (new Date()).getTime();
                var blobCache = tinymce.activeEditor.editorUpload.blobCache;
                var base64 = reader.result.split(',')[1];
                var blobInfo = blobCache.create(id, file, base64);
                blobCache.add(blobInfo);
                // call the callback and populate the Title field with the file name
                cb(blobInfo.blobUri(), { title: file.name });
            };
            reader.readAsDataURL(file);
        };
        input.click();
    }
});


tinymce.init({
    selector: '#editorsecond',
    menubar: false,
    plugins: "link code emoticons hr lists charmap table media",
    external_plugins: { tiny_mce_wiris: 'https://www.wiris.net/demo/plugins/tiny_mce/plugin.js' },
    fontsize_formats: "8pt 10pt 12pt 13pt 14pt 18pt 24pt 36pt",
    toolbar1: 'undo redo  |  fontsizeselect | bold italic underline strikethrough | superscript subscript |bullist numlist | removeformat| alignleft aligncenter alignright alignjustify | forecolor | outdent indent | link emoticons charmap hr | code ',
    // enable automatic uploads of images represented by blob or data URIs
    automatic_uploads: true,
    // add custom filepicker only to Image dialog
    file_picker_types: 'image',
    file_picker_callback: function (cb, value, meta) {
        var input = document.createElement('input');
        input.setAttribute('type', 'file');
        input.setAttribute('accept', 'image/*');
        input.onchange = function () {
            var file = this.files[0];
            var reader = new FileReader();
            reader.onload = function () {
                var id = 'blobid' + (new Date()).getTime();
                var blobCache = tinymce.activeEditor.editorUpload.blobCache;
                var base64 = reader.result.split(',')[1];
                var blobInfo = blobCache.create(id, file, base64);
                blobCache.add(blobInfo);
                // call the callback and populate the Title field with the file name
                cb(blobInfo.blobUri(), { title: file.name });
            };
            reader.readAsDataURL(file);
        };
        input.click();
    }
});



tinymce.init({
    selector: '#editorthird',
    menubar: false,
    plugins: "link code emoticons hr lists charmap table media",
    external_plugins: { tiny_mce_wiris: 'https://www.wiris.net/demo/plugins/tiny_mce/plugin.js' },
    fontsize_formats: "8pt 10pt 12pt 13pt 14pt 18pt 24pt 36pt",
    toolbar1: 'undo redo  |  fontsizeselect | bold italic underline strikethrough | superscript subscript |bullist numlist | removeformat| alignleft aligncenter alignright alignjustify | forecolor | outdent indent | link emoticons charmap hr | code ',
    // enable automatic uploads of images represented by blob or data URIs
    automatic_uploads: true,
    // add custom filepicker only to Image dialog
    file_picker_types: 'image',
    file_picker_callback: function (cb, value, meta) {
        var input = document.createElement('input');
        input.setAttribute('type', 'file');
        input.setAttribute('accept', 'image/*');
        input.onchange = function () {
            var file = this.files[0];
            var reader = new FileReader();
            reader.onload = function () {
                var id = 'blobid' + (new Date()).getTime();
                var blobCache = tinymce.activeEditor.editorUpload.blobCache;
                var base64 = reader.result.split(',')[1];
                var blobInfo = blobCache.create(id, file, base64);
                blobCache.add(blobInfo);
                // call the callback and populate the Title field with the file name
                cb(blobInfo.blobUri(), { title: file.name });
            };
            reader.readAsDataURL(file);
        };
        input.click();
    }
});


tinymce.init({
    selector: '#editorfourth',
    menubar: false,
    plugins: "link code emoticons hr lists charmap table media",
    external_plugins: { tiny_mce_wiris: 'https://www.wiris.net/demo/plugins/tiny_mce/plugin.js' },
    fontsize_formats: "8pt 10pt 12pt 13pt 14pt 18pt 24pt 36pt",
    toolbar1: 'undo redo  |  fontsizeselect | bold italic underline strikethrough | superscript subscript |bullist numlist | removeformat| alignleft aligncenter alignright alignjustify | forecolor | outdent indent | link emoticons charmap hr | code ',
    // enable automatic uploads of images represented by blob or data URIs
    automatic_uploads: true,
    // add custom filepicker only to Image dialog
    file_picker_types: 'image',
    file_picker_callback: function (cb, value, meta) {
        var input = document.createElement('input');
        input.setAttribute('type', 'file');
        input.setAttribute('accept', 'image/*');
        input.onchange = function () {
            var file = this.files[0];
            var reader = new FileReader();
            reader.onload = function () {
                var id = 'blobid' + (new Date()).getTime();
                var blobCache = tinymce.activeEditor.editorUpload.blobCache;
                var base64 = reader.result.split(',')[1];
                var blobInfo = blobCache.create(id, file, base64);
                blobCache.add(blobInfo);
                // call the callback and populate the Title field with the file name
                cb(blobInfo.blobUri(), { title: file.name });
            };
            reader.readAsDataURL(file);
        };
        input.click();
    }
});

