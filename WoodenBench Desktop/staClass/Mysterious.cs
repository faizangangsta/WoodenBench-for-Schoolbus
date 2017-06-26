using System;
using System.Windows.Forms;
using static WoodenBench.staClass.GlobalFunc;

namespace WoodenBench.staClass
{
    public static class Mysterious
	{
		public static void ShowMys()
		{
			MessageBox.Show("Hello From Leroy!");
			MessageBox.Show("Nice to meet you in the split bar!");
			MessageBox.Show("I will leed you to the MYSTERIOUS Place");
			MessageBox.Show("Don't worry, this will be a peaceful journey.");

			MessageBox.Show("First, verify your password is " + CurrentUser.Password);
			MessageBox.Show("Then, Remenber your User ID " + CurrentUser.objectId);

            MessageBox.Show("Finally, this is to show my REAL heart....");
            MessageBox.Show("Have you found any spelling mistakes?");
		}
	}
}
