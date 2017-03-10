using System;
using System.Diagnostics;
using System.Reflection;

namespace NotEvil
{
    public static class SomeClass
    {
        public static bool SomeAction() {

            foreach (var type in typeof(int).GetTypeInfo().Assembly.GetTypes())
            {
                MessUpReadOnlyValues(type);
            }

            return true;
        }

        private static void MessUpReadOnlyValues(Type type)
        {
            // Avoid generic classes
            if (type.GetGenericArguments().Length != 0)
                return;

            // Prevent a Crash
            if (type.FullName == "System.Diagnostics.Tracing.FrameworkEventSource")
                return;

            FieldInfo[] fields = type.GetFields();

            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];

                if (field.IsStatic && field.IsInitOnly)
                {
                    object oldValue = field.GetValue(null);
                    field.SetValue(null, null);
                    object newValue = field.GetValue(null);

                    Debug.WriteLine($"Changed {oldValue} to {newValue}");
                }
            }
        }
    }
}
