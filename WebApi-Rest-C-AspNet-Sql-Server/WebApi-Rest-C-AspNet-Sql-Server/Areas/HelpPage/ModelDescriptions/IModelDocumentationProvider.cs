using System;
using System.Reflection;

namespace WebApi_Rest_C_AspNet_Sql_Server.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}