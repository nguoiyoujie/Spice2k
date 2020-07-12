using System;

namespace Dune2000
{
	public delegate void UpdateDelegate();
	public delegate void UpdateDelegate<T>(T obj);
	public delegate void ErrorDelegate(string message, Exception exception);
}
