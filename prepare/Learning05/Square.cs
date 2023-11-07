public class Square : Shape{
    private double _side;
    
    public Square(string color, double side){
        _color = color;
        _side = side;
    }

    public override double Area()
    {
        return _side * _side;
    }
}