using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace SnakeGame
{
    class RoundRobinLst<T>
    {
        private readonly IList<T> _listF;
        private int _position;

        public RoundRobinLst(IList<T> listForward, int initPosition)
        {
            if (!listForward.Any())
                throw new NullReferenceException("list");

            _listF = new List<T>(listForward);
            _position = initPosition;
        }

        public T NextF()
        {
            //if (_listF.Last() is int last && _position == last)
            //{
            //    _position = -1;
            //}

            if (_position == _listF.IndexOf(_listF.Last()))
            {
                _position = -1;
            }

            _position++;
            return _listF[_position];
        }

        public T NextB()
        {
            if (_position == 0)
            {
                _position = _listF.Count;
            }

            _position--;
            return _listF[_position];
        }
    }
}

