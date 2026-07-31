namespace CommanLib
{
    public abstract class LoginAbs
    {
        public abstract void Login(string userName, string password);
        public abstract void Logout();

        public bool LoginProcess()
        {
            return true;
        }
    }
}
