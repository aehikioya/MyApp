namespace MyApp
{
	public class MyClass : BaseClass
	{
		private string name;
		private bool isSelected;

		public string Name
		{
			set { SetProperty(ref name, value); }
			get { return name; }
		}

		public bool IsSelected
		{
			set { SetProperty(ref isSelected, value); }
			get { return isSelected; }
		}

		public MyClass(string name, bool isSelected)
		{
			Name = name;
			IsSelected = isSelected;
		}
	}
}
