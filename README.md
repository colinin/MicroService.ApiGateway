""abp framework & ocelot ui manager"  ABP vNext 自用API网关,正在不定期编写中" 

1、实现图形化管理
2、后台服务后期会分离为单独的微服务，与UI隔离


前端框架：

LayUi：https://github.com/sentsin/layui

后端依赖框架：

ABP：https://github.com/abpframework/abp

CAP：https://github.com/dotnetcore/CAP

其中实体标识采用的CAP中的雪花算法生成

【2019-06-11】
1、集成CAP实现Ocelot服务修改/创建同步变更网关配置(需配置RabbitMQ)。