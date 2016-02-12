﻿using System;
using System.Text;
using System.Threading.Tasks;
using Anathema.MemoryManagement.Assembly.CallingConvention;
using Anathema.MemoryManagement.Native;

namespace Anathema.MemoryManagement.Memory
{
    /// <summary>
    /// Class representing a pointer in the memory of the remote process.
    /// </summary>
    public class RemotePointer : IEquatable<RemotePointer>
    {
        /// <summary>
        /// The address of the pointer in the remote process.
        /// </summary>
        public IntPtr BaseAddress { get; set; }
        /// <summary>
        /// Gets if the <see cref="RemotePointer"/> is valid.
        /// </summary>
        public virtual Boolean IsValid
        {
            get { return MemorySharp.IsRunning && BaseAddress != IntPtr.Zero; }
        }
        /// <summary>
        /// The reference of the <see cref="MemoryManagement.WindowsOSInterface"/> object.
        /// </summary>
        public WindowsOSInterface MemorySharp { get; protected set; }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RemotePointer"/> class.
        /// </summary>
        /// <param name="MemorySharp">The reference of the <see cref="MemoryManagement.WindowsOSInterface"/> object.</param>
        /// <param name="Address">The location where the pointer points in the remote process.</param>
        public RemotePointer(WindowsOSInterface MemorySharp, IntPtr Address)
        {
            // Save the parameters
            this.MemorySharp = MemorySharp;
            BaseAddress = Address;
        }
        #endregion

        #region Methods
        #region ChangeProtection
        /// <summary>
        /// Changes the protection of the n next bytes in remote process.
        /// </summary>
        /// <param name="Size">The size of the memory to change.</param>
        /// <param name="Protection">The new protection to apply.</param>
        /// <param name="MustBeDisposed">The resource will be automatically disposed when the finalizer collects the object.</param>
        /// <returns>A new instance of the <see cref="MemoryProtection"/> class.</returns>
        public MemoryProtection ChangeProtection(Int32 Size, MemoryProtectionFlags Protection = MemoryProtectionFlags.ExecuteReadWrite, Boolean MustBeDisposed = true)
        {
            return new MemoryProtection(MemorySharp, BaseAddress, Size, Protection, MustBeDisposed);
        }

