namespace MyApp
{
	public class MyClass : BaseClass
	{
		private string name;
		private string email;
		private bool isSelected;

		public string Name
		{
			set { SetProperty(ref name, value); }
			get { return name; }
		}

		public string Email
		{
			set { SetProperty(ref email, value); }
			get { return email; }
		}

		public bool IsSelected
		{
			set { SetProperty(ref isSelected, value); }
			get { return isSelected; }
		}

		public MyClass(string name, string email, bool isSelected)
		{
			Name = name;
			Email = email;
			IsSelected = isSelected;
		}
	}
}
