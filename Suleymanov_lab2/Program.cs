using System.Globalization;

Person pers1 = new Person();
Person pers2 = new Person("Ivanov", "Ivan", new DateTime(2004, 5, 20), 'М');
Person pers3 = new Person(pers1);
pers1.gender = 'ж';
Person pers4 = new Person();
pers4.Input();
pers1.Output();
pers2.Output();
pers3.Output();
Console.WriteLine(pers4.ToString());
Console.WriteLine(pers4.Age());
one();

void one()
{
    Console.WriteLine("Введите количество людей: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Person[] persons = new Person[n];
    for (int i = 0; i < persons.Length; i++)
    {
        persons[i] = new Person();
        persons[i].Input();
    }

    for (int i = 0; i < persons.Length; i++) Console.WriteLine($"{i + 1}. {persons[i].lastname} {persons[i].name[0]}. {persons[i].Age()} {persons[i].gender}");
    

}

class Person
{
    public string lastname { get; set; }
    public string name { get; set; }
    public DateTime birthday { get; set; }
    private char g;
    public char gender
    {
        get { return g; }
        set
        {
            if (value == 'М' || value == 'Ж' || value == 'м' || value == 'ж')
            {
                g = Char.ToUpper(value);
            }
            else
            {
                Console.WriteLine("Пол может иметь только значения: 'М' или 'Ж'");
            }
        }
    }

    public Person()
    {
        lastname = "Kuztecova";
        name = "Svetlana";
        birthday = new DateTime(2004, 6, 30);
        g = 'М';
    }

    public Person(string l, string n, DateTime bh, char s)
    {
        lastname = l;
        name = n;
        birthday = bh;
        g = s;
    }

    public Person(Person other)
    {
        lastname = other.lastname;
        name = other.name;
        birthday = other.birthday;
        g = other.g;
    }
    public void Input()
    {
        Console.Write("Введите фамилию:  ");
        lastname = Console.ReadLine();
        Console.Write("Введите имя: ");
        name = Console.ReadLine();
        Console.Write("Введите дату рождения (дд.мм.гггг): ");
        birthday = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        Console.Write("Пол (М/Ж): ");
        g = Convert.ToChar(Console.ReadLine());
    }

    public void Output()
    {
        Console.WriteLine($"Фамилия: {lastname}" +
            $"\nИмя: {name}" +
            $"\nДата рождения: {birthday.Day}.{birthday.Month}.{birthday.Year}" +
            $"\nПол: {g}\n");
    }
    public override string ToString()
    {
        return $"{lastname}, {name}, {birthday.Day}.{birthday.Month}.{birthday.Year}, {g}";
    }

    public int Age()
    {
        int age = DateTime.Now.Year - birthday.Year;
        if (DateTime.Now.DayOfYear < birthday.DayOfYear) age--;
        return age;
    }
}