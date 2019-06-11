layui.use(['form', 'element'], function () {
    var form = layui.form,
        element = layui.element,
        $ = layui.jquery;

    var _reRouteRoot= microService.apiGateway.ocelot.reRoute;

    var _reRouteLoadService = _reRouteRoot.get;
    let _reRouteEditService;

    form.on('submit(btnSave)', function (data) {
        console.log(data.field);
        _reRouteEditService = data.field.ReRouteId == 0
            ? _reRouteRoot.create
            : _reRouteRoot.update;
        let submitDto = {
            reRouteId: data.field.ReRouteId,
            reRouteName: data.field.ReRouteName,
            downstreamPathTemplate: data.field.DownstreamPathTemplate,
            upstreamPathTemplate: data.field.UpstreamPathTemplate,
            upstreamHttpMethod: data.field.UpstreamHttpMethod,
            addHeadersToRequest: data.field.AddHeadersToRequest,
            upstreamHeaderTransform: data.field.UpstreamHeaderTransform,
            downstreamHeaderTransform: data.field.DownstreamHeaderTransform,
            downstreamHostAndPorts: data.field.DownstreamHostAndPorts,
            addClaimsToRequest: data.field.AddClaimsToRequest,
            routeClaimsRequirement: data.field.RouteClaimsRequirement,
            addQueriesToRequest: data.field.AddQueriesToRequest,
            requestIdKey: data.field.RequestIdKey,
            reRouteIsCaseSensitive: data.field.CaseSensitive === 'on',
            serviceName: data.field.ServiceName,
            downstreamScheme: data.field.DownstreamScheme,
            timeout: data.field.ReRouteTimeOut,
            key: data.field.AggregateKey,
            priority: data.field.Priority,
            httpHandlerOptions: {
                allowAutoRedirect: data.field.AllowAutoRedirect === "on",
                useCookieContainer: data.field.UseCookieContainer === "on",
                useTracing: data.field.UseTracing === "on",
                useProxy: data.field.UseProxy === "on"
            },
            loadBalancerOptions: {
                type: data.field.Type
            },
            rateLimitOptions: {
                clientWhitelist: data.field.ClientWhitelist.split(","),
                enableRateLimiting: data.field.EnableRateLimiting === "on",
                limit: data.field.Limit,
                period: data.field.Period,
                periodTimespan: data.field.PeriodTimespan
            },
            qoSOptions: {
                exceptionsAllowedBeforeBreaking: data.field.ExceptionsAllowedBeforeBreaking,
                durationOfBreak: data.field.DurationOfBreak,
                timeoutValue: data.field.TimeoutValue
            },
            securityOptions: {
                ipAllowedList: data.field.IpAllowedList.split(","),
                ipBlockedList: data.field.IpBlockedList.split(",")
            },
            authenticationOptions: {
                allowedScopes: data.field.AllowedScopes.split(","),
                authenticationProviderKey: data.field.AuthenticationProviderKey
            },
            dangerousAcceptAnyServerCertificateValidator: data.field.CertificateValidator === "on"
        };

        _reRouteEditService(submitDto).done(function (result) {
            console.log(result);
            abp.notify.success('保存成功!');
        });
        return false;
    });

    function refreshTagsInput() {
        $('.tags-input').tagsinput();
    }

    $(function(){
        _reRouteLoadService($('#ReRouteId').val())
            .done(function (result) {
                form.val('ReRouteCfg', {
                    //basic
                    'ReRouteId': result.reRouteId,
                    'ReRouteName': result.reRouteName,
                    'ServiceName': result.serviceName,
                    'UpstreamPathTemplate': result.upstreamPathTemplate,
                    'DownstreamPathTemplate': result.downstreamPathTemplate,
                    'UpstreamHttpMethod': result.upstreamHttpMethod,
                    'DownstreamHostAndPorts': result.downstreamHostAndPorts,
                    'DownstreamScheme': result.downstreamScheme,
                    'RequestIdKey': result.requestIdKey,
                    'CertificateValidator': result.dangerousAcceptAnyServerCertificateValidator,
                    'AggregateKey': result.key,
                    'Priority': result.priority,
                    'CaseSensitive': result.reRouteIsCaseSensitive,
                    'RouteClaimsRequirement': result.routeClaimsRequirement,
                    'ReRouteTimeOut': result.timeout,
                    //http
                    'UpstreamHeaderTransform': result.upstreamHeaderTransform,
                    'DownstreamHeaderTransform': result.downstreamHeaderTransform,
                    'AddHeadersToRequest': result.addHeadersToRequest,
                    'AddClaimsToRequest': result.addClaimsToRequest,
                    'AddQueriesToRequest': result.addQueriesToRequest,
                    'AllowAutoRedirect': result.httpHandlerOptions.allowAutoRedirect,
                    'UseCookieContainer': result.httpHandlerOptions.useCookieContainer,
                    'UseProxy': result.httpHandlerOptions.useProxy,
                    'UseTracing': result.httpHandlerOptions.useTracing,
                    //ratelimit
                    'ClientWhitelist': result.rateLimitOptions.clientWhitelist.join(','),
                    'EnableRateLimiting': result.rateLimitOptions.enableRateLimiting,
                    'Period': result.rateLimitOptions.period,
                    'PeriodTimespan': result.rateLimitOptions.periodTimespan,
                    'Limit': result.rateLimitOptions.limit,
                    //qos
                    'ExceptionsAllowedBeforeBreaking': result.qoSOptions.exceptionsAllowedBeforeBreaking,
                    'DurationOfBreak': result.qoSOptions.durationOfBreak,
                    'TimeoutValue': result.qoSOptions.timeoutValue,
                    'Type': result.loadBalancerOptions.type,
                    //security
                    'AuthenticationProviderKey': result.authenticationOptions.authenticationProviderKey,
                    'AllowedScopes': result.authenticationOptions.allowedScopes.join(','),
                    'IpAllowedList': result.securityOptions.ipAllowedList.join(','),
                    'IpBlockedList': result.securityOptions.ipBlockedList.join(',')
                });
                refreshTagsInput();
            });
    });
});