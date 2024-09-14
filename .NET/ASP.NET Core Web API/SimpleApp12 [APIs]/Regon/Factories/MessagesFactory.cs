using Regon.ValueObjectsAndTheirExceptions.NazwaRaportuValue;
using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.SilosIdValue;
using Regon.ValueObjectsAndTheirExceptions.TypJednostkiValue;
using System.Reflection;

namespace Regon.Factories
{
    public class MessagesFactory
    {
        private static readonly string _class = "ClassForChanges";
        private static readonly string _method = "MethodForChanges";
        private static readonly string _problemDescription = "Description";
        private static readonly string _inputData = "InputData";
        private static readonly string _classData = "OtherClassDataChanged";

        public static string GenerateExeptionMessageDeserializationProblem(Type classType, MethodBase? method, string inputData)
        {
            return string.Format
                (
                "{0}: {1}; {2}; {3}: {4};",
                _problemDescription,
                Messages.ExceptionMessageDeserializationProblem,
                GenerateClassNameAndMethodName(classType, method),
                _inputData,
                inputData
                );
        }
        public static string GenerateExeptionMessageDeserializationProblemOrHaveNoAcess(Type classType, MethodBase? method, string inputData)
        {
            return string.Format
                (
                "{0}: {1}; {2}; {3}: {4};",
                _problemDescription,
                Messages.ExceptionMessageDeserializationProblemOrHaveNoAcess,
                GenerateClassNameAndMethodName(classType, method),
                _inputData,
                inputData
                );
        }

        //NazwaRaportu
        public static string GenerateExeptionMessageNazwaRaportuChanged(Type classType, MethodBase? method, NazwaRaportu nazwaRaportu)
        {
            return string.Format
                (
                "{0}: {1}; {2}; {3}: {4};",
                _problemDescription,
                Messages.ExeptionMessageClassesChanged,
                GenerateClassNameAndMethodName(classType, method),
                _classData,
                $"{nazwaRaportu.GetType().FullName}:{nazwaRaportu.Name}"
                );
        }

        public static string GenerateExeptionMessageNazwaRaportuNotImplementedValue
            (
            Type classType,
            MethodBase? method,
            TypJednostki typ,
            SilosId silosId
            )
        {
            //Zaistnały zmiany w strukturze klass
            return string.Format
                (
                "{0}: {1}; {2}; {3}: {4};",
                _problemDescription,
                Messages.ExeptionMessageClassesChanged,
                GenerateClassNameAndMethodName(classType, method),
                _classData,
                $"{typ.GetType().FullName}:{typ.Value}, {silosId.GetType().FullName}:{silosId.Value}"
                );
        }

        //UserKey
        public static string GenerateExeptionMessageUserKeyInvalid()
        {
            return $"{Messages.ExceptionMessageUserKeyInvalid};";
        }
        public static string GenerateExeptionMessageUserKeyEmpty()
        {
            return $"{Messages.ExceptionMessageUserKeyEmpty};";
        }
        //
        public static string GenerateExeptionMessageTypJednostkiNewValue(Type classType, MethodBase? method, string value)
        {
            return string.Format
                (
                "{0}: {1}; {2}; {3}: {4};",
                _problemDescription,
                Messages.ExeptionMessageClassesNotImplemented,
                GenerateClassNameAndMethodName(classType, method),
                _inputData,
                value
                );
        }

        public static string GenerateExeptionMessageSilosIdNewValue(Type classType, MethodBase? method, int value)
        {
            return string.Format
                (
                "{0}: {1}; {2}; {3}: {4};",
                _problemDescription,
                Messages.ExeptionMessageClassesNotImplemented,
                GenerateClassNameAndMethodName(classType, method),
                _inputData,
                value
                );
        }

        //Regon
        public static string GenerateExeptionMessageRegonIncorrect(string incorrectRegon)
        {
            return $"{Messages.ExeptionMessageRegonIncorrect}: {incorrectRegon};";
        }

        public static string GenerateExeptionMessageRegonCompanyNotExist(ValueObjectsAndTheirExceptions.RegonValue.Regon regon)
        {
            return $"{Messages.ExeptionMessageRegonCompanyNotExist}: {regon.Number};";
        }
        //Nip
        public static string GenerateExeptionMessageNipIncorrect(string incorrectNip)
        {
            return $"{Messages.ExeptionMessageNipIncorrect}: {incorrectNip};";
        }
        public static string GenerateExeptionMessageNipCompanyNotExist(Nip nip)
        {
            return $"{Messages.ExeptionMessageNipCompanyNotExist}: {nip.Number};";
        }
        //??
        public static string GenerateExeptionMessageCustomDateOnlyIncorrect(string value)
        {
            //dane zwaracane nie w formie datime lub dateonly
            return $"{Messages.ExeptionMessageCustomDateOnlyIncorrect}: {value};";
        }
        public static string GenerateExeptionMessageStructureOfResponseHasChanged(Type classType, MethodBase? method, string response)
        {
            //Struktura zmieniła sie 
            return string.Format
                (
                "{0}: {1}; {2}; {3}: {4};",
                _problemDescription,
                Messages.ExeptionMessageStructureOfResponseHasChanged,
                GenerateClassNameAndMethodName(classType, method),
                _inputData,
                response
                );
        }
        public static string GenerateExeptionMessageDanePelneNewClass(Type classType, MethodBase? method, Type typeClassWhichHasChanged)
        {
            //Struktura zmieniła sie 
            return string.Format
                (
                "{0}: {1}; {2}; {3}: {4};",
                _problemDescription,
                Messages.ExeptionMessageClassesNotImplemented,
                GenerateClassNameAndMethodName(classType, method),
                _classData,
                typeClassWhichHasChanged.FullName
                );
        }
        //=====================================================================================================================================
        //=====================================================================================================================================
        //Private Methods
        //=====================================================================================================================================
        private static string GenerateClassNameAndMethodName(Type classType, MethodBase? method)
        {
            return $"{_class}: {classType.FullName}; {_method}: {(method != null ? method.Name : "None")}";
        }
    }
}
