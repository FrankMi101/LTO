using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
   
    

    public interface Shape
    {
        void draw();
     
    }
    public class Rectangle : Shape
    {
        public void draw()
        {
            throw new NotImplementedException();
        }
    }
         
    public class Square: Shape
{
        public void draw()
        {
            Console.Out.WriteLine("Shape - Square");
        }

       
    }
    public class Circle : Shape
{
        public void draw()
        {
            Console.Out.WriteLine("Shape - Circle");
        }

       
    }
    public interface Color
    {
        void fill();
       
    }
    public class Red : Color
    {
        public void fill()
        {
            Console.Out.WriteLine("Fill Color - Red");
        }

       
    }
    public class Green : Color
    {
        public void fill()
        {
            Console.Out.WriteLine("Fill Color - Green");
        }

      
    }
    public class Blue : Color
    {
        public void fill()
        {
            Console.Out.WriteLine("Fill Color - Blue");
        }

      
    }
    public abstract class AbstractFactory
    {
       public abstract Color getColor(string color);
       public abstract Shape getShape(string shape);
    }

    public class ShapeFactory : AbstractFactory
    {
        public override Color getColor(string color)
        {
            throw new NotImplementedException();
        }
        public override Shape getShape(string shapeType)
        {
            switch (shapeType)
            {
                case "Rectangel":
                    return new Rectangle();
                  
                case "Circle":
                    return new Circle();
                  
                case "Square":
                    return new  Square();
                 
                default:
                    return null;
            }
        }
 
    }
    public class ColorFactory : AbstractFactory
    {
        
        public override Color getColor(string color)
        {
            switch (color)
            {
                case "Red":
                    return new Red();

                case "Blue":
                    return new Blue();

                case "Green":
                    return new Green();

                default:
                    return null;
            }
        }

        public override Shape getShape(string shape)
        {
            throw new NotImplementedException();
        }
    }

    public class FactoryProducer
    {
        public static AbstractFactory getFactory(string factory)
        {
            if (factory == "SHAPE")
            {
                return new ShapeFactory();
            }
            else  if (factory == "COLOR")
            {
                return new ColorFactory();
            }
            return null;
        }
    }
}
