using System.Reflection;
using System.Reflection.Emit;

namespace Reflection.Task4
{
    /// <summary>
    /// Performs dynamic build operations.
    /// </summary>
    internal class DynamicTypeBuilder
    {
        /// <summary>
        /// Dynamically builds assembly, module and type and displays the value to user.
        /// </summary>
        internal void Build()
        {
            AssemblyName assembly = new AssemblyName("DynamicAssembly");

            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);
            typeBuilder.DefineField("DynamicField", typeof(string), FieldAttributes.Public);

            Type? dynamicType = typeBuilder.CreateType();
            if (dynamicType is null)
            {
                return;
            }

            object? newObject = Activator.CreateInstance(dynamicType);
            FieldInfo? field = dynamicType.GetField("DynamicField");
            if (field != null)
            {
                field.SetValue(newObject, "Hello World");
                Console.WriteLine(field.GetValue(newObject));
            }

            ConsoleHelper.CleanConsole();
        }
    }
}
