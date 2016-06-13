﻿using System;

namespace DirectXShell.Interface
{
    [Serializable]
    public class DisplayTextEventArgs : MarshalByRefObject
    {
        public String Text { get; set; }
        public TimeSpan Duration { get; set; }

        public DisplayTextEventArgs(String Text, TimeSpan Duration)
        {
            this.Text = Text;
            this.Duration = Duration;
        }

        public override string ToString()
        {
            return String.Format("{0}", Text);
        }

    } // End class

} // End namespace