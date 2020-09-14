using System;

namespace SimplExModel.Service
{
    public class InvalidPasswordException : Exception
    {
        public override string Message => "Неверный пароль.";
    }
}
