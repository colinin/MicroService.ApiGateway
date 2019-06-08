layui.use(['code'], function () {
    var code = layui.code({
        title: 'OcelotConfiguration',
        about: false
    });

    $('#btnDownload').click(function () {
        var ocelotConfiguration = $('#ocelotConfiguration')[0].outerText.substring('OcelotConfiguration'.length + 1);
        var downloadData = "data:text/json;charset=utf-8," + encodeURIComponent(ocelotConfiguration);
        var downloadAnchorNode = document.createElement('a')
        downloadAnchorNode.setAttribute("href", downloadData);
        downloadAnchorNode.setAttribute("download", 'OcelotConfiguration.json');
        downloadAnchorNode.click();
        downloadAnchorNode.remove();
    });
});