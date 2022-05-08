using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;//mã hóa mật khẩu md5
using System.Text.RegularExpressions;


namespace Custom
{
    public class txtPassword : TextBox
    {
        ErrorProvider err = new ErrorProvider();
        public txtPassword()
        {
            this.Leave+=txtPassword_Leave;
            this.UseSystemPasswordChar = true;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            err.Clear();
            if (IsStrongPass(this.Text) == false)
            {
                err.SetError(this, "Mật khẩu này chưa đủ mạnh, phải có:\r\n1. Tối thiểu 1 ký tự hoa.\r\n2. Tối thiểu 1 ký tự thường.\r\n3. Tối thiểu 1 ký tự đặc biệt.\r\n4. Tối thiểu 1 số.\r\n5. Tối thiểu 8 ký tự.\r\n6. Tối đa 30 ký tự.");
                //this.Focus();
            }
            else
            {
                err.Clear();
            }
        }
        public StringBuilder encrypt(String str)
        {
            StringBuilder sb = new StringBuilder();
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] hash = md5.ComputeHash(inputBytes);
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x"));
            }
            return sb;
        }
        public static bool IsStrongPass(String password)
        {

            // Regex to check valid password.
            String regex = "^(?=.*[0-9])"
                           + "(?=.*[a-z])(?=.*[A-Z])"
                           + "(?=.*[@#$%^&+=])"
                           + "(?=\\S+$).{8,20}$";
            //1. Min 1 uppercase letter.
            //2. Min 1 lowercase letter.
            //3. Min 1 special character.
            //4. Min 1 number.
            //5. Min 8 characters.
            //6. Max 30 characters.
            // Compile the ReGex
            Regex re = new Regex(regex);
            if (re.IsMatch(password))
                return (true);
            else
                return (false);
        }

    }
}
