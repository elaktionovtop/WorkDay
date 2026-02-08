/*
Пользователь вводит число месяца.
Вывести для этого дня: выходной / рабочий день.
*/

using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

WriteTitle("Рабочий/нерабочий день");

bool repeat;
do
{
    WorkDay();
    WriteLine();
    Write("Хотите повторить? (д/н): ");
    string answer = ReadLine();
    repeat = answer.Trim().ToLower() == "д";
    WriteLine();
} while(repeat);

ExitApp();

void WorkDay()
{
    string month = EnterText("Введите название месяца: ");
    int daysNumber = EnterInteger("Введите количество дней в месяце: ");
    int firstWeekDayNumber = EnterInteger("Введите номер дня недели для 1-го числа: ");
    WriteLine(month.ToUpper());
    for (int day = 1; day <= daysNumber; day++)
    {
        Write($"{day, 4}");
        if (day % 7 == 0)
            WriteLine();
    }
}

int EnterInteger(string prompt)
{
    Write(prompt);
    bool result = int.TryParse(ReadLine(), out int number);
    while(!result)
    {
        Write($"Некорректный ввод. {prompt}");
        result = int.TryParse(ReadLine(), out number);
    }
    return number;
}

string EnterText(string prompt)
{
    Write(prompt);
    string text = ReadLine();
    while(string.IsNullOrEmpty(text))
    {
        Write($"Некорректный ввод. {prompt}");
    }
    return text;
}

void WriteTitle(string title)
{
    WriteLine(title);
    WriteLine(new string('-', title.Length));
    WriteLine();
}

void ExitApp()
{
    WriteLine();
    Write("Для выхода нажми Enter");
    ReadLine();
}
