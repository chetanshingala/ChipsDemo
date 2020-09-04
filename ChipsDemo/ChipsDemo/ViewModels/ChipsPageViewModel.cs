using System;
using System.Collections.ObjectModel;
using System.Linq;
using ChipsDemo.Model;
using Prism.Commands;
using Prism.Navigation;

namespace ChipsDemo.ViewModels
{
    public class ChipsPageViewModel : ViewModelBase
    {
        public ChipsPageViewModel(INavigationService navigationPage) : base(navigationPage)
        {
        }

        private ObservableCollection<ChipsModel> _itemCollection = new ObservableCollection<ChipsModel>();
        public ObservableCollection<ChipsModel> ItemCollection
        {
            get { return _itemCollection; }
            set { SetProperty(ref _itemCollection, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            ItemCollection = new ObservableCollection<ChipsModel>();
            ItemCollection.Add(new ChipsModel() { Id = 1, Title = "Google", IsSelected = false });
            ItemCollection.Add(new ChipsModel() { Id = 2, Title = "Yahoo message", IsSelected = true });
            ItemCollection.Add(new ChipsModel() { Id = 3, Title = "Google doc", IsSelected = false });
            ItemCollection.Add(new ChipsModel() { Id = 4, Title = "Miscrosoft", IsSelected = false });
            ItemCollection.Add(new ChipsModel() { Id = 5, Title = "Google Pay", IsSelected = false });
            ItemCollection.Add(new ChipsModel() { Id = 6, Title = "MSFT", IsSelected = false });
            ItemCollection.Add(new ChipsModel() { Id = 7, Title = "Amazon", IsSelected = false });
            ItemCollection.Add(new ChipsModel() { Id = 8, Title = "FlipCart", IsSelected = false });
            ItemCollection.Add(new ChipsModel() { Id = 9, Title = "Amozon pay", IsSelected = false });
        }

        public DelegateCommand<ChipsModel> ChipClickCommand
        {
            get { return new DelegateCommand<ChipsModel>((obj) => OnChipClickCommandExecuted(obj)); }
        }

        private void OnChipClickCommandExecuted(ChipsModel item)
        {
            ItemCollection.All(arg =>
            {
                if (arg.Id == item.Id)
                {
                    if (arg.IsSelected)
                        arg.IsSelected = false;
                    else
                        arg.IsSelected = true;
                }
                return true;
            });
        }


    }
}
