#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.2.2.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("SimpleGrainsInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace Rb.Nci.Actor.FacilityGrainsInterface
{
    using global::Orleans.Async;
    using global::Orleans;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.2.2.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::Rb.Nci.Actor.FacilityGrainsInterface.ITemporaryAceForReminderTest))]
    internal class OrleansCodeGenTemporaryAceForReminderTestReference : global::Orleans.Runtime.GrainReference, global::Rb.Nci.Actor.FacilityGrainsInterface.ITemporaryAceForReminderTest
    {
        protected @OrleansCodeGenTemporaryAceForReminderTestReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenTemporaryAceForReminderTestReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return 722032349;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::Rb.Nci.Actor.FacilityGrainsInterface.ITemporaryAceForReminderTest";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == 722032349;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case 722032349:
                    switch (@methodId)
                    {
                        case 777405116:
                            return "DoSomethingThatTriggersReminder";
                        case -474922990:
                            return "DidTheReminderFire";
                        case -1637950409:
                            return "UnregisterReminder";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + 722032349 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @DoSomethingThatTriggersReminder()
        {
            return base.@InvokeMethodAsync<global::System.Object>(777405116, null);
        }

        public global::System.Threading.Tasks.Task<global::System.Boolean> @DidTheReminderFire()
        {
            return base.@InvokeMethodAsync<global::System.Boolean>(-474922990, null);
        }

        public global::System.Threading.Tasks.Task @UnregisterReminder()
        {
            return base.@InvokeMethodAsync<global::System.Object>(-1637950409, null);
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.2.2.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::Rb.Nci.Actor.FacilityGrainsInterface.ITemporaryAceForReminderTest", 722032349, typeof (global::Rb.Nci.Actor.FacilityGrainsInterface.ITemporaryAceForReminderTest)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenTemporaryAceForReminderTestMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::Orleans.CodeGeneration.InvokeMethodRequest @request)
        {
            global::System.Int32 interfaceId = @request.@InterfaceId;
            global::System.Int32 methodId = @request.@MethodId;
            global::System.Object[] arguments = @request.@Arguments;
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case 722032349:
                        switch (methodId)
                        {
                            case 777405116:
                                return ((global::Rb.Nci.Actor.FacilityGrainsInterface.ITemporaryAceForReminderTest)@grain).@DoSomethingThatTriggersReminder().@Box();
                            case -474922990:
                                return ((global::Rb.Nci.Actor.FacilityGrainsInterface.ITemporaryAceForReminderTest)@grain).@DidTheReminderFire().@Box();
                            case -1637950409:
                                return ((global::Rb.Nci.Actor.FacilityGrainsInterface.ITemporaryAceForReminderTest)@grain).@UnregisterReminder().@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + 722032349 + ",methodId=" + methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return 722032349;
            }
        }
    }
}

namespace SimpleGrainsInterface
{
    using global::Orleans.Async;
    using global::Orleans;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.2.2.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::SimpleGrainsInterface.ISimpleStateTestGrain))]
    internal class OrleansCodeGenSimpleStateTestGrainReference : global::Orleans.Runtime.GrainReference, global::SimpleGrainsInterface.ISimpleStateTestGrain
    {
        protected @OrleansCodeGenSimpleStateTestGrainReference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenSimpleStateTestGrainReference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return -427915147;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::SimpleGrainsInterface.ISimpleStateTestGrain";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == -427915147;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case -427915147:
                    switch (@methodId)
                    {
                        case 1477117189:
                            return "SetTheNumber";
                        case -1795044861:
                            return "GetTheNumber";
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -427915147 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task @SetTheNumber(global::System.Int32 @theNumber)
        {
            return base.@InvokeMethodAsync<global::System.Object>(1477117189, new global::System.Object[]{@theNumber});
        }

        public global::System.Threading.Tasks.Task<global::System.Int32> @GetTheNumber()
        {
            return base.@InvokeMethodAsync<global::System.Int32>(-1795044861, null);
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.2.2.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::SimpleGrainsInterface.ISimpleStateTestGrain", -427915147, typeof (global::SimpleGrainsInterface.ISimpleStateTestGrain)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenSimpleStateTestGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::Orleans.CodeGeneration.InvokeMethodRequest @request)
        {
            global::System.Int32 interfaceId = @request.@InterfaceId;
            global::System.Int32 methodId = @request.@MethodId;
            global::System.Object[] arguments = @request.@Arguments;
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case -427915147:
                        switch (methodId)
                        {
                            case 1477117189:
                                return ((global::SimpleGrainsInterface.ISimpleStateTestGrain)@grain).@SetTheNumber((global::System.Int32)arguments[0]).@Box();
                            case -1795044861:
                                return ((global::SimpleGrainsInterface.ISimpleStateTestGrain)@grain).@GetTheNumber().@Box();
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -427915147 + ",methodId=" + methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return -427915147;
            }
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
