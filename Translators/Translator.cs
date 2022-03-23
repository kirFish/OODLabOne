using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Translator : ITranslator
    {
        private readonly string _name;
        private readonly int _translationNumber;

        public string GetName()
        {
            return _name;
        }

        public int GetMaxLength()
        {
            return 30;
        }

        public TranslatorType GetTranslatorType()
        {
            return TranslatorType.Ordinary;
        }

        public string TranslateMessage(string message)
        {
            if (_i++ < _translationNumber)
            {
                if (message.Length > GetMaxLength())
                    return message.Substring(0, GetMaxLength());
                return message;
            }

            return "";
        }

        private int _i;

        public Translator(string name, int translationNumber)
        {
            _name = name + " translator";
            _translationNumber = translationNumber;
        }

        public int GetTranslationsLeft()
        {
            return _translationNumber - _i;
        }
    }
}