        #endregion
        #region Equals (override)
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        public override bool Equals(Object Object)
        {
            if (ReferenceEquals(null, Object)) return false;
            if (ReferenceEquals(this, Object)) return true;
            return Object.GetType() == GetType() && Equals((RemotePointer)Object);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        public bool Equals(RemotePointer other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || (BaseAddress.Equals(other.BaseAddress) && MemorySharp.Equals(other.MemorySharp));
        }

        #endregion
        #region Execute
        /// <summary>
        /// Executes the assembly code in the remote process.
        /// </summary>
        /// <returns>The return value is the exit code of the thread created to execute the assembly code.</returns>
        public T Execute<T>()
        {
            return MemorySharp.Assembly.Execute<T>(BaseAddress);
        }

        /// <summary>
        /// Executes the assembly code in the remote process.
        /// </summary>
        /// <returns>The return value is the exit code of the thread created to execute the assembly code.</returns>
        public IntPtr Execute()
        {
            return Execute<IntPtr>();
        }

        /// <summary>
        /// Executes the assembly code in the remote process.
        /// </summary>
        /// <param name="Parameter">The parameter used to execute the assembly code.</param>
        /// <returns>The return value is the exit code of the thread created to execute the assembly code.</returns>
        public T Execute<T>(dynamic Parameter)
        {
            return MemorySharp.Assembly.Execute<T>(BaseAddress, Parameter);
        }

        /// <summary>
        /// Executes the assembly code in the remote process.
        /// </summary>
        /// <param name="Parameter">The parameter used to execute the assembly code.</param>
        /// <returns>The return value is the exit code of the thread created to execute the assembly code.</returns>
        public IntPtr Execute(dynamic Parameter)
        {
            return Execute<IntPtr>(Parameter);
        }

        /// <summary>
        /// Executes the assembly code in the remote process.
        /// </summary>
        /// <param name="CallingConvention">The calling convention used to execute the assembly code with the parameters.</param>
        /// <param name="Parameters">An array of parameters used to execute the assembly code.</param>
        /// <returns>The return value is the exit code of the thread created to execute the assembly code.</returns>
        public T Execute<T>(CallingConventions CallingConvention, params dynamic[] Parameters)
        {
            return MemorySharp.Assembly.Execute<T>(BaseAddress, CallingConvention, Parameters);
        }

        /// <summary>
        /// Executes the assembly code in the remote process.
        /// </summary>
        /// <param name="callingConvention">The calling convention used to execute the assembly code with the parameters.</param>
        /// <param name="Parameters">An array of parameters used to execute the assembly code.</param>
        /// <returns>The return value is the exit code of the thread created to execute the assembly code.</returns>
        public IntPtr Execute(CallingConventions callingConvention, params dynamic[] Parameters)
        {
            return Execute<IntPtr>(callingConvention, Parameters);
        }

        #endregion
        #region ExecuteAsync
        /// <summary>
        /// Executes asynchronously the assembly code in the remote process.
        /// </summary>
        /// <returns>The return value is an asynchronous operation that return the exit code of the thread created to execute the assembly code.</returns>
        public Task<T> ExecuteAsync<T>()
        {
            return MemorySharp.Assembly.ExecuteAsync<T>(BaseAddress);
        }

        /// <summary>
        /// Executes asynchronously the assembly code in the remote process.
        /// </summary>
        /// <returns>The return value is an asynchronous operation that return the exit code of the thread created to execute the assembly code.</returns>
        public Task<IntPtr> ExecuteAsync()
        {
            return ExecuteAsync<IntPtr>();
        }

        /// <summary>
        /// Executes asynchronously the assembly code located in the remote process at the specified address.
        /// </summary>
        /// <param name="Parameter">The parameter used to execute the assembly code.</param>
        /// <returns>The return value is an asynchronous operation that return the exit code of the thread created to execute the assembly code.</returns>
        public Task<T> ExecuteAsync<T>(dynamic Parameter)
        {
            return MemorySharp.Assembly.ExecuteAsync<T>(BaseAddress, Parameter);
        }

        /// <summary>
        /// Executes asynchronously the assembly code located in the remote process at the specified address.
        /// </summary>
        /// <param name="Parameter">The parameter used to execute the assembly code.</param>
        /// <returns>The return value is an asynchronous operation that return the exit code of the thread created to execute the assembly code.</returns>
        public Task<IntPtr> ExecuteAsync(dynamic Parameter)
        {
            return ExecuteAsync<IntPtr>(Parameter);
        }

        /// <summary>
        /// Executes asynchronously the assembly code located in the remote process at the specified address.
        /// </summary>
        /// <param name="CallingConvention">The calling convention used to execute the assembly code with the parameters.</param>
        /// <param name="Parameters">An array of parameters used to execute the assembly code.</param>
        /// <returns>The return value is an asynchronous operation that return the exit code of the thread created to execute the assembly code.</returns>
        public Task<T> ExecuteAsync<T>(CallingConventions CallingConvention, params dynamic[] Parameters)
        {
            return MemorySharp.Assembly.ExecuteAsync<T>(BaseAddress, CallingConvention, Parameters);
        }

        /// <summary>
        /// Executes asynchronously the assembly code located in the remote process at the specified address.
        /// </summary>
        /// <param name="CallingConvention">The calling convention used to execute the assembly code with the parameters.</param>
        /// <param name="Parameters">An array of parameters used to execute the assembly code.</param>
        /// <returns>The return value is an asynchronous operation that return the exit code of the thread created to execute the assembly code.</returns>
        public Task<IntPtr> ExecuteAsync(CallingConventions CallingConvention, params dynamic[] Parameters)
        {
            return ExecuteAsync<IntPtr>(CallingConvention, Parameters);
        }

        #endregion
        #region GetHashCode (override)
        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        public override Int32 GetHashCode()
        {
            return BaseAddress.GetHashCode() ^ MemorySharp.GetHashCode();
        }

        #endregion
        #region Operator (override)
        public static Boolean operator ==(RemotePointer Left, RemotePointer Right)
        {
            return Equals(Left, Right);
        }

        public static Boolean operator !=(RemotePointer Left, RemotePointer Right)
        {
            return !Equals(Left, Right);
        }

        #endregion
        #region Read
        /// <summary>
        /// Reads the value of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="offset">The offset where the value is read from the pointer.</param>
        /// <returns>A value.</returns>
        public T Read<T>(Int32 Offset, out Boolean Success)
        {
            return MemorySharp.Read<T>(BaseAddress + Offset, out Success);
        }

        /// <summary>
        /// Reads the value of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="Offset">The offset where the value is read from the pointer.</param>
        /// <returns>A value.</returns>
        public T Read<T>(Enum Offset, out Boolean Success)
        {
            return Read<T>(Convert.ToInt32(Offset), out Success);
        }

        /// <summary>
        /// Reads the value of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>A value.</returns>
        public T Read<T>(out Boolean Success)
        {
            return Read<T>(0, out Success);
        }

        /// <summary>
        /// Reads an array of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="Offset">The offset where the values is read from the pointer.</param>
        /// <param name="count">The number of cells in the array.</param>
        /// <returns>An array.</returns>
        public T[] Read<T>(Int32 Offset, Int32 Count, out Boolean Success)
        {
            return MemorySharp.Read<T>(BaseAddress + Offset, Count, out Success);
        }

        /// <summary>
        /// Reads an array of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="offset">The offset where the values is read from the pointer.</param>
        /// <param name="Count">The number of cells in the array.</param>
        /// <returns>An array.</returns>
        public T[] Read<T>(Enum offset, Int32 Count, out Boolean Success)
        {
            return Read<T>(Convert.ToInt32(offset), Count, out Success);
        }

        #endregion
        #region ReadString
        /// <summary>
        /// Reads a string with a specified encoding in the remote process.
        /// </summary>
        /// <param name="Offset">The offset where the string is read from the pointer.</param>
        /// <param name="Encoding">The encoding used.</param>
        /// <param name="MaxLength">[Optional] The number of maximum bytes to read. The string is automatically cropped at this end ('\0' char).</param>
        /// <returns>The string.</returns>
        public String ReadString(Int32 Offset, Encoding Encoding, out Boolean Success, Int32 MaxLength = 512)
        {
            return MemorySharp.ReadString(BaseAddress + Offset, Encoding, out Success, MaxLength);
        }

        /// <summary>
        /// Reads a string with a specified encoding in the remote process.
        /// </summary>
        /// <param name="Offset">The offset where the string is read from the pointer.</param>
        /// <param name="Encoding">The encoding used.</param>
        /// <param name="MaxLength">[Optional] The number of maximum bytes to read. The string is automatically cropped at this end ('\0' char).</param>
        /// <returns>The string.</returns>
        public String ReadString(Enum Offset, Encoding Encoding, out Boolean Success, Int32 MaxLength = 512)
        {
            return ReadString(Convert.ToInt32(Offset), Encoding, out Success, MaxLength);
        }

        /// <summary>
        /// Reads a string with a specified encoding in the remote process.
        /// </summary>
        /// <param name="Encoding">The encoding used.</param>
        /// <param name="MaxLength">[Optional] The number of maximum bytes to read. The string is automatically cropped at this end ('\0' char).</param>
        /// <returns>The string.</returns>
        public String ReadString(Encoding Encoding, out Boolean Success, Int32 MaxLength = 512)
        {
            return ReadString(0, Encoding, out Success, MaxLength);
        }

        /// <summary>
        /// Reads a string using the encoding UTF8 in the remote process.
        /// </summary>
        /// <param name="Offset">The offset where the string is read from the pointer.</param>
        /// <param name="MaxLength">[Optional] The number of maximum bytes to read. The string is automatically cropped at this end ('\0' char).</param>
        /// <returns>The string.</returns>
        public String ReadString(Int32 Offset, out Boolean Success, Int32 MaxLength = 512)
        {
            return MemorySharp.ReadString(BaseAddress + Offset, out Success, MaxLength);
        }

        /// <summary>
        /// Reads a string using the encoding UTF8 in the remote process.
        /// </summary>
        /// <param name="offset">The offset where the string is read from the pointer.</param>
        /// <param name="MaxLength">[Optional] The number of maximum bytes to read. The string is automatically cropped at this end ('\0' char).</param>
        /// <returns>The string.</returns>
        public String ReadString(Enum Offset, out Boolean Success, Int32 MaxLength = 512)
        {
            return ReadString(Convert.ToInt32(Offset), out Success, MaxLength);
        }

        #endregion
        #region ToString (override)
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        public override String ToString()
        {
            return string.Format("BaseAddress = 0x{0:X}", BaseAddress.ToInt64());
        }

        #endregion
        #region Write
        /// <summary>
        /// Writes the values of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="Offset">The offset where the value is written from the pointer.</param>
        /// <param name="Value">The value to write.</param>
        public void Write<T>(Int32 Offset, T Value)
        {
            MemorySharp.Write(BaseAddress + Offset, Value);
        }

        /// <summary>
        /// Writes the values of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="Offset">The offset where the value is written from the pointer.</param>
        /// <param name="Value">The value to write.</param>
        public void Write<T>(Enum Offset, T Value)
        {
            Write(Convert.ToInt32(Offset), Value);
        }

        /// <summary>
        /// Writes the values of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="Value">The value to write.</param>
        public void Write<T>(T Value)
        {
            Write(0, Value);
        }

        /// <summary>
        /// Writes an array of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="Offset">The offset where the values is written from the pointer.</param>
        /// <param name="Array">The array to write.</param>
        public void Write<T>(Int32 Offset, T[] Array)
        {
            MemorySharp.Write(BaseAddress + Offset, Array);
        }

        /// <summary>
        /// Writes an array of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="Offset">The offset where the values is written from the pointer.</param>
        /// <param name="Array">The array to write.</param>
        public void Write<T>(Enum Offset, T[] Array)
        {
            Write(Convert.ToInt32(Offset), Array);
        }

        /// <summary>
        /// Writes an array of a specified type in the remote process.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="Array">The array to write.</param>
        public void Write<T>(T[] Array)
        {
            Write(0, Array);
        }

        #endregion
        #region WriteString
        /// <summary>
        /// Writes a string with a specified encoding in the remote process.
        /// </summary>
        /// <param name="Offset">The offset where the string is written from the pointer.</param>
        /// <param name="Text">The text to write.</param>
        /// <param name="Encoding">The encoding used.</param>
        public void WriteString(Int32 Offset, String Text, Encoding Encoding)
        {
            MemorySharp.WriteString(BaseAddress + Offset, Text, Encoding);
        }

        /// <summary>
        /// Writes a string with a specified encoding in the remote process.
        /// </summary>
        /// <param name="Offset">The offset where the string is written from the pointer.</param>
        /// <param name="Text">The text to write.</param>
        /// <param name="Encoding">The encoding used.</param>
        public void WriteString(Enum Offset, String Text, Encoding Encoding)
        {
            WriteString(Convert.ToInt32(Offset), Text, Encoding);
        }

        /// <summary>
        /// Writes a string with a specified encoding in the remote process.
        /// </summary>
        /// <param name="Text">The text to write.</param>
        /// <param name="Encoding">The encoding used.</param>
        public void WriteString(String Text, Encoding Encoding)
        {
            WriteString(0, Text, Encoding);
        }

        /// <summary>
        /// Writes a string using the encoding UTF8 in the remote process.
        /// </summary>
        /// <param name="Offset">The offset where the string is written from the pointer.</param>
        /// <param name="Text">The text to write.</param>
        public void WriteString(Int32 Offset, String Text)
        {
            MemorySharp.WriteString(BaseAddress + Offset, Text);
        }

        /// <summary>
        /// Writes a string using the encoding UTF8 in the remote process.
        /// </summary>
        /// <param name="Offset">The offset where the string is written from the pointer.</param>
        /// <param name="Text">The text to write.</param>
        public void WriteString(Enum Offset, String Text)
        {
            WriteString(Convert.ToInt32(Offset), Text);
        }

        /// <summary>
        /// Writes a string using the encoding UTF8 in the remote process.
        /// </summary>
        /// <param name="Text">The text to write.</param>
        public void WriteString(String Text)
        {
            WriteString(0, Text);
        }

        #endregion
        #endregion

    } // End class

} // End namespace