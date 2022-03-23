using System;

namespace Lab1
{
    public static class TranslatorManipulator
    {
        public static ITranslator SetTranslatorToBroken(ITranslator translator, string message)
        {
            TranslatorBroken broken = new TranslatorBroken(translator);
            return broken;
        }
        
        public static ITranslator MakeTranslatorSmart(ITranslator translator)
        {
            //TODO
            throw new NotImplementedException();
        }
        
        public static ITranslator EncryptMessages(ITranslator translator, int offset, int maxCallsNumber)
        {
            //TODO
            throw new NotImplementedException();
        }
        
        public static ITranslator DecryptMessages(ITranslator translator, int offset)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}