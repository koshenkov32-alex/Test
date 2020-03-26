using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            using (StreamReader fs = new StreamReader(@"C:\test\inp.txt"))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    text += temp;
                }
            }
            int j1 = 0;
            int id = 1;
            int idR = 0;
            int idF = 0;
            int flag = 0;
            int flag1 = 0;
            int flag2 = 0;
            int flag3 = 0;
            int asdqwe = 0;
            int[] nums = new int[100000];





            string writePath = @"C:\test\out.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i <= text.Length; i++)
                    {
                        if (i == text.Length)
                        {
                            asdqwe = flag3 % 2;
                        }
                        if ((flag1 != 0 || flag == 1 || asdqwe != 0) && i == text.Length)
                        {
                            flag2 = 1;
                            break;
                        }



                        if ((Char.IsLetter(text[i]) || text[i] == '_' || Char.IsDigit(text[i])) && i != 0)
                        {
                            if (!Char.IsLetter(text[i - 1]) && text[i - 1] != '_' && !Char.IsDigit(text[i - 1]))
                                j1 = i;
                        }

                        switch (text[i])
                        {
                            case '=':
                                int i2 = 1;
                                for (int i1 = i; i1 < text.Length; i1++)
                                {
                                    if (text[i1] == ' ')
                                        i2++;
                                    if (text[i1] == '{' || text[i1] == '"')
                                        break;
                                }
                                if (text[i + i2] == '{' || text[i + i2] == '"')
                                {
                                    if (Char.IsDigit(text[j1]))
                                    {
                                        flag = 1;
                                        break;
                                    }

                                    for (int i12 = 0; i12 <= idF; i12++)
                                        Console.Write("   ");


                                    sw.Write("(");
                                    sw.Write("Id node ={0} ", id);
                                    sw.Write(",Id higher node = {0} ", idR);
                                    sw.Write(",Name = ");



                                    for (int j = j1; j < i; j++)
                                    {
                                        sw.Write(text[j]);
                                        Console.Write(text[j]);
                                    }


                                    id++;
                                    sw.Write(" ,Value = ");
                                    if (text[i + i2] == '"')
                                    {
                                        for (int j = i + i2 + 1; text[j] != '"'; j++)
                                        {
                                            sw.Write(text[j]);
                                        }
                                    }
                                    Console.WriteLine("");
                                    sw.WriteLine(")");
                                }
                                break;
                            case '}':
                                flag1--;
                                idF--;
                                idR = nums[idF];
                                break;
                            case '{':
                                flag1++;
                                nums[idF] = idR;
                                idR = id - 1;
                                idF++;
                                break;
                            case '"':
                                flag3++;
                                break;
                        }
                    }


                }
                if (flag2 == 1)
                {
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        Console.Clear();
                        sw.WriteLine("");
                        Console.WriteLine("Ошибка в синтаксисе");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
