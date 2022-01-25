using System;

using R5T.L0011.T001;
using R5T.L0011.T002;
using R5T.T0034;
using R5T.T0035;
using R5T.T0036;
using R5T.T0060;


namespace R5T.T0045.X002
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static ICompilationUnitGenerator CompilationUnitGenerator { get; } = T0045.CompilationUnitGenerator.Instance;
        public static ICompilationUnitOperator CompilationUnitOperator { get; } = T0045.CompilationUnitOperator.Instance;
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static IInterfaceGenerator InterfaceGenerator { get; } = T0045.InterfaceGenerator.Instance;
        public static IInterfaceName InterfaceName { get; } = T0036.InterfaceName.Instance;
        public static IMethodGenerator MethodGenerator { get; } = T0045.MethodGenerator.Instance;
        public static IMethodName MethodName { get; } = T0036.MethodName.Instance;
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
        public static INamespaceGenerator NamespaceGenerator { get; } = T0045.NamespaceGenerator.Instance;
        public static INamespaceName NamespaceName { get; } = T0035.NamespaceName.Instance;
        public static IParameterGenerator ParameterGenerator { get; } = T0045.ParameterGenerator.Instance;
        public static IParameterName ParameterName { get; } = T0036.ParameterName.Instance;
        public static IStatementGenerator StatementGenerator { get; } = T0045.StatementGenerator.Instance;
        public static ISelector Selector { get; } = T0060.Selector.Instance;
        public static ISyntax Syntax { get; } = L0011.T002.Syntax.Instance;
        public static ISyntaxFactory SyntaxFactory { get; } = L0011.T001.SyntaxFactory.Instance;
        public static ITypeName TypeName { get; } = T0034.TypeName.Instance;
    }
}
