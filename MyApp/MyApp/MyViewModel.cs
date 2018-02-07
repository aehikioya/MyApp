using System.Collections.ObjectModel;

namespace MyApp
{
	public class MyViewModel : BaseClass
    {
		private ObservableCollection<MyClass> myList;
		private string selected;

		public ObservableCollection<MyClass> MyList
		{
			set { SetProperty(ref myList, value); }
			get { return myList; }
		}

		public string Selected
		{
			set { SetProperty(ref selected, value); }
			get { return selected; }
		}

		public MyViewModel()
		{
			MyList = new ObservableCollection<MyClass>()
			{
				AddNew("John", "john@gmail.com", false),
				AddNew("Smith", "smith@hotmail.com", false),
				AddNew("Sara", "sara@yahoo.com", false),
			};
		}

		private MyClass AddNew(string name, string email, bool isSelected)
		{
			var myClass = new MyClass(name, email, isSelected);
			myClass.PropertyChanged += MyClass_PropertyChanged;
			return myClass;
		}

		private void MyClass_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (sender is MyClass myClass)
			{
				Selected = $"{myClass.Name} is {myClass.IsSelected}";
			}
		}
		
	}
}
