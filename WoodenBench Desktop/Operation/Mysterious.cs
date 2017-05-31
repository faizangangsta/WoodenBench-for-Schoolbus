using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WoodenBench_Desktop.Controls.Users;

namespace WoodenBench_Desktop.Operation
{
    static class Mysterious
	{
		public static void ShowMys(UserTableElements NowUser)
		{
			MessageBox.Show("Hello From Leroy!");
			MessageBox.Show("Nice to meet you in the split bar!");
			MessageBox.Show("I will leed you to the MYSTERIOUS Place");
			MessageBox.Show("Don't worry, this will be a peaceful journey.");

			MessageBox.Show("First, verify your password is " + NowUser.Password);
			MessageBox.Show("Then, Remenber your User ID " + NowUser.UserID);

            MessageBox.Show("Finally, this is to show my REAL heart....");
            MessageBox.Show("Have you found any spelling mistakes?");
		}
	}
}
