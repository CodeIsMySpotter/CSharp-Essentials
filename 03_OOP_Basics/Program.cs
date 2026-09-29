

Person person = new Person();
person.Introduce();

class Person
{
    public string FirstName { get; set; }
    string lastName;
    public string LastName
    {
        get { return lastName; }
        set
        {
            
            var isOk = true;
            foreach (char character in value.ToLower())
            {
                if (!char.IsLetter(character))
                {
                    isOk = false;
                    break;
                }
            }

            if (isOk)
            {
                lastName = value;
            }
        }
    }


    int age;
    public int Age {
        get { return age; }
        set
        {
            if(value> 0) age = value;
        }
    }


    public Person()
    {
        FirstName = "Codyseus";
        LastName = "Spotter";
        Age = 21;
    }

    public Person(string firstName, string lastNameArg, int ageArg)
    {
        FirstName = firstName;
        LastName = lastNameArg;
        Age = ageArg;
    }


    public void Introduce()
    {
        Console.WriteLine($"Hello, my name is {FirstName} {LastName} and my age is {Age}");
    }
}


