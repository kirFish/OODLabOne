namespace Lab1
{
    public class TranslatorBroken : ITranslator
    {
        private string name;
        private int translationNumber;
        public TranslatorBroken(ITranslator translator)
        {
            name = "broken";
            translationNumber = 0;
        }

        public string GetName()
        {
            return "broken";
        }

        public int GetMaxLength() => 0;
        public int GetTranslationsLeft() => 0;
        public string TranslateMessage(string message)  => message;
        public TranslatorType GetTranslatorType() => TranslatorType.Broken;
        
        
        
    }
}