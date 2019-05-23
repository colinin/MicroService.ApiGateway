namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Layui.Bundling
{
    public static class LayuiThemeBundles
    {
        public static class Styles
        {
            public const string Global = "Layui.Global";

            public const string Empty = "Layui.Empty";

            public const string TableFilter = "Layui.TableFilter";

            public const string SoulTable = "Layui.SoulTable";

            public const string InputTags = "Layui.InputTags";
        }

        public static class Scripts
        {
            public const string Global = "Layui.Global";

            public const string Empty = "Layui.Empty";
            /// <summary>
            /// Layui模块化设计可以不需要引用JS文件,框架会自行搜索引用JS,但是css文件必须引用
            /// </summary>
            public const string TableFilter = "Layui.TableFilter";
            /// <summary>
            /// Layui模块化设计可以不需要引用JS文件,框架会自行搜索引用JS,但是css文件必须引用
            /// </summary>
            public const string SoulTable = "Layui.SoulTable";
        }
    }
}
