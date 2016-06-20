﻿using System;

namespace Anathema.Source.Engine.Hook.Unrandomizer
{
    public interface IUnrandomizerInterface
    {
        void SetSeed(UInt32 Seed);

        void Disconnect();

    } // End interface

} // End namespace