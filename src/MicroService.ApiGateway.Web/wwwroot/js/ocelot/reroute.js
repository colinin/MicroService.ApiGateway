layui.use(['form', 'element'], function () {
    var form = layui.form,
        element = layui.element,
        $ = layui.jquery;

    $(function () {
        $('#UpstreamHttpMethodItems').tagsinput();
    });
});