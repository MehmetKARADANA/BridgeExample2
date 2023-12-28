internal class Program
{
    private static void Main(string[] args)
    {
        Kitap k1 = new Kitap(new A5Boyut(),new  MaviKapak());

        magazineKapak d1 = new Dergi(new A4Boyut(),new KirmiziKapak());

        k1.KapakUret();
        d1.KapakUret();
    }
}

class magazineKapak { //abstraction

    private IBoyutImplementor boyut;
    private IRenkImplementor renk;

    public magazineKapak(IBoyutImplementor boyut, IRenkImplementor renk)
    {
        Boyut = boyut;
        Renk = renk;
    }

    internal IBoyutImplementor Boyut { get => boyut; set => boyut = value; }
    internal IRenkImplementor Renk { get => renk; set => renk = value; }

    public virtual void KapakUret() {
        boyut.KapakKes();
        renk.KapakBoya();
    }
}



interface IBoyutImplementor {
    public void KapakKes();
}

interface IRenkImplementor {
    public void KapakBoya();
}


class KirmiziKapak : IRenkImplementor
{
    public void KapakBoya()
    {
        Console.WriteLine("kapak Kirmiziya boyandı.");
    }
}

class MaviKapak : IRenkImplementor//concrete implementor
{
    public void KapakBoya()
    {
        Console.WriteLine("kapak Maviye boyandı.");
    }
}

class A4Boyut : IBoyutImplementor
{
    public void KapakKes()
    {
        Console.WriteLine("A4 kapak kesildi");
    }
}


class A5Boyut : IBoyutImplementor//concrete implementor
{
    public void KapakKes()
    {
        Console.WriteLine("A5 kapak kesildi");
    }
}

class Dergi : magazineKapak//refined
{
    public Dergi(IBoyutImplementor boyut, IRenkImplementor renk) : base(boyut, renk)
    {
    }
    public override void KapakUret()
    {
        Console.WriteLine("Dergi Kapağı üretiliyor");
        base.KapakUret();
        Console.WriteLine("Dergi Kapağı üretildi");
        Console.WriteLine("***");
      
    }

}

class Kitap : magazineKapak//refined
{
    public Kitap(IBoyutImplementor boyut, IRenkImplementor renk) : base(boyut, renk)
    {
    }
    public override void KapakUret()
    {
        Console.WriteLine("Kitap Kapağı üretiliyor");
        base.KapakUret();
        Console.WriteLine("Kitap Kapağı üretildi");
        Console.WriteLine("***");
    }

}