using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public interface ITranslator
    {
        public string GetName();
        public int GetMaxLength();
        public TranslatorType GetTranslatorType();
        public string TranslateMessage(string message);
        public int GetTranslationsLeft();
    }
}