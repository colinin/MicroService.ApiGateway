layui.use(['table', 'form'], function () {
    let table = layui.table,
        form = layui.form;
    let _rerouteService = microService.apiGateway.ocelot.reRoute;
    let _abpUiLocalizer = abp.localization.getResource('AbpUi');
    let _localizer = abp.localization.getResource('ApiGateway');

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
            , { field: 'reRouteName', title: _localizer('RouteName'), width: 130 }
            , { field: 'upstreamPathTemplate', title: _localizer('UpstreamPathTemplate'), width: 130 }
            , {
                field: 'upstreamHttpMethod',
                title: _localizer('UpstreamHttpMethod'),
                width: 200,
                unresize: true,
                sort: false
            }
            , { field: 'downstreamPathTemplate', title: _localizer('DownstreamPathTemplate'), width: 200 }
            , { field: 'downstreamScheme', title: _localizer('DownstreamScheme'), width: 200}
            , {
                field: 'downstreamHostAndPorts',
                title: _localizer('DownstreamHostAndPorts'),
                width: 200
            }
            , { field: 'reRouteIsCaseSensitive', title: _localizer('CaseSensitive'), width: 110}
            , { field: 'serviceName', title: _localizer('ServiceName'), width: 110}
            , {
                field: 'loadBalancer',
                title: _localizer('LoadBalancer'),
                width: 125,
                sort: true,
                templet: function (d) {
                    return d.loadBalancerOptions.type;
                }
            }
            , {
                field: 'exceptionsAllowed',
                title: _localizer('ExceptionsAllowedBeforeBreaking'),
                width: 180,
                templet: function (d) {
                    return d.qoSOptions.exceptionsAllowedBeforeBreaking;
                }
            }
            , {
                field: 'durationOfBreak',
                title: _localizer('DurationOfBreak'),
                width: 200,
                templet: function (d) {
                    return d.qoSOptions.durationOfBreak;
                }
            }
            , {
                field: 'timeoutValue',
                title: _localizer('TimeoutValue'),
                width: 200,
                templet: function (d) {
                    return d.qoSOptions.timeoutValue;
                }
            }
            , {
                field: 'enableRateLimiting',
                title: _localizer('EnableRateLimiting'),
                width: 150,
                templet: function (d) {
                    var checked = d.rateLimitOptions.enableRateLimiting ? "checked='checked'" : "";
                    var title = _localizer('EnableRateLimiting');
                    return '<input type="checkbox" title=' + title + ' ' + checked + '>';
                }
            }
            , {
                field: 'limit',
                title: _localizer('Limit'),
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
                layer.open({
                    type: 2,
                    title: _localizer('AddReoute'),
                    scrollbar: false,
                    area: ['920px', '600px'],
                    content: 'ReRoute'
                }); 
                break;
            case 'edit':
                layer.open({
                    type: 2,
                    title: _localizer('EditRoute'),
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
                abp.message.confirm(_localizer('WellDeleteSelection'), _abpUiLocalizer('AreYouSure'), function (result) {
                    if (result) {
                        // TODO: 删除选择的路由
                        _rerouteService.delete(checkStatus.data[0].reRouteId)
                            .done(function (result) {
                                console.log(result);
                                refreshReRouteTable();
                            });
                    }
                });
                break;
            case 'removeAll':
                abp.message.confirm(_localizer('WellDeleteAll'), _abpUiLocalizer('AreYouSure'), function (result) {
                    if (result) {
                        // TODO: 删除所有路由
                        _rerouteService.remove()
                            .done(function (result) {
                                console.log(result);
                                refreshReRouteTable();
                            });
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