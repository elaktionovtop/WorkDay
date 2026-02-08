/*
Пользователь вводит число месяца.
Вывести для этого дня: выходной / рабочий день.
*/

using static System.Console;

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
    int dayNumber = EnterInteger("Введите номер дня месяца (1-28): ");
    int remainder = dayNumber % 7;
    if (remainder == 0 || remainder == 1)
        WriteLine("Выходной день");
    else
        WriteLine("Рабочий день");
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
