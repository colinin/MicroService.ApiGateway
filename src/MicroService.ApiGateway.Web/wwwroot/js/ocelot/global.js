layui.use(['inputTags', 'form'], function () {
    var inputTags = layui.inputTags,
        form = layui.form,
        $ = layui.jquery;
    let input = inputTags.render({
        elem: '#inputTags',
        close: true,
        content: ['标题一', '标题二'],
        aldaBtn: false
    });
});