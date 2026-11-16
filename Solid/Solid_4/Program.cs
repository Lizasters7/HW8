using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/

interface IPriceable
{
    void SetPrice(double price);
}

interface IDiscountable
{
    void ApplyDiscount(String discount);
}

interface IPromocodable
{
    void ApplyPromocode(String promocode);
}

interface IColorable
{
    void SetColor(byte color);
}

interface ISizeable
{
    void SetSize(byte size);
}

class Book : IPriceable, IDiscountable, IPromocodable
{
    public double Price { get; private set; }
    public string Discount { get; private set; }
    public string Promocode { get; private set; }

    public void SetPrice(double price) { Price = price; }
    public void ApplyDiscount(String discount) { Discount = discount; }
    public void ApplyPromocode(String promocode) { Promocode = promocode; }
}

class OuterWear : IPriceable, IDiscountable, IColorable, ISizeable
{
    public double Price { get; private set; }
    public string Discount { get; private set; }
    public byte Color { get; private set; }
    public byte Size { get; private set; }

    public void SetPrice(double price) { Price = price; }
    public void ApplyDiscount(String discount) { Discount = discount; }
    public void SetColor(byte color) { Color = color; }
    public void SetSize(byte size) { Size = size; }
}

class Program
{
    static void Main(string[] args)
    {
        var book = new Book();
        book.SetPrice(250);
        book.ApplyDiscount("10%");

        var jacket = new OuterWear();
        jacket.SetPrice(2000);
        jacket.SetColor(3);
        jacket.SetSize(48);
        jacket.ApplyDiscount("20%");

        Console.WriteLine($"The book: {book.Price} hrn, the discount: {book.Discount}");
        Console.WriteLine($"The jacket: {jacket.Price} hrn, the size: {jacket.Size}, the discount: {jacket.Discount}");

        Console.ReadKey();
    }
}