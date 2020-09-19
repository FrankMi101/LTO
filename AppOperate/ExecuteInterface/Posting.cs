using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate.ExecuteInterface
{
  public  class Posting<T>
    {
        private readonly IPosting<T> _postingPosition;

        public Posting( IPosting<T> postingPosition)
        {
            this._postingPosition = postingPosition;
        }
        public List<T> Position(object parameter)
        {
              return _postingPosition.Position(parameter); 
        }

        public List<T> Positions(object parameter)
        {
            return _postingPosition.Positions(parameter);
        }

        public string Update(object parameter)
        {
            return _postingPosition.Update(parameter);

        }
    }

  public class Posting
  {
      private readonly IPosting _posting;

      public Posting(IPosting postingPosition)
      {
          this._posting = postingPosition;
      }
      public List<T> Position<T>(object parameter)
      {
          return _posting.Position<T>(parameter);
      }

      public List<T> Positions<T>(object parameter)
      {
          return _posting.Positions<T>(parameter);
      }

        public string Update(object parameter)
      {
          return _posting.Update(parameter);

      }
  }
}
