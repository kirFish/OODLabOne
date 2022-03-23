using System;
using tm = Lab1.TranslatorManipulator;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITranslator[] translators =
            {
               new Translator("First" ,5),
               new Translator("Second",5),
               new Translator("Third" ,5),
               new Translator("Spare" ,4),
               new Translator("Fourth",5),
               new Translator("Fast",100),
               new Translator("Old",20),
               new Translator("Rapid" ,30),
               new Translator("Square",40)
            };
			
			ITranslator[] translatorsDatabase =
            {
               new Translator("First" ,5),
               new Translator("Second",5),
               new Translator("Third" ,5),
               new Translator("Spare" ,4),
               new Translator("Fourth",5),
               new Translator("Fast",100),
               new Translator("Old",20),
               new Translator("Rapid" ,30),
               new Translator("Square",40)
            };

            foreach (var node in translators)
            {
                TestPrintTranslator(node, 0 ,"");
            }

            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SmartTranslator\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintTranslator(translators[0],1, "While a book has got to be worthwhile from the point of view of the reader it's got to be worthwhile from the point of view of the writer as well");
                translators[0] = tm.MakeTranslatorSmart(translators[0]);
                TestPrintTranslator(translators[0], 4, "While a book has got to be worthwhile from the point of view of the reader it's got to be worthwhile from the point of view of the writer as well");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BrokenTranslator\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintTranslator(translators[1],1, "Cras a ullamcorper risus. Vivamus elementum");
                translators[1] = tm.SetTranslatorToBroken(translators[1], "testing");
                TestPrintTranslator(translators[1],3, "Cras a ullamcorper risus. Vivamus elementum");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EncryptionTranslator\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintTranslator(translators[2],1, "It is well known that a vital ingredient of success is not knowing that what you're attempting can't be done.");
                translators[2] = tm.EncryptMessages(translators[2], 2, 1);
                TestPrintTranslator(translators[2],4, "It is well known that a vital ingredient of success is not knowing that what you're attempting can't be done.");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DecryptionTranslator\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintTranslator(translators[4],1, "Kv\"ku\"ygnn\"mpqyp\"vjcv\"c\"xkvcn\"");
                translators[4] = tm.DecryptMessages(translators[4], 2);
                TestPrintTranslator(translators[4],2, "Kv\"ku\"ygnn\"mpqyp\"vjcv\"c\"xkvcn\"");
                Console.WriteLine("----------------------------------------------------------------------");
            }

            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintTranslator(translators[5],1, "Curabitur pretium, turpis in imperdiet bibendum");
                translators[5] = tm.DecryptMessages(tm.EncryptMessages(tm.EncryptMessages(translators[5],  2,10), 3,10), 5);
                TestPrintTranslator(translators[5], 2, "Curabitur pretium, turpis in imperdiet bibendum");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintTranslator(translators[6],1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
                translators[6] = tm.SetTranslatorToBroken(tm.EncryptMessages(tm.DecryptMessages(translators[6], 2),4, 3), "Out of order");
                TestPrintTranslator(translators[6], 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintTranslator(translators[7],1, "Quisque auctor arcu a ante lobortis");
                translators[7] = tm.EncryptMessages(tm.MakeTranslatorSmart(translators[7]), 23, 5);
                TestPrintTranslator(translators[7], 6, "Quisque auctor arcu a ante lobortis");
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("4\n");
                Console.ForegroundColor = ConsoleColor.White;
                TestPrintTranslator(translators[8],1, "Sed eu facilisis arcu.");
                translators[8] = tm.SetTranslatorToBroken(tm.DecryptMessages(tm.SetTranslatorToBroken(translators[8], "Old translator"), 5),"404");
                TestPrintTranslator(translators[8], 4, "Sed eu facilisis arcu.");
                Console.WriteLine("----------------------------------------------------------------------");
            }
			
			//Part 2
			{
				//Write your code here
			}
        }

        private static void TestPrintTranslator(ITranslator translator, int tries, string message)
        {
            Console.WriteLine($"Name: {translator.GetName()}");
            Console.WriteLine($"MaxLength: {translator.GetMaxLength()}");
            Console.WriteLine($"Type: {translator.GetTranslatorType()}");
            Console.WriteLine($"Translations left: {translator.GetTranslationsLeft()}");
            if(tries >0)
                Console.WriteLine($"First try: {translator.TranslateMessage(message)}");
            if (tries > 1)
            {
                for (int i = 0; i < tries - 2; i++)
                    translator.TranslateMessage(message);
                Console.WriteLine($"Last try: {translator.TranslateMessage(message)}");
            }
            Console.WriteLine("\n");
        }
        
    }
}