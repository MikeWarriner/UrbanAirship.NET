using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UrbanAirship.NET.Test
{
    public static class Helper
    {
        public static void AreJsonEqual(string expected, string actual)
        {
            expected = StripJson(expected);
            actual = StripJson(actual);
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    Assert.Fail(
                        "\r\n"+
                        "Expected  : "+expected+"\r\n"+
                        "Actual    : "+actual+"\r\n"+
                        "Failed at : "+i+"\r\n"+
                        "Length    : "+actual.Length);
                    return;
                }
            }
        }
        private static string StripJson(string a)
        {
            bool isQuoted = false;
            string b = "";
            foreach (char ch in a.ToCharArray())
            {
                if (isQuoted)
                {
                    b += ch;
                }
                else
                {
                    if (!Char.IsWhiteSpace(ch) &&
                        !(ch == '\n' || ch == '\r'))
                    {
                        b += ch;
                    }
                }
                if (ch == '\"') isQuoted = !isQuoted;
            }
            Console.WriteLine("STRIP SRC=" + a);
            Console.WriteLine("STRIP DST=" + b);
            return b;
        }

    }
}
