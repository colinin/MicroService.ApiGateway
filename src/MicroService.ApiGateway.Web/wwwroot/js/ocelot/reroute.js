layui.use(['form', 'element'], function () {
    var form = layui.form,
        element = layui.element,
        $ = layui.jquery;

    var _reRouteRoot= microService.apiGateway.ocelot.reRoute;

    var _reRouteLoadService = _reRouteRoot.get;
    let _reRouteEditService;

    form.on('submit(btnSave)', function (data) {
        _reRouteEditService = $('#ReRouteId').val() == 0
            ? _reRouteRoot.create
            : _reRouteRoot.update;
        let submitDto = {
            reRouteId: $('#ReRouteId').val(),
            reRouteName: data.field.ReRouteName,
            downstreamPathTemplate: data.field.DownstreamPathTemplate,
            upstreamPathTemplate: data.field.UpstreamPathTemplate,
            upstreamHttpMethod: data.field.UpstreamHttpMethod,
            addHeadersToRequest: data.field.AddHeadersToRequest,
            upstreamHeaderTransform: data.field.UpstreamHeaderTransform,
            downstreamHeaderTransform: data.field.DownstreamHeaderTransform,
            downstreamHostAndPorts: data.field.DownstreamHostAndPorts,
            addClaimsToRequest: data.field.AddClaimsToRequest,
            routeClaimsRequirement: "",
            addQueriesToRequest: data.field.AddQueriesToRequest,
            requestIdKey: data.field.RequestIdKey,
            reRouteIsCaseSensitive: true,
            serviceName: data.field.ServiceName,
            downstreamScheme: data.field.DownstreamScheme,
            httpHandlerOptions: {
                allowAutoRedirect: true,
                useCookieContainer: true,
                useTracing: true,
                useProxy: true
            },
            loadBalancerOptions: {
                type: data.field.Type
            },
            rateLimitOptions: {
                clientWhitelist: data.field.ClientWhitelist.split(","),
                enableRateLimiting: $("input[name='EnableRateLimiting']:checked").val() === "on",
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
            dangerousAcceptAnyServerCertificateValidator: $("input[name='CertificateValidator']:checked").val() === "on"
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
                    //http
                    'UpstreamHeaderTransform': result.upstreamHeaderTransform,
                    'DownstreamHeaderTransform': result.downstreamHeaderTransform,
                    'AddHeadersToRequest': result.addHeadersToRequest,
                    'AddClaimsToRequest': result.addClaimsToRequest,
                    'AddQueriesToRequest': result.addQueriesToRequest,
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