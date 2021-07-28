using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Model;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Services;
using WPFApp1.Services.Message;

namespace WPFApp1.ViewModel
{
    internal class ObjectPageViewModel : BindableBase
    {
        public int ide;
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        private readonly MessageBus _messageBus;
        public ObservableCollection<Main_Reestr> CurrentObjekt { get; set; } = new ObservableCollection<Main_Reestr>();
        public ObservableCollection<int> Guid { get; set; } = new ObservableCollection<int>();

        public ObjectPageViewModel(PageService navigation, DataService dataservice, MessageBus messageBus)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            _messageBus = messageBus;

            _ = _messageBus.Receive<Message>(this, async message =>
            {
                  await Task.Delay(10);
                  ide = message.Guid;
            });
            //_messageBus.Receive<Message>(new object(), async message => Guid.Add( message.Guid));

            CurrentObjekt = new ObservableCollection<Main_Reestr>(_dataservice.GetCurrentObjektInfo(_dataservice.Guid));

        }



    }
}
