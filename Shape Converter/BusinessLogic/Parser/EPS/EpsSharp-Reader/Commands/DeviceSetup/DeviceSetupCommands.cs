﻿//
// Author:
//   Michael Göricke
//
// Copyright (c) 2019
//
// This file is part of ShapeConverter.
//
// ShapeConverter is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program. If not, see<http://www.gnu.org/licenses/>.

using EpsSharp.Eps.Core;

namespace EpsSharp.Eps.Commands.DeviceSetup
{
    /// <summary>
    /// Register device setup commands
    /// </summary>
    static internal class DeviceSetupCommands
    {
        /// <summary>
        /// Register device setup commands
        /// </summary>
        static public void Register(EpsInterpreter interpreter)
        {
            interpreter.RegisterCommand("currentpagedevice", new CurrentPageDeviceOperand());
            interpreter.RegisterCommand("showpage", new ShowPageOperand());
        }
    }
}