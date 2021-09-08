using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SnakeGame
{
    public class Food
    {
        public void incerdNewEat(Button button)
        {
            var rnd = new Random();
            var rndX = rnd.Next(0, 5);
            var rndY = rnd.Next(0, 5);

            button.SetValue(Grid.ColumnProperty, rndX);
            button.SetValue(Grid.RowProperty, rndY);
            
        }


    }
}
