layui.use([ 'form'], function () {
    var form = layui.form,
        $ = layui.jquery;

    var _globalService = microService.apiGateway.ocelot.globalConfiguration;

    var _itemId = 0;

    $(function () {
        _globalService.get().done(function (result) {
            console.log(result);
            _itemId = result.itemId ? result.itemId :0;
            form.val('GlobalCfg', {
                'ItemId': result.itemId,
                'BaseUrl': result.baseUrl,
                'RequestIdKey': result.requestIdKey,
                'DownstreamScheme': result.downstreamScheme,
                'ExceptionsAllowedBeforeBreaking': result.qoSOptions.exceptionsAllowedBeforeBreaking,
                'DurationOfBreak': result.qoSOptions.durationOfBreak,
                'TimeoutValue': result.qoSOptions.timeoutValue,
                'ClientIdHeader': result.rateLimitOptions.clientIdHeader,
                'QuotaExceededMessage': result.rateLimitOptions.quotaExceededMessage,
                'HttpStatusCode': result.rateLimitOptions.httpStatusCode,
                'DisableRateLimitHeaders': result.rateLimitOptions.disableRateLimitHeaders,
                'AllowAutoRedirect': result.httpHandlerOptions.allowAutoRedirect,
                'UseCookieContainer': result.httpHandlerOptions.useCookieContainer,
                'UseProxy': result.httpHandlerOptions.useProxy,
                'UseTracing': result.httpHandlerOptions.useTracing,
                'Type': result.loadBalancerOptions.type,
                'ServiceType': result.serviceDiscoveryProvider.type,
                'Host': result.serviceDiscoveryProvider.host,
                'Port': result.serviceDiscoveryProvider.port,
            });
        });
    });

    form.on('submit(btnSave)', function (data) {
        let _globalStore = _itemId === 0 ? _globalService.create : _globalService.update;

        _globalStore({
            itemId: data.field.ItemId,
            baseUrl: data.field.BaseUrl,
            requestIdKey: data.field.RequestIdKey,
            downstreamScheme: data.field.DownstreamScheme,
            qoSOptions: {
                exceptionsAllowedBeforeBreaking: data.field.ExceptionsAllowedBeforeBreaking,
                durationOfBreak: data.field.DurationOfBreak,
                timeoutValue: data.field.TimeoutValue
            },
            rateLimitOptions: {
                clientIdHeader: data.field.ClientIdHeader,
                quotaExceededMessage: data.field.QuotaExceededMessage,
                httpStatusCode: data.field.HttpStatusCode,
                disableRateLimitHeaders: data.field.DisableRateLimitHeaders === "on"
            },
            httpHandlerOptions: {
                allowAutoRedirect: data.field.AllowAutoRedirect === "on",
                useCookieContainer: data.field.UseCookieContainer === "on",
                useProxy: data.field.UseProxy === "on",
                useTracing: data.field.UseTracing === "on"
            },
            loadBalancerOptions: {
                type: data.field.Type
            },
            serviceDiscoveryProvider: {
                type: data.field.ServiceType,
                host: data.field.Host,
                port: data.field.Port
            }
        }).done(function (result) {
            console.log(result);
            abp.notify.success('保存成功!');
        });

        return false;
    });
});