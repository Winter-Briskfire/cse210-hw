public class Product
{
    private string _name;
    private string _id;
    private double _pricePerUnit;
    private int _quantity;

    public Product(string name, string id, double pricePerUnit, int quantity)
    {
        _name = name;
        _id = id;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }

    public string GetName() => _name;
    public string GetId() => _id;
}
