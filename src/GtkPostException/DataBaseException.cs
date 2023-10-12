using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Npgsql;

namespace GtkPostException
{
public class DataBaseException : ApplicationException
{
public DataBaseException(string message) : base(message) { }
public DataBaseException(string message, NpgsqlException inner):base(message,inner) { }
public DataBaseException(string message, Exception inner):base(message,inner) { }
}
}
