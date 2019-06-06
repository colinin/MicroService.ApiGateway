layui.use(['table', 'form'], function () {
    let table = layui.table,
        form = layui.form;

    let reRouteTable = table.render({
        elem: '#ReRoutesTable'
        , id: "routeTable"
        , toolbar: '#toolbarOpera'
        , height: '740px'
        , page: true
        , limit: 100
        , limits: [50, 100, 200, 500, 1000]
        , request: {
            pageName: 'skipCount',
            limitName: 'maxResultCount'
        }
        , parseData: function (res) {
            return {
                "code": 0,
                "msg": "",
                "count": res.totalCount,
                "data": res.items
            };
        }
        , url: '../../ReRoute/GetPagedList'
        , cols: [[
            { type: 'radio', fixed: 'left' }
            , { field: 'reRouteName', title: '路由名称', width: 130 }
            , { field: 'upstreamPathTemplate', title: '上游请求地址', width: 130 }
            , {
                field: 'upstreamHttpMethod',
                title: '上游请求方式',
                width: 200,
                unresize: true,
                sort: false,
                templet: function (d) {
                    if (typeof d.upstreamHttpMethod === 'array') {
                        return d.upstreamHttpMethod.join(";")
                    }
                    return d.upstreamHttpMethod;
                }
            }
            , { field: 'downstreamPathTemplate', title: '下游跳转地址', width: 200 }
            , { field: 'downstreamScheme', title: '下游请求协议', width: 200}
            , {
                field: 'downstreamHostAndPorts',
                title: '下游服务地址',
                width: 200,
                templet: function (d) {
                    if (typeof d.downstreamHostAndPorts === 'array') {
                        var result = "";
                        d.downstreamHostAndPorts.forEach(x => result += x.host + ":" + x.port + ";");
                        return result;
                    }
                    return d.downstreamHostAndPorts;
                }
            }
            , { field: 'reRouteIsCaseSensitive', title: '区分大小写', width: 110}
            , { field: 'serviceName', title: '服务发现名称', width: 110}
            , {
                field: 'loadBalancer',
                title: '负载均衡算法',
                width: 125,
                sort: true,
                templet: function (d) {
                    return d.loadBalancerOptions.type;
                }
            }
            , {
                field: 'exceptionsAllowed',
                title: '允许异常次数',
                width: 180,
                templet: function (d) {
                    return d.qoSOptions.exceptionsAllowedBeforeBreaking;
                }
            }
            , {
                field: 'durationOfBreak',
                title: '熔断时间',
                width: 200,
                templet: function (d) {
                    return d.qoSOptions.durationOfBreak;
                }
            }
            , {
                field: 'timeoutValue',
                title: '下游请求超时时间',
                width: 200,
                templet: function (d) {
                    return d.qoSOptions.timeoutValue;
                }
            }
            , {
                field: 'enableRateLimiting',
                title: '是否限流',
                width: 150,
                templet: function (d) {
                    return '<input type="checkbox" disabled title="是否限流"  {{ d.rateLimitOptions.enableRateLimiting ? "checked" : "" }}>';
                }
            }
            , {
                field: 'limit',
                title: '最大请求数量',
                width: 250,
                sort: true,
                templet: function (d) {
                    return d.rateLimitOptions.limit;
                }
            }
        ]]
        , done: function (res, curr, count) {
            if (count > 0) {
                $('.layui-btn-danger:not(.disbledBtn)').removeAttr('hidden');
            } else {
                $('.layui-btn-danger:not(.disbledBtn)').attr('hidden');
            }
        }
    });

    table.on('radio(reroute)', function (obj) {
        var checkStatus = table.checkStatus('routeTable');
        if (checkStatus.data.length === 1) {
            $('.layui-btn-disabled').removeAttr('disabled');
            $('#editRoute').removeClass('layui-btn-disabled').addClass('layui-btn-normal');
            $('#removeRoute').removeClass('layui-btn-disabled').addClass('layui-btn-danger');
        }else {
           
            $('#editRoute').removeClass('layui-btn-normal').addClass('layui-btn-disabled');
            $('#removeRoute').removeClass('layui-btn-danger').addClass('layui-btn-disabled');
            $('.layui-btn-disabled').attr('disabled');
        }
    });

    table.on('toolbar(reroute)', function (obj) {
        var checkStatus = table.checkStatus('routeTable');
        switch (obj.event) {
            case 'refresh':
                refreshReRouteTable(1);
                break;
            case 'add':
                /// TODO:增加路由
                layer.open({
                    type: 2,
                    title: '增加路由',
                    scrollbar: false,
                    area: ['920px', '600px'],
                    content: 'ReRoute'
                }); 
                break;
            case 'edit':
                layer.open({
                    type: 2,
                    title: '编辑路由',
                    scrollbar: false,
                    area: ['920px', '600px'],
                    content: 'ReRoute',
                    success: function (layero, index) {
                        var body = layer.getChildFrame('body', index);
                        body.find('#ReRouteId').val(checkStatus.data[0].reRouteId);
                    }
                }); 
                break;
            case 'remove':
                abp.message.confirm("请确认是否继续", '将删除选定的路由', function (result) {
                    if (result) {
                        // TODO: 删除选择的路由
                    }
                });
                break;
            case 'removeAll':
                abp.message.confirm("请确认是否继续", '将删除所有路由', function (result) {
                    if (result) {
                        // TODO: 删除所有路由
                    }
                });
                //layer.msg('删除所有');
                break;
        };
    });

    function refreshReRouteTable(pageNumber) {
        if (!pageNumber) {
            pageNumber = 1;
        }
        reRouteTable.reload({
            page: {
                curr: pageNumber
            }
        });
    }
});