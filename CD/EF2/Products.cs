public class Product
{
    public int ProductID { get; set; }

    public string maker { get; set; }

    public string model { get; set; }

    public string type { get; set; }
}

public class PC 
{
    public int PCID { get; set; }
    public int speed { get; set; }
    public int ram { get; set; }
     public int hd { get; set; }
     public float price { get; set; }
    public int ProductID { get; set; }
     public Product Product { get; set; }

}

public class Laptop 
{
    public int LaptopID { get; set; }
    public int speed { get; set; }
    public int ram { get; set; }
     public int hd { get; set; }
     public float screen { get; set; }
     public float price { get; set; }

     public int ProductID { get; set; }
     public Product Product { get; set; }

}

public class Printer 
{
    public int PrinterID { get; set; }
    public string color { get; set; }
    public string type { get; set; }
     public float price { get; set; }

     public int ProductID { get; set; }
     public Product Product { get; set; }
}

