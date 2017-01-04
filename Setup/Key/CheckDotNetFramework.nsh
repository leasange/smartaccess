/*
 * Name: CheckDotNetFramework.nsh
 * Version: 0.1
 * Date: 20110720
 *
 * Author: Michael Mefford
 * Contact info: meffordm@gmail.com
 *
 * Description: NSIS header file to check a windows system for a specified .NET
 *              framework.  CheckDotNetFramework.nsh uses the NSIS stack to
 *              receive and pass values.
 *
 * Modified from: http://nsis.sourceforge.net/How_to_Detect_any_.NET_Framework
 *
 * License: Copyright (C) 2011  Michael Mefford
 *
 *          This software is provided 'as-is', without any express or implied
 *          warranty. In no event will the author(s) be held liable for any
 *          damages arising from the use of this software.
 *
 *          Permission is granted to anyone to use this software for any
 *          purpose, including commercial applications, and to alter it and
 *          redistribute it freely, subject to the following restrictions:
 *
 *             1. The origin of this software must not be misrepresented;
 *                you must not claim that you wrote the original software.
 *                If you use this software in a product, an acknowledgment in
 *                the product documentation would be appreciated but is not
 *                required.
 *
 *             2. Altered versions must be plainly marked as such,
 *                and must not be misrepresented as being the original software.
 *
 *             3. This notice may not be removed or altered from any
 *                distribution.
 *
 * Usage: Push ${DotNetFrameworkVersion}
 *        Call CheckDotNetFramework
 *        Exch $R0
 *        StrCmp $R0 "0" found not_found
 *
 * Algorithm: ...
 *
 * Input: A .NET Framework version.  This must be verbatim, including major,
 *        minor, and build version - i.e.
 *
 *          1.1.4322
 *          2.0.50727
 *          3.0
 *          3.5
 *          4
 *          4.0
 *          .
 *          .
 *          .
 *          etc.
 *
 * Output: "0" if the requested .Net Framework version IS FOUND
 *         "1" if the requested .NET Framework version IS NOT FOUND
 *
 */
 Function CheckDotNetFramework

  /* Exchange $R0 with the top of the stack to get the value passed by caller */
  Exch $R0

  /* Save other NSIS registers */
  Push $R1
  Push $R2
  Push $R3

  /* Zero out $R2 for the indexer */
  StrCpy $R3 "0"

loop:
  /* Get each sub key under "SOFTWARE\Microsoft\NET Framework Setup\NDP" */
  EnumRegKey $R1 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP" $R3
  StrCmp $R1 "" version_not_found  /* Requested version is not found */

  StrCpy $R2 $R1 "" 1              /* Remove "v" from subkey */
  StrCmp $R2 $R0 version_found     /* Requested version is found */

  IntOp $R3 $R3 + 1                /* Increment registry key index */
  Goto loop

/* The requested .Net Framework version WAS NOT FOUND on this system */
version_not_found:
  /* Restore the registers saved earlier */
  Pop $R3
  Pop $R2
  Pop $R1
  Pop $R0

  Push "1"  /* Put "1" on the top of the stack for caller to use */
  Goto end

/* The requested .Net Framework version WAS FOUND on this system */
version_found:
  /* Restore the registers saved earlier */
  Pop $R3
  Pop $R2
  Pop $R1
  Pop $R0

  Push "0"  /* Put "0" on the top of the stack for caller to use */
end:

FunctionEnd