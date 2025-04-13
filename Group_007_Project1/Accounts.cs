using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
namespace Group_007_Project1
{
    internal class Accounts
    {
        public string userName;
        public string password;
        public string name;
        public string pass;
        public string user;

      public Accounts(string userNames, string passwords)
        {
            userName = userNames;
            password = passwords;   
        }
       
        
        

        public void NewUser()
        {
            string user;
            user = userName + ":" + password;
            FileStream fs = new FileStream("user.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(user);
            MessageBox.Show("New account created");
            sw.Close();
            fs.Close();
        }
        public void Login() 
        {

            string userAcc;
            userAcc = userName + ":" + password;

           

            Form2 frm = new Form2();
            
            List<string> users = GetUser();

            if(users.Contains(userAcc))
            {
                MessageBox.Show("Login successful");
                frm.Show();
            }else
            {
                MessageBox.Show("Incorrect Password or Username");
            }
            
            //foreach (string user in users)
            //{
            //    name = FSplit(user);
            //    pass = SSplit(user);
            //    if (name == userName && pass == password)
            //    {

            //         MessageBox.Show("Login successfull");
            //         Form2 frm1 = new Form2();
            //         frm.Show();
            //    } 
            //}

        }
        public void Forgotpassword()
        {
            List<string> users = GetUser();

            string userAcc;
            userAcc = userName + ":" + password;
            bool exists = false;

            FileStream fs = new FileStream("user.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

           
           
                while (!sr.EndOfStream)
                {
                    user = sr.ReadLine();
                    if (user != "")
                    {
                        name = FSplit(user);
                        pass = SSplit(user);
                    }
                


                    if (userName == name)
                    {
                        MessageBox.Show($"The user {name} is avaliable. You cannot create same user.\nYour password is : {pass}");
                        exists = true;
                    }

                   

                }
            
            
               
                while(!sr.EndOfStream)
                {
                    user = sr.ReadLine();
                    if (user != "")
                    {
                    name = FSplit(user);
                    }
                    if (userName == name)
                    {
                        exists = true;
                    }
                }

                sr.Close();
                fs.Close();

                if (exists == false)
                {
                    NewUser();
                }
              
                
            

            sr.Close();
            fs.Close();


        }

        private string FSplit (string text)
        {

            string u;
            u = text.Substring(0, text.IndexOf(":"));

            return u;

        }

        private string SSplit (string text)
        {
            string u;
            int len = text.Length - text.IndexOf(":");
            u = text.Substring (text.IndexOf(":") + 1, (len -1));

            return u;
        }

        private List<string> GetUser()
        {
            FileStream fs = new FileStream("user.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            StreamWriter sw = new StreamWriter(fs);

            List<string> users = new List<string>();

            while(!sr.EndOfStream)
            {
                users.Add(sr.ReadLine());
            }


            sw.Close();
            sr.Close();
            fs.Close() ;

            return users;
        }

    }
}
