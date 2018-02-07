using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp
{
	public class MasterViewModel : BaseClass
	{
		public ViewModelA viewModelA;
		public ViewModelB viewModelB;

		public ViewModelA ViewModelA
		{
			set { SetProperty(ref viewModelA, value); }
			get { return viewModelA; }
		}

		public ViewModelB ViewModelB
		{
			set { SetProperty(ref viewModelB, value); }
			get { return viewModelB; }
		}

		public MasterViewModel()
		{
			ViewModelA = new ViewModelA();
			ViewModelB = new ViewModelB();

			ViewModelA.SelectedItemChanged += ViewModelA_SelectedItemChanged;
		}

		private void ViewModelA_SelectedItemChanged(object sender, MyClass e)
		{
			ViewModelB.SelectedItemOnA = e;
		}
	}

	public class ViewModelA : BaseClass
	{
		public event EventHandler<MyClass> SelectedItemChanged;

		public ViewModelA()
		{
			ItemTapCommand = new Command<ItemTappedEventArgs>((ItemTappedEventArgs args) => SetSelectedItem(args));

			MyList = new ObservableCollection<MyClass>()
			{
				new MyClass("John", "john@gmail.com", false),
				new MyClass("Smith", "smith@hotmail.com", false),
				new MyClass("Sara", "sara@yahoo.com", false),
			};
		}

		private void SetSelectedItem(ItemTappedEventArgs args)
		{
			if (args.Item is MyClass myClass)
			{
				SelectedItem = myClass;
			}
		}

		private ObservableCollection<MyClass> myList;
		private MyClass selectedItem;

		public ObservableCollection<MyClass> MyList
		{
			set { SetProperty(ref myList, value); }
			get { return myList; }
		}

		public MyClass SelectedItem
		{
			set
			{
				if(SetProperty(ref selectedItem, value))
				{
					SelectedItemChanged?.Invoke(this, value);
				}
			}
			get { return selectedItem; }
		}

		public ICommand ItemTapCommand { get; set; }
	}

	public class ViewModelB : BaseClass
	{
		private MyClass selectedItemOnA;

		public MyClass SelectedItemOnA
		{
			set { SetProperty(ref selectedItemOnA, value); }
			get { return selectedItemOnA; }
		}
	}
}
