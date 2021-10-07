using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFApp1.Services
{
    public class PageService : BindableBase
    {
        private readonly Stack<Page> _history;


        public event Action<Page> OnePageChanged;
        public bool CanGoToBack => _history.Skip(1).Any();


        public PageService()
        {
            _history = new Stack<Page>();
        }

        public void ClearStack()
        {
            _history.Clear();
        }

        public void Navigate(Page page)
        {
            OnePageChanged?.Invoke(page);
            _history.Push(page);
            
        }

        internal void GoToBack()
       {
            _ = _history.Pop();
            var page = _history.Peek();
            OnePageChanged?.Invoke(_history.Peek());
        }
        internal void Refresh()
        {
            _ = _history.Pop();
        }


    }
}
