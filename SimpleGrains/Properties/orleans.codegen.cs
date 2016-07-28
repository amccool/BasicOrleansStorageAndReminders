#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.2.2.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("SimpleGrains, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace SimpleGrains
{
    using global::Orleans.Async;
    using global::Orleans;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.2.2.0"), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.SerializerAttribute(typeof (global::SimpleGrains.SimpleStateTestGrainState)), global::Orleans.CodeGeneration.RegisterSerializerAttribute]
    internal class OrleansCodeGenSimpleGrains_SimpleStateTestGrainStateSerializer
    {
        private static readonly global::System.Reflection.FieldInfo field0 = typeof (global::SimpleGrains.SimpleStateTestGrainState).@GetField("MyNumber", (System.@Reflection.@BindingFlags.@Instance | System.@Reflection.@BindingFlags.@NonPublic | System.@Reflection.@BindingFlags.@Public));
        private static readonly global::System.Func<global::SimpleGrains.SimpleStateTestGrainState, global::System.Int32> getField0 = (global::System.Func<global::SimpleGrains.SimpleStateTestGrainState, global::System.Int32>)global::Orleans.Serialization.SerializationManager.@GetGetter(field0);
        private static readonly global::System.Action<global::SimpleGrains.SimpleStateTestGrainState, global::System.Int32> setField0 = (global::System.Action<global::SimpleGrains.SimpleStateTestGrainState, global::System.Int32>)global::Orleans.Serialization.SerializationManager.@GetReferenceSetter(field0);
        [global::Orleans.CodeGeneration.CopierMethodAttribute]
        public static global::System.Object DeepCopier(global::System.Object original)
        {
            global::SimpleGrains.SimpleStateTestGrainState input = ((global::SimpleGrains.SimpleStateTestGrainState)original);
            global::SimpleGrains.SimpleStateTestGrainState result = new global::SimpleGrains.SimpleStateTestGrainState();
            setField0(result, getField0(input));
            global::Orleans.@Serialization.@SerializationContext.@Current.@RecordObject(original, result);
            return result;
        }

        [global::Orleans.CodeGeneration.SerializerMethodAttribute]
        public static void Serializer(global::System.Object untypedInput, global::Orleans.Serialization.BinaryTokenStreamWriter stream, global::System.Type expected)
        {
            global::SimpleGrains.SimpleStateTestGrainState input = (global::SimpleGrains.SimpleStateTestGrainState)untypedInput;
            global::Orleans.Serialization.SerializationManager.@SerializeInner(getField0(input), stream, typeof (global::System.Int32));
        }

        [global::Orleans.CodeGeneration.DeserializerMethodAttribute]
        public static global::System.Object Deserializer(global::System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            global::SimpleGrains.SimpleStateTestGrainState result = new global::SimpleGrains.SimpleStateTestGrainState();
            global::Orleans.@Serialization.@DeserializationContext.@Current.@RecordObject(result);
            setField0(result, (global::System.Int32)global::Orleans.Serialization.SerializationManager.@DeserializeInner(typeof (global::System.Int32), stream));
            return (global::SimpleGrains.SimpleStateTestGrainState)result;
        }

        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.@Register(typeof (global::SimpleGrains.SimpleStateTestGrainState), DeepCopier, Serializer, Deserializer);
        }

        static OrleansCodeGenSimpleGrains_SimpleStateTestGrainStateSerializer()
        {
            Register();
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
