/*
 *   Copyright (c) 2023 Mikael Aboagye & Ultralight Inc.
 *   All rights reserved.

 *   Permission is hereby granted, free of charge, to any person obtaining a copy
 *   of this software and associated documentation files (the "Software"), to deal
 *   in the Software without restriction, including without limitation the rights
 *   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *   copies of the Software, and to permit persons to whom the Software is
 *   furnished to do so, subject to the following conditions:
 
 *   The above copyright notice and this permission notice shall be included in all
 *   copies or substantial portions of the Software.
 
 *   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *   SOFTWARE.
 */

#pragma once
#include <Ultralight/platform/FileSystem.h>
#include <UltralightUELibrary/ULUEDefines.h>
namespace ultralightue
{
    enum class ULTRALIGHTUE_EXPORT FSAccess : int
    {
        FSA_Native = 0x0001, /// Native UE FileSystem, should be used with editor modules.
        FSA_Package = 0x0002, /// Package FileSystem, should be used at runtime.
    };

    /// @brief Unreal Engine implementation of Ultralight's FileSystem.
    /*
    * NOTE: This is a internal class. you should not really be using this, unless you have a special filesystem to set.
    * HOW TO USE: SetFSAccess if you are using the native file system, or reading through package files, then provide to ULUEHandler.
    */
    class ULTRALIGHTUE_EXPORT ULUEFileSystem : public ultralight::FileSystem
    {
        public:
            void SetFSAccess(ultralightue::FSAccess& in_accesspattern);

            
        private:
            ultralightue::FSAccess m_access = FSAccess::FSA_Native;
        protected:
    }
}