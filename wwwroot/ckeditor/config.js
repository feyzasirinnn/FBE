CKEDITOR.editorConfig = function (config) {
    config.extraPlugins = 'uploadimage';
    config.extraPlugins = 'filebrowser';
    config.filebrowserUploadMethod = "form";
    config.filebrowserImageUploadUrl = '/CkEditor/UploadImage';
    config.fileTools_requestHeaders = { 'X-CSRFToken': '{{ @GetAntiXsrfRequestToken() }}' };
    config.removePlugins = 'easyimage,cloudservices';
}
