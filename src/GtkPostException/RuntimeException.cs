using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GtkPostException
{
public class RuntimeException : ApplicationException
{
public RuntimeException(string message): base(message){ }
public RuntimeException(string message, Exception inner): base(message, inner){}
}
}
