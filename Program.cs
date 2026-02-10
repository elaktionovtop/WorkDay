/*
Пользователь вводит число месяца.
Вывести для этого дня: выходной / рабочий день.
*/
/*
ввести месяц, количество дней, номер дня недели для 1-го числа месяца
цикл от 1 до дня недели начала месяца - 1
    вывести пробелы
цикл от 1 до конца месяца
    вывести число
    к дню недели прибавить 1
    если день недели больше 7
        установить день недели в 1
        перейти на новую строку
ввести число месяца
вывести название дня недели цветом:
    понедельник - черный
    вторник, среда, четверг - синий
    пятница - зеленый
    суббота, воскресенье - красный
*/

using static System.Console;
using static System.Net.Mime.MediaTypeNames;
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

    WriteMonth(month, daysNumber, firstWeekDayNumber);
    
    int dayNumber = EnterInteger("Введите число месяца: ");
    WriteDayOfWeek(month, dayNumber, firstWeekDayNumber);
}

void WriteMonth(string month, int daysNumber, int firstWeekDayNumber)
{
    WriteLine();
    WriteLine(month.ToUpper());
    WriteLine(" пн. вт. ср. чт. пт. сб. вс.");
    for(int i = 0; i < firstWeekDayNumber; i++)
    {
        Write("    ");
    }
    int weekDayNumber = firstWeekDayNumber;
    for(int day = 1; day <= daysNumber; day++)
    {
        Write($"{day,4}");
        weekDayNumber++;
        if(weekDayNumber == 7)
        {
            weekDayNumber = 0;
            WriteLine();
        }
    }
    WriteLine();
}

void WriteDayOfWeek(string month, int dayNumber, int firstWeekDayNumber)
{
    string[] weekDays = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", 
        "Суббота", "Воскресенье" };
    int weekDayNumber = (firstWeekDayNumber + dayNumber - 1) % 7;
    switch(weekDayNumber)
    {
        case 1:
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            break;
        case 2:
        case 3:
        case 4:
            ForegroundColor = ConsoleColor.Blue;
            break;
        case 5:
            ForegroundColor = ConsoleColor.Green;
            break;
        case 6:
        case 0:
            ForegroundColor = ConsoleColor.Red;
            break;
    }
    WriteLine($"{month}, {dayNumber}: {weekDays[weekDayNumber]}");
    ResetColor();
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
        text = ReadLine();
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
