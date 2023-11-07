public class Rectangle : Shape{
    private double _width;
    private double _length;

    public Rectangle(string color, double width, double length){
        _color = color;
        _width = width;
        _length = length;
    }

    public override double Area()
    {
        return _width * _length;
    }
}