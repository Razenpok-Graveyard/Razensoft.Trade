using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Razensoft.Trade.Pine
{
    public class BuiltinFunction : PineScriptFunction
    {
        private readonly MethodInfo _methodInfo;
        private readonly object _provider;

        public BuiltinFunction(MethodInfo methodInfo, object provider) : base(methodInfo.Name.Replace("__", "."))
        {
            _methodInfo = methodInfo;
            _provider = provider;
        }

        public override bool CanAcceptAsIs(object[] positionalArgs, Dictionary<string, object> namedArgs)
        {
            static bool IsAssignable(object arg, ParameterInfo parameterInfo)
            {
                var argType = arg.GetType();
                var parameterType = parameterInfo.ParameterType;
                return parameterType == typeof(object) || argType == parameterType;
            }
            
            var parameters = _methodInfo.GetParameters();
            var implicitArgs = parameters.ToList();
            for (int i = 0; i < positionalArgs.Length; i++)
            {
                var parameter = parameters[i];
                if (!IsAssignable(positionalArgs[i], parameter))
                {
                    return false;
                }
                implicitArgs.Remove(parameter);
            }

            foreach (var (name, value) in namedArgs)
            {
                var parameter = implicitArgs.Find(a => a.Name == name);
                if (parameter == null || !IsAssignable(value, parameter))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool CanAccept(object[] positionalArgs, Dictionary<string, object> namedArgs)
        {
            static bool IsAssignable(object arg, ParameterInfo parameterInfo)
            {
                var argType = arg.GetType();
                var parameterType = parameterInfo.ParameterType;
                return parameterType == typeof(object) || argType == parameterType || PineTypeSystem.IsConvertible(argType, parameterType);
            }

            var parameters = _methodInfo.GetParameters();
            var implicitArgs = parameters.ToList();
            for (int i = 0; i < positionalArgs.Length; i++)
            {
                if (!IsAssignable(positionalArgs[i], parameters[i]))
                {
                    return false;
                }
                implicitArgs.Remove(parameters[i]);
            }

            foreach (var (name, value) in namedArgs)
            {
                var parameter = implicitArgs.Find(a => a.Name == name);
                if (parameter == null || !IsAssignable(value, parameter))
                {
                    return false;
                }
            }

            return true;
        }

        public override object Execute(PineScriptExecutionContext parentContext, object[] positionalArgs, Dictionary<string, object> namedArgs)
        {
            var parameters = _methodInfo.GetParameters();
            var args = ConstructArguments(positionalArgs, namedArgs)
                .Select((arg, i) =>
                {
                    if (arg == null) return arg;
                    var argType = arg.GetType();
                    var parameterType = parameters[i].ParameterType;
                    if (parameterType == typeof(object) || argType == parameterType)
                    {
                        return arg;
                    }

                    if (PineTypeSystem.IsConvertible(argType, parameterType))
                    {
                        return PineTypeSystem.Convert(arg, parameterType);
                    }

                    throw new Exception($"Cannot cast {argType} to {parameterType}");
                })
                .ToArray();

            try
            {
                return _methodInfo.Invoke(_provider, args);
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        private object[] ConstructArguments(object[] positionalArgs, Dictionary<string, object> namedArgs)
        {
            var argMap = new Dictionary<string, object>();
            var parameters = _methodInfo.GetParameters();
            var implicitArgs = parameters.ToList();
            for (int i = 0; i < positionalArgs.Length; i++)
            {
                var parameter = parameters[i];
                var value = positionalArgs[i];
                argMap.Add(parameter.Name, value);
                implicitArgs.Remove(parameter);
            }

            foreach (var (name, value) in namedArgs)
            {
                var arg = implicitArgs.Find(a => a.Name == name);
                if (arg == null)
                {
                    throw new Exception($"Unknown function argument \"{name}\" in function \"{Name}\"");
                }
                argMap.Add(name, value);
                implicitArgs.Remove(arg);
            }

            foreach (var arg in implicitArgs)
            {
                object value = null;
                if (arg.HasDefaultValue)
                {
                    value = arg.DefaultValue;
                }
                if (arg.ParameterType.IsValueType)
                {
                    value = Activator.CreateInstance(arg.ParameterType);
                }
                argMap.Add(arg.Name, value);
            }


            return parameters
                .Select(parameter => argMap[parameter.Name])
                .ToArray();
        }
    }
}