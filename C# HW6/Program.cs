using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C__HW6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HW_File_01();
            HW_File_02();
            HW_File_Add01();
            HW_File_Add02();
            HW_File_Add03();

            HW_Random_01();
            HW_Random_02();
            HW_Random_03();
            HW_Random_Add01();
            HW_Random_Add02();
            HW_Random_Add03();
            HW_Random_Add03_solution2();

            HW_DateTime_01();
            HW_DateTime_02();
            HW_DateTime_03();
            HW_DateTime_04();
            HW_DateTime_05();
            HW_DateTime_06();
            HW_DateTime_Add01();
            HW_DateTime_Add02();
            HW_DateTime_Add03();

            Console.ReadKey();

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public static void HW_File_01()
        {
            Console.WriteLine("檔案處理題目1.寫一篇中文歌的歌詞到到自己指定的文字檔(使用UTF-8編碼)。\n");
            string path = @"../../../files_txt/HW_File_01.txt";
            string[] lyrics = { "高空彈跳的刺激我不想聽", "沒興趣冒險的遊戲", "當你邀請我為何輕易答應", "你的語氣讓我安心", "摩天輪上的夜景浪漫絢麗", "半空中我忘了恐懼", "當你親吻我分散了注意力", "怕高的我看見星星", "你讓天空失去距離", "我讓我離開了遲疑", "往上攀登愛情 告別回憶", "我在愛著你", "閉上眼睛等你抱緊", "輕撫我起伏的心", "你是唯一讓我勇敢的原因", "摩天輪上的夜景浪漫絢麗", "半空中我忘了恐懼", "當你親吻我分散了注意力", "怕高的我看見星星", "你讓天空失去距離", "我讓我離開了遲疑", "往上攀登愛情 告別回憶", "我在愛著你", "閉上眼睛等你抱緊", "輕撫我起伏的心", "你是唯一讓我勇敢的原因", "你讓天空如此靠近", "我讓我再認識自己", "往上攀登愛情 告別回憶", "我在愛著你", "深深呼吸讓你抱緊", "傾聽我起伏的心", "天堂出現你的愛是樓梯", "你讓天空失去距離", "我讓我離開了遲疑", "往上攀登愛情 告別回憶", "我在愛著你" };
            File.WriteAllLines(path, lyrics, Encoding.UTF8);

            Console.WriteLine("寫入完成！");
            Console.WriteLine("\n\n");
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_File_02()
        {
            Console.WriteLine("檔案處理題目2.讀取1.txt 顯示在畫面上。\n");
            string path = @"../../../files_txt/HW_File_01.txt";
            string ReadFiletexts = File.ReadAllText(path, Encoding.UTF8);
            Console.WriteLine(ReadFiletexts);

            Console.WriteLine("\n\n");
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_File_Add01()
        {
            Console.WriteLine("檔案處理補充練習題1.寫入九九乘法表資料到一個文字檔到自己指定的文字檔。\n");
            string path = @"../../../files_txt/HW_File_Add01.txt";
            string[] multTable = new string[30];
            int times = 0;
            for (int i = 1; i <= 7; i += 3)
            {
                for (int j = 1; j < 10; j++)
                {
                    multTable[times] = $"{i}*{j}={i * j:00}\t{i + 1}*{j}={(i + 1) * j:00}\t{i + 2}*{j}={(i + 2) * j:00}\t";
                    times++;
                }
                multTable[times] = "";  //排版用
                times++;  //排版用
            }
            File.WriteAllLines(path, multTable, Encoding.UTF8);
            Console.WriteLine("寫入完成！");

            Console.WriteLine("\n\n");
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_File_Add02()
        {
            Console.WriteLine("檔案處理補充練習題2.讀取1.txt 顯示在畫面上，並將1.txt 裡的阿拉伯數字，轉換成中文數字(壹、貳、叁、肆…..)，並儲存到指定的路徑。(UTF-8)\n");
            string path = @"../../../files_txt/HW_File_Add01.txt";
            string file_input = File.ReadAllText(path);
            Console.WriteLine(file_input);
            string file_output = file_input;

            string[] arr1 = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] arr2 = new string[] { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
            for (int i = 0; i < arr1.Length; i++)
            {
                file_output = file_output.Replace(arr1[i], arr2[i]);
            }


            string path2 = @"../../../files_txt/HW_File_Add02.txt";
            File.WriteAllText(path2, file_output, Encoding.UTF8);
            Console.WriteLine("寫入完成！");


            Console.WriteLine("\n\n");
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_File_Add03()
        {
            Console.WriteLine("檔案處理補充練習題3.讀取fc4bb.csv，並將此資料轉成HTML TABLE 格式，並儲存到指定的HTML檔裡。\n");
            string path = @"../../../files_csv/fc4bb.csv";
            string[] fileContentsDim1 = File.ReadAllLines(path, Encoding.UTF8);
            int rows = fileContentsDim1.Length;
            int cols = fileContentsDim1[0].Split(',').Length;

            string[,] fileContentsDim2 = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] temp = fileContentsDim1[i].Split(',');
                for (int j = 0; j < cols; j++)
                {
                    fileContentsDim2[i, j] = temp[j];
                }
            }

            string fc4bbHTML = "<div>\n\t<table>\n";

            for (int i = 0; i < rows; i++)
            {
                fc4bbHTML += "<tr>\n";
                for (int j = 0; j < cols; j++)
                {
                    fc4bbHTML += ("\t<td style=\"border: 1px solid\">" + fileContentsDim2[i, j] + "</td>\n");
                }
                fc4bbHTML += "</tr>\n";
            }

            fc4bbHTML += "\t</table>\n</div>";

            string pathHTML = @"../../../files_html/HW_File_Add03.html";
            File.WriteAllText(pathHTML, fc4bbHTML, Encoding.UTF8);

            Console.WriteLine("寫入完成");


            Console.WriteLine("\n\n");
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_Random_01()
        {
            Console.WriteLine("亂數題目1.請隨機由0~99產生一個數字輸出。\n");
            Random Rand = new Random();
            Console.WriteLine($"輸出結果：{Rand.Next(0, 100)}");
            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_Random_02()
        {
            Console.WriteLine("亂數題目2.請隨機由0~99產生10個數字輸出。\n");
            Random Rand = new Random();
            Console.WriteLine("輸出結果如下：");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Rand.Next(0, 100));
            }


            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_Random_03()
        {
            Console.WriteLine("亂數題目3.隨機幫每位學員產生成績，並寫入文字檔(欄位之間用，分開，換行寫入下一筆)。\n");
            string[] students = { "江苡煊", "黃韋菘", "吳瑋婷", "林郁庭", "何宜晴", "李核渝", "詹子霆", "謝易庭", "楊詠丞", "蔡宛珊", "郭聰盟" };
            int[] scores = new int[students.Length];
            Random Rand = new Random();
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = Rand.Next(0, 101);
            }
            string scoresContent = " 姓名 ，成績 \n";
            for (int i = 0; i < students.Length; i++)
            {
                scoresContent += $"{students[i]}，{scores[i]:00}\n";
            }
            string path = @"../../../files_txt/HW_Random_03.txt";
            File.WriteAllText(path, scoresContent);
            Console.WriteLine("寫入完成！");
            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_Random_Add01()
        {
            Console.WriteLine("亂數補充題1.請設計樂透開獎程式。\n");
            int[] lottery = new int[7];
            Random Rand = new Random();
            int i = 0;
            //抽出六碼
            while (i < 6)
            {
                int temp = Rand.Next(1, 50);
                if (lottery.Contains(temp))
                {
                    continue;
                }
                lottery[i] = temp;
                i++;
            }

            //抽出特別號
            while (true)
            {
                int temp = Rand.Next(1, 50);
                if (lottery.Contains(temp))
                {
                    continue;
                }
                lottery[i] = temp;
                break;
            }

            Array.Sort(lottery, 0, 6); //排序lottery這個陣列，從索引0開始，排序6個元素

            Console.Write("所抽出的大樂透號碼為：");
            for (int j = 0; j < 6; j++)
            {
                Console.Write($"{lottery[j]:00}  ");
            }
            Console.WriteLine($"特別號為{lottery[6]:00}。");

            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_Random_Add02()
        {
            Console.WriteLine("亂數補充題2.請在文字檔裡輸入所有午餐的店家，讀取文字檔，隨機抽出今天中午要吃哪一家。\n");
            string path = @"../../../files_txt/HW_Random_Add02.txt";
            string[] lunches = File.ReadAllLines(path);
            Random Rand = new Random();
            Console.WriteLine($"今天午餐吃 {lunches[Rand.Next(0, lunches.Length)]} 吧！");

            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_Random_Add03()
        {
            Console.WriteLine("亂數補充題3.請在文字檔裡輸入所有教室裡的學員名字，讀取文字檔，隨機抽出今天的值日生，抽過不能再被抽中，直到全部學員都被抽過，才可以再被抽。\n");
            string path = @"../../../files_txt/HW_Random_Add03.txt";
            string[] students= File.ReadAllLines(path);
            string[] students_Duty=new string[students.Length];
            Random rand= new Random();

            int i= 0;
            while (i< students.Length) 
            {
                string temp = students[rand.Next(0, students.Length)];
                if(students_Duty.Contains(temp))
                {
                    continue;
                }
                students_Duty[i] = temp;
                i++;
            }

            Console.WriteLine("此輪的值日生順序如下：");
            foreach(string duty in students_Duty)
            {
                Console.WriteLine(duty);
            }

            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_Random_Add03_solution2()
        {
            Console.WriteLine("亂數補充題3.請在文字檔裡輸入所有教室裡的學員名字，讀取文字檔，隨機抽出今天的值日生，抽過不能再被抽中，直到全部學員都被抽過，才可以再被抽。\n");
            string path = @"../../../files_txt/HW_Random_Add03.txt";
            string[] students = File.ReadAllLines(path);
            string[] students_Duty = new string[students.Length];
            Random rand = new Random();

            string[] studentsTemp = new string[students.Length];

            Array.Copy(students, studentsTemp, students.Length);

            for (int i = 0; i < studentsTemp.Length; i++)
            {
                int randInt = rand.Next(0, (studentsTemp.Length - i));
                string temp = studentsTemp[randInt];
                students_Duty[i] = temp;
                studentsTemp[randInt] = studentsTemp[(studentsTemp.Length - i-1)];
                studentsTemp[(studentsTemp.Length - i-1)] = temp;
            }


            Console.WriteLine("此輪的值日生順序如下：");
            foreach (string duty in students_Duty)
            {
                Console.WriteLine(duty);
            }

            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_01()
        {
            Console.WriteLine("日期題目1.顯示現在日期與時間\n");
            DateTime now = DateTime.Now;
            Console.WriteLine($"現在時間是：{now:yyyy年MM月dd日 tt hh時mm分ss秒}");
            Console.WriteLine("現在時間是：" + now);
            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_02()
        {
            Console.WriteLine("日期題目2.顯示再過30天為哪一天。\n");
            DateTime now = DateTime.Now;
            Console.WriteLine($"再過30天是{now.AddDays(30):yyyy年MM月dd日}");
            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_03()
        {
            Console.WriteLine("日期題目3.顯示24小時前的年月日時分秒。\n");
            DateTime now = DateTime.Now;
            Console.WriteLine($"24小時前是{now.AddHours(-24):yyyy年MM月dd日 tt hh時mm分ss秒}");

            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_04()
        {
            Console.WriteLine("日期題目4.取得目前是幾月。\n");
            DateTime now = DateTime.Now;
            Console.WriteLine($"現在是{now.Month}月");

            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_05()
        {
            Console.WriteLine("日期題目5.取得明年是否為閏年。(可以試試民國)\n");
            DateTime nextyear = DateTime.Now.AddYears(1);
            if (DateTime.IsLeapYear(nextyear.Year))
            {
                Console.WriteLine("明年是閏年。");
            }
            else
            {
                Console.WriteLine("明年不是閏年");
            }

            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_06()
        {
            Console.WriteLine("日期題目6.取得離2025年1月1日還有幾天。\n");
            DateTime now = DateTime.Now;
            int daysDifference = (int)(new DateTime(2025, 1, 1) - now).TotalDays;

            Console.WriteLine($"離2025年1月1日還有{daysDifference}天");
            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_Add01()
        {
            Console.WriteLine("日期補充題1.請顯示今天猴子做甚麼事。\n");
            Console.WriteLine("星期一，猴子穿新衣，");
            Console.WriteLine("星期二，猴子肚子餓，");
            Console.WriteLine("星期三，猴子去爬山，");
            Console.WriteLine("星期四，猴子看電視，");
            Console.WriteLine("星期五，猴子去跳舞，");
            Console.WriteLine("星期六，猴子去斗六，");
            Console.WriteLine("星期日，猴子過生日。\n");
            DateTime now = DateTime.Now;
            switch ((int)now.AddDays(2).DayOfWeek)
            {
                case 1:
                    Console.WriteLine("今天星期一，猴子穿新衣。");
                    break;
                case 2:
                    Console.WriteLine("今天星期二，猴子肚子餓。");
                    break;
                case 3:
                    Console.WriteLine("今天星期三，猴子去爬山。");
                    break;
                case 4:
                    Console.WriteLine("今天星期四，猴子看電視。");
                    break;
                case 5:
                    Console.WriteLine("今天星期五，猴子去跳舞。");
                    break;
                case 6:
                    Console.WriteLine("今天星期六，猴子去斗六。");
                    break;
                case 0:   //0是週日
                    Console.WriteLine("今天星期日，猴子過生日。");
                    break;
            }


            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_Add02()
        {
            Console.WriteLine("日期補充題2.輸入‘兩個日期，輸出兩個日期相差幾天。\n");
            Console.WriteLine("日期輸入格式：yyyy/mm/dd\n");
            string pattern = @"^\d{1,4}/\d{1,2}/\d{1,2}";
            string input1, input2;
            Regex regOj = new Regex(pattern);
            while (true)
            {
                Console.Write("請輸入第一個日期：");
                input1 = Console.ReadLine();
                if (regOj.IsMatch(input1))
                {
                    break;
                }
                Console.WriteLine("輸入錯誤，請重新輸入。\n");
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("請輸入第二個日期：");
                input2 = Console.ReadLine();
                if (regOj.IsMatch(input2))
                {
                    break;
                }
                Console.WriteLine("輸入錯誤，請重新輸入。\n");

            }


            string[] temp = input1.Split('/');
            int[] Dates = Array.ConvertAll(temp, Convert.ToInt32);
            DateTime Date1 = new DateTime(Dates[0], Dates[1], Dates[2]);

            temp = input2.Split('/');
            Dates = Array.ConvertAll(temp, Convert.ToInt32);
            DateTime Date2 = new DateTime(Dates[0], Dates[1], Dates[2]);

            int daysDifference = Math.Abs((int)(Date1 - Date2).TotalDays);

            Console.WriteLine($"\n這兩個日期相差{daysDifference}天");

            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public static void HW_DateTime_Add03()
        {
            Console.WriteLine("日期補充題3.兩光法師時常替人占卜，由於他算得又快有便宜，因此生意源源不絕，時常大排長龍，他想算得更快一點，因此找了你這位電腦高手幫他用電腦來加快算命的速度。");
            Console.WriteLine("\t他的占卜規則很簡單，規則是這樣的，隨機產生一個今年日期，然後依照下面的公式：");
            Console.WriteLine("M=月");
            Console.WriteLine("D=日");
            Console.WriteLine("S=(M*2+D)%3");
            Console.WriteLine("得到 S 的值，再依照 S 的值從 0 到 2 分別給予 普通、吉、大吉 等三種不同的運勢，輸出運勢。\n");

            Random Rand = new Random();
            DateTime randDate = new DateTime(DateTime.Now.Year, 1, 1);
            randDate = randDate.AddDays(Rand.Next(0, 366));

            int M = randDate.Month, D = randDate.Day,S=(M*2+D)%3;

            

            switch (S)
            {
                case 0:
                    Console.WriteLine("運勢：普通");
                    break;
                case 1:
                    Console.WriteLine("運勢：吉");
                    break;
                case 2:
                    Console.WriteLine("運勢：大吉");
                    break;
            }
            Console.WriteLine($"\n(驗算用)隨機的日期為：{randDate:yyyy/MM/dd}");


            Console.WriteLine("\n\n");

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

    }
}
