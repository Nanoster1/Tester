using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace StructsConsole.RPN
{
    public class RPN
    {
        public static List<object> RPNAr { get; private set; }
        public static List<int> Indexes { get; } = new List<int>();
        public static void GetRPN(string text)
        {
            var expression = ParseExpression(text);
            RPNAr = ParseInRpn(expression).ToList();
            Indexes.Clear();
            GetIndexes();
        }

        private static void GetIndexes()
        {
            while (RPNAr.Contains("x"))
            {
                var i = RPNAr.IndexOf("x");
                Indexes.Add(i);
                RPNAr[i] = null;
            }
        }

        private static List<object> ParseExpression(string text)                                                              //Парсим выражение в лист объектов
        {
            var expression = new List<object>();
            for (int i = 0; i < text.Length; i++)
            {
                if (CheckDigit(text[i].ToString()) || ((text[i] == '-' || text[i] == '+') && !CheckDigit(text[i - 1].ToString()) && text[i - 1] != ')'))                                                            //Если число
                    expression.Add(ReadNumber(text, ref i));
                else if (CheckLeftBracket(text[i]) || CheckRightBracket(text[i]) || CheckStartEnd(text[i]))
                    expression.Add(text[i].ToString());
                else if (char.IsWhiteSpace(text[i]))
                    i++;
                else
                {
                    expression.Add(ReadOperation(text, ref i));
                }
            }
            return expression;
        }

        private static object ReadNumber(string text, ref int i)
        {
            if (text[i] == 'x')
                return "x";
            else
            {
                StringBuilder num = new StringBuilder().Append(text[i]);
                while (CheckDigit(text[i + 1].ToString()) || text[i + 1] == ',')
                {
                    i++;
                    num.Append(text[i]);
                }
                return double.Parse(num.ToString());
            }
        }

        private static Operation ReadOperation(string text, ref int i)
        {
            var @string = new StringBuilder().Append(text[i]);
            while (!CheckDigit(text[i + 1].ToString()) && text[i + 1] != '(' && text[i + 1] != ')')
            {
                if ("+-*/".Contains(text[i]))
                    break;
                i++;
                @string.Append(text[i]);
            }
            return ChooseOp(@string.ToString());
        }

        private static bool CheckDigit(string text)                       //Проверяем на число
        {
            if (double.TryParse(text.ToString(), out _) || text == "x")
                return true;
            return false;
        }

        private static bool CheckStartEnd(object text)                                //Проверяем на символ начала/конца выражения
        {
            if (text.ToString() == "⊥")
                return true;
            return false;
        }

        private static bool CheckLeftBracket(object text)
        {
            if (text.ToString() == "(")
                return true;
            return false;
        }

        private static bool CheckRightBracket(object text)
        {
            if (text.ToString() == ")")
                return true;
            return false;
        }
        static public Operation ChooseOp(object sym)
        {
            Operation op = null;
            switch (sym.ToString())
            {
                case ("+"):
                    op = new Plus();
                    break;
                case ("-"):
                    op = new Minus();
                    break;
                case ("*"):
                    op = new Mult();
                    break;
                case ("/"):
                    op = new Div();
                    break;
                case ("log"):
                    op = new Log();
                    break;
                case ("sin"):
                    op = new Sin();
                    break;
                case ("cos"):
                    op = new Cos();
                    break;
                case ("tg"):
                    op = new Tan();
                    break;
                case ("^"):
                    op = new Rank();
                    break;
                case ("sqrt"):
                    op = new Sqrt();
                    break;
            }
            return op;
        }

        private static object[] ParseInRpn(List<object> expression)
        {
            var california = new Stack<object>();
            var texas = new Stack<object>();
            var i = 0;
            while (true)
            {
                if (i == 0)                                                     //Символ начала строки идёт сразу во 2-й стек 
                {
                    texas.Push(expression[i]);
                    i++;
                }
                else if (CheckDigit(expression[i].ToString()))
                {
                    california.Push(expression[i]);
                    i++;
                }
                else if (CheckLeftBracket(expression[i]))
                {
                    texas.Push(expression[i]);
                    i++;
                }
                else if (CheckRightBracket(expression[i]))
                {
                    if (texas.Peek() is Operation)
                        california.Push(texas.Pop());
                    else if (CheckLeftBracket(texas.Peek()))
                    {
                        texas.Pop();
                        i++;
                    }
                    else
                        throw new SyntaxErrorException();
                }
                else if (expression[i] is Operation)
                {
                    switch ((expression[i] as Operation).Prior)
                    {
                        case (1):
                            texas.Push(expression[i]);
                            i++;
                            break;
                        case (2):
                            if (!(texas.Peek() is Operation) || (texas.Peek() as Operation).Prior == 3)
                            {
                                texas.Push(expression[i]);
                                i++;
                            }
                            else
                            {
                                california.Push(texas.Pop());
                            }
                            break;
                        case (3):
                            if (texas.Peek() is Operation)
                            {
                                california.Push(texas.Pop());
                            }
                            else
                            {
                                texas.Push(expression[i]);
                                i++;
                            }
                            break;
                    }
                }
                else if (CheckStartEnd(expression[i]))
                {
                    if (texas.Peek() is Operation)
                        california.Push(texas.Pop());
                    else if (CheckLeftBracket(texas.Peek()))                                                                           //ошибка
                        throw new Exception("Левая скобка в конце выражения");
                    else
                        break;
                }
            }
            return california.ToArray();
        }
    }
}
