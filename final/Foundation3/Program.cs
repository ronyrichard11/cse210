using System;

class Address {
    private string street;
    private string city;
    private string state;
    private int zipCode;

    public Address(string street, string city, string state, int zipCode) {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public string GetFullAddress() {
        return $"{street}, {city}, {state} {zipCode}";
    }
}

class Event {
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address) {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GetStandardDetails() {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails() {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription() {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

class Lecture : Event {
    private string speakerName;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speakerName, int capacity) : base(title, description, date, time, address) {
        this.speakerName = speakerName;
        this.capacity = capacity;
    }

    public override string GetFullDetails() {
        return $"{base.GetFullDetails()}\nSpeaker: {speakerName}\nCapacity: {capacity}";
    }
}

class Reception : Event {
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail) : base(title, description, date, time, address) {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails() {
        return $"{base.GetFullDetails()}\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event {
    private string weather;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weather) : base(title, description, date, time, address) {
        this.weather = weather;
    }

    public override string GetFullDetails() {
        return $"{base.GetFullDetails()}\nWeather: {weather}";
    }
}

class Program {
    static void Main(string[] args) {
        Address address1 = new Address("8661 SE 96th Way", "Maraca", "CA", 84621);
        Address address2 = new Address("101 Disco Ave", "Parkland", "NY", 33071);
        Address address3 = new Address("422 Grove St", "Ottertown", "CO", 24680);

        Lecture lecture1 = new Lecture("C# Final Study Group", "Open Studygroup for our C# Final", new DateTime(2023, 6, 17), new TimeSpan(10, 0, 0), address1, "John Smith", 50);
        Reception reception1 = new Reception("Class Pizza Party", "Celebrate our success!", new DateTime(2023, 5, 1), new TimeSpan(18, 0, 0), address2, "rsvp@company.com");
        OutdoorGathering gathering1 = new OutdoorGathering("Park Fair", "Enjoy food and games under the Sun!", new DateTime(2023, 6, 15), new TimeSpan(12, 0, 0), address3, "Sunny with a high of 75°F");

        Console.WriteLine("Standard details for Lecture:");
        Console.WriteLine(lecture1.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full details for Reception:");
        Console.WriteLine(reception1.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short description for Outdoor Gathering:");
        Console.WriteLine(gathering1.GetShortDescription());
        Console.WriteLine();
    }
